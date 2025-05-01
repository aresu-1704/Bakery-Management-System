using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyChucVu
    {
        private readonly ChucVu chucVu = new ChucVu();

        public async Task<DataTable> LayChucVuAsync()
        {
            try
            {
                return await chucVu.LayChucVuAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin chức vụ: " + ex.Message);
            }
        }

        public async Task<DataTable> LayDSChucVuAsync()
        {
            try
            {
                return await chucVu.LayDSChucVuAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chức vụ: " + ex.Message);
            }
        }

        public async Task CapNhatCVAsync(ChucVu chucVu)
        {
            try
            {
                await chucVu.CapNhatCVAsync(chucVu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật chức vụ: " + ex.Message);
            }
        }

        public async Task ThemChucVuAsync(ChucVu chucVu)
        {
            try
            {
                await chucVu.ThemChucVuAsync(chucVu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm chức vụ: " + ex.Message);
            }
        }

        public async Task XoaChucVuAsync(int maCV)
        {
            try
            {
                await chucVu.XoaChucVuAsync(maCV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa chức vụ: " + ex.Message);
            }
        }
    }
}