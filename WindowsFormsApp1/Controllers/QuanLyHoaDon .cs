using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyHoaDon
    {
        private readonly HoaDon _hoaDon = new HoaDon();

        public async Task TaoHoaDonMoiAsync(int maHD, int maNV, int maBan, int loaiHD, int maKH)
        {
            try
            {
                await _hoaDon.TaoHoaDonMoiAsync(maHD, maNV, maBan, loaiHD, maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tạo hóa đơn mới: " + ex.Message);
            }
        }

        public async Task<DataTable> LayThongTinHoaDonCuaKHAsync(int maKH)
        {
            try
            {
                return await _hoaDon.LayThongTinHoaDonCuaKHAsync(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin hóa đơn của khách hàng: " + ex.Message);
            }
        }
    }
}
