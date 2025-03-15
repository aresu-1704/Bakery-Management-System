using BakeryManagementSystem.Models;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyDonTheoYeuCau
    {
        private ChiTietHoaDonTheoYeuCau chiTietHoaDon = new ChiTietHoaDonTheoYeuCau();
        private DonBepTheoYeuCau nhaBep = new DonBepTheoYeuCau();
        private HoaDon hoaDon = new HoaDon();
        private Ban ban = new Ban();
        private HangHoa hangHoa = new HangHoa();
        private int maHoaDon = 0;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }

        public List<ChiTietHoaDonTheoYeuCau> DanhSachSP { get => danhSachSP; set => danhSachSP = value; }

        private List<ChiTietHoaDonTheoYeuCau> danhSachSP = new List<ChiTietHoaDonTheoYeuCau>();

        #region  Hàm thêm sản phẩm vào hóa đơn và trả về có thêm hay cập nhật sản phẩm vừa thêm
        public bool ThemSanPham(string maHH, double giaBan, ref int index)
        {
            if (maHoaDon == 0)
            {
                return false;
            }
            if (danhSachSP.Any(p => p.MaHH == int.Parse(maHH)) == true)
            {
                return false;
            }
            DanhSachSP.Add(new ChiTietHoaDonTheoYeuCau(int.Parse(maHH), maHoaDon, giaBan));
            DanhSachSP[DanhSachSP.Count - 1].SoLuong = 1;
            index = DanhSachSP.Count - 1;
            return true;
        }
        #endregion

        #region Xóa sản phẩm
        public void XoaSanPham(int maHH)
        {
            int index = danhSachSP.FindIndex(p => p.MaHH == maHH);

            if (DanhSachSP[index].SoLuong == 0)
            {
                DanhSachSP.RemoveAt(index);
            }
        }
        #endregion

        #region Lưu hóa đơn vào cơ sở Dữ liệu
        public async System.Threading.Tasks.Task LuuCTHDAsync(int maNV, int maBan, int loaiHD, int maKH)
        {
            /*
             * Có thể lấy số lượng sẵn có từ database thay vì trong Session để xử lý bất đồng bộ trên database
             */
            int maHoaDon = DanhSachSP[0].MaHoaDon;

            await System.Threading.Tasks.Task.WhenAll(
                hoaDon.TaoHoaDonMoiAsync(maHoaDon, maNV, maBan, loaiHD, maKH),
                ban.CapNhatTinhTrangBanAsync(maHoaDon, maBan)
            );

            var tasks = new List<System.Threading.Tasks.Task>();

            //Thêm từng chi tiết hóa đơn vào cơ sở dữ liệu
            foreach (var sp in DanhSachSP)
            {
                tasks.Add(chiTietHoaDon.ThemCTHDTheoYeuCauAsync(sp.MaHoaDon, sp.MaHH, sp.SoLuong, (float)sp.GiaTien, sp.YeuCau, (float)sp.PhuThu));
                int soLuongNau = sp.SoLuong;
                tasks.Add(nhaBep.ThemVaoBepYCAsync(sp.MaHoaDon, sp.MaHH, soLuongNau));
            }

            await System.Threading.Tasks.Task.WhenAll(tasks);

            DanhSachSP.Clear();
            MaHoaDon = 0;
        }
        #endregion

        //Tạo mã hóa đơn
        public string GenerateUniqueNineDigitNumber()
        {
            Random random = new Random();
            var digits = Enumerable.Range(0, 10).ToList();
            digits = digits.OrderBy(x => random.Next()).ToList();
            var uniqueNumber = string.Join("", digits.Take(9));
            return uniqueNumber;
        }

        //Tính tổng tiền hóa đơn
        public decimal TongTien(DataGridView dgvHoaDon)
        {
            decimal tong = 0;

            foreach (DataGridViewRow row in dgvHoaDon.Rows)
            {
                var cellValue = row.Cells[3].Value;
                if (cellValue != null)
                {
                    string giaTri = cellValue.ToString().Replace(" VNĐ", "").Replace(",", "").Trim();
                    if (decimal.TryParse(giaTri, out decimal giaTriDecimal))
                    {
                        tong += giaTriDecimal;
                    }
                }
            }

            return tong;
        }

        //Cập nhật số lượng
        public (string, string, string) CapNhatSoLuongMoi(string maHH, string soLuongMoi, string yeuCau, float phuThu)
        {
            int soLuong = int.Parse(soLuongMoi);
            double thanhTien;

            if (danhSachSP.Any(p => p.MaHH == int.Parse(maHH)) == true)
            {
                int index = danhSachSP.FindIndex(p => p.MaHH == int.Parse(maHH));
                danhSachSP[index].SoLuong = soLuong;
                danhSachSP[index].YeuCau = yeuCau;
                danhSachSP[index].PhuThu = phuThu;
                thanhTien = danhSachSP[index].GiaTien * soLuong + phuThu;
                return (thanhTien.ToString("N0") + " VNĐ", yeuCau, phuThu.ToString());
            }
            return (null, null, null);
        }
    }
}
