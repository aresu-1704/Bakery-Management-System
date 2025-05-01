using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyNhaCungCap
    {
        private readonly NhaCungCap _nhaCungCap = new NhaCungCap();

        public async Task<DataTable> LayDSNCCAsync()
        {
            try
            {
                return await _nhaCungCap.LayDSNCCAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhà cung cấp: " + ex.Message);
            }
        }

        public async Task<DataTable> LayNCCAsync(string maNCC)
        {
            try
            {
                return await _nhaCungCap.LayNCCAsync(maNCC);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin nhà cung cấp: " + ex.Message);
            }
        }

        public async Task ThemNhaCCAsync(NhaCungCap nhaCungCap)
        {
            try
            {
                await _nhaCungCap.ThemNhaCCAsync(nhaCungCap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message);
            }
        }

        public async Task CapNhatNCCAsync(NhaCungCap nhaCungCap)
        {
            try
            {
                await _nhaCungCap.CapNhatNCCAsync(nhaCungCap);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        public async Task XoaNhaCCAsync(string maNCC)
        {
            try
            {
                await _nhaCungCap.XoaNhaCCAsync(maNCC);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        public async Task ThemLaiNCCAsync(string maNCC)
        {
            try
            {
                await _nhaCungCap.ThemLaiNCCAsync(maNCC);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi khôi phục nhà cung cấp: " + ex.Message);
            }
        }
    }
}