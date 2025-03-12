using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyPhanCong
    {
        private PhanCong _phanCong = new PhanCong();

        // Lấy danh sách phân công theo mã nhân viên
        public async Task<DataTable> LayDSPhanCongAsync(int maNV)
        {
            return await _phanCong.LayDSPhanCongAsync(maNV);
        }

        // Thêm lịch làm việc
        public async Task<bool> ThemLichLamAsync(PhanCong phanCong)
        {
            return await _phanCong.ThemLichLamAsync(phanCong);
        }

        // Cập nhật lịch làm việc
        public async Task<bool> CapNhatLichLamAsync(PhanCong phanCong)
        {
            return await _phanCong.CapNhatLichLamAsync(phanCong);
        }

        // Xóa lịch làm việc
        public async Task XoaLichLamAsync(int maPC)
        {
            await _phanCong.XoaLichLamAsync(maPC);
        }

        // Lấy lịch làm việc hôm nay
        public async Task<DataTable> LayLichLamViecHomNayAsync()
        {
            return await _phanCong.LayLichLamViecHomNay();
        }
    }
}