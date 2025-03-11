using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyChiTietHoaDon
    {
        private readonly ChiTietHoaDon _chiTietHoaDon = new ChiTietHoaDon();

        public async Task ThemChiTietHoaDonAsync(int maHD, int maHH, int soLuong, float giaTien)
        {
            try
            {
                await _chiTietHoaDon.ThemCTHDAsync(maHD, maHH, soLuong, giaTien);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chi tiết hóa đơn: " + ex.Message);
            }
        }

        public async Task<DataTable> LayChiTietHoaDonAsync(int maHD)
        {
            try
            {
                return await _chiTietHoaDon.LayChiTietHoaDonAsync(maHD);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}