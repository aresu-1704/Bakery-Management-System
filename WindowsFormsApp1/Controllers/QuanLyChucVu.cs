using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyChucVu
    {
        private ChucVu _chucVu = new ChucVu();

        // Lấy thông tin chức vụ
        public async Task<DataTable> LayChucVuAsync()
        {
            return await _chucVu.LayChucVuAsync();
        }

        // Lấy danh sách chức vụ
        public async Task<DataTable> LayDSChucVuAsync()
        {
            return await _chucVu.LayDSChucVuAsync();
        }

        // Cập nhật chức vụ
        public async Task CapNhatCVAsync(ChucVu chucVu)
        {
            await _chucVu.CapNhatCVAsync(chucVu);
        }

        // Thêm chức vụ
        public async Task ThemChucVuAsync(ChucVu chucVu)
        {
            await _chucVu.ThemChucVuAsync(chucVu);
        }

        // Xóa chức vụ
        public async Task XoaChucVuAsync(int maCV)
        {
            await _chucVu.XoaChucVuAsync(maCV);
        }
    }
}