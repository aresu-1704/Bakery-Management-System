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
    public class QuanLyBanHang
    {
        private ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
        private NhaBep nhaBep = new NhaBep();
        private HoaDon hoaDon = new HoaDon();
        private Ban ban = new Ban();
        private HangHoa hangHoa = new HangHoa();
        private int maHoaDon = 0;

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }

        public List<ChiTietHoaDon> DanhSachSP { get => danhSachSP; set => danhSachSP = value; }

        private List<ChiTietHoaDon> danhSachSP = new List<ChiTietHoaDon>();

        #region  Hàm thêm sản phẩm vào hóa đơn và trả về có thêm hay cập nhật sản phẩm vừa thêm
        public bool ThemSanPham(string maHH, double giaBan, int coSan, ref int index)
        {
            if (maHoaDon == 0)
            {
                return false;
            }
            if (danhSachSP.Any(p => p.MaHH == int.Parse(maHH)) == true)
            {
                return false;
            }
            DanhSachSP.Add(new ChiTietHoaDon(int.Parse(maHH), maHoaDon, giaBan, coSan));
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


            //Thêm từng chi tiết hóa đơn vào cơ sở dữ liệu
            foreach (var sp in DanhSachSP)
            {
                await chiTietHoaDon.ThemCTHDAsync(sp.MaHoaDon, sp.MaHH, sp.SoLuong, (float)sp.GiaTien);

                if (sp.SoLuong > sp.SoLuongSanCo)
                {
                    int soLuongNau = sp.SoLuong - sp.SoLuongSanCo;                    
                    await nhaBep.ThemVaoBepAsync(sp.MaHoaDon, sp.MaHH, soLuongNau);
                    await hangHoa.CapNhatSoLuongSanCoAsync(sp.MaHH, 0);
                }
                else
                {
                    await hangHoa.CapNhatSoLuongSanCoAsync(sp.MaHH, sp.SoLuongSanCo - sp.SoLuong);
                }
            }

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
        public string CapNhatSoLuongMoi(string maHH, string soLuongMoi)
        {
            int soLuong = int.Parse(soLuongMoi);
            double thanhTien;

            if (danhSachSP.Any(p => p.MaHH == int.Parse(maHH)) == true)
            {
                int index = danhSachSP.FindIndex(p => p.MaHH == int.Parse(maHH));
                danhSachSP[index].SoLuong = soLuong;
                thanhTien = danhSachSP[index].GiaTien * soLuong;
                return thanhTien.ToString("N0") + " VNĐ";
            }
            return null;
        }
    }
}
