using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyPhieuNhapHang
    {
        private readonly PhieuNhapHang phieuNhapHang = new PhieuNhapHang();

        public async void TaoPhieuNhapHang(int maPhieu, int maNV)
        {
            await phieuNhapHang.ThemPhieuNhapAsync(maPhieu, maNV);
        }

        public async Task ThemPhieuNhapAsync(int maPhieu, int maNV)
        {
            try
            {
                await phieuNhapHang.ThemPhieuNhapAsync(maPhieu, maNV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phiếu nhập hàng: " + ex.Message);
            }
        }

        public async Task<DataTable> LayChiTietPNAsync(int maNL)
        {
            try
            {
                return await phieuNhapHang.LayChiTietPNAsync(maNL);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public async Task<DataTable> LayTongTienAsync(int maPhieu)
        {
            try
            {
                return await phieuNhapHang.LayTongTienAsync(maPhieu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tính tổng tiền phiếu nhập: " + ex.Message);
            }
        }

        public async void LuuPhieuNhapHangAsync(string soPhieu, int maNV, DataGridView dgvPhieuNhap)
        {
            int soPhieuNhap = int.Parse(soPhieu);
            TaoPhieuNhapHang(soPhieuNhap, maNV);
            foreach (DataGridViewRow row in dgvPhieuNhap.Rows)
            {
                NguyenLieu nguyenLieu = new NguyenLieu()
                {
                    TenNL = row.Cells[0].Value?.ToString(),
                    DonViTinh = row.Cells[2].Value?.ToString(),
                    TrangThai = true,
                    MaNCC = int.Parse(row.Cells[5].Value?.ToString()),
                    SoLuong = float.Parse(row.Cells[1].Value?.ToString()),
                    HSD = DateTime.ParseExact(row.Cells[4].Value?.ToString().Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    MaPhieu = soPhieuNhap,
                    SoLuongNhap = float.Parse(row.Cells[1].Value?.ToString()),
                    TongTien = float.Parse(row.Cells[3].Value?.ToString().Replace(",", "").Replace(" VNĐ", "").Trim())
                };
                await nguyenLieu.ThemNguyenLieuAsync(nguyenLieu);
            }
        }
    }
}
