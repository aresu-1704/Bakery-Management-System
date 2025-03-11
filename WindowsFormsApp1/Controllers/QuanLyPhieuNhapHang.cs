using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyPhieuNhapHang
    {
        private readonly PhieuNhapHang phieuNhapHang = new PhieuNhapHang();

        public async Task ThemPhieuNhapAsync(string maPhieu, int maNV)
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
    }
}
