using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyHoaDon
    {
        private readonly HoaDon _hoaDon = new HoaDon();
        private readonly ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
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

        public async Task<DataTable> LayChiTietHoaDonAsync(int maHD)
        {
            try
            {
                return await chiTietHoaDon.LayChiTietHoaDonAsync(maHD);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy chi tiết hóa đơn: " + ex.Message);
            }
        }
    }
}
