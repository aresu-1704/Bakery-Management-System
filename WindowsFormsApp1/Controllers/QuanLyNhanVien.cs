using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyNhanVien
    {
        private readonly NhanVien nhanVien = new NhanVien();

        // Lấy thông tin nhân viên theo mã
        public async Task<DataTable> LayNhanVienAsync(string maNV)
        {
            try
            {
                return await nhanVien.LayNhanVienAsync(int.Parse(maNV));
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin nhân viên: " + ex.Message);
            }
        }

        // Lấy danh sách mức lương nhân viên
        public async Task<DataTable> LayDSMucLuongNVAsync()
        {
            try
            {
                return await nhanVien.LayDSMucLuongNVAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách mức lương nhân viên: " + ex.Message);
            }
        }

        // Lấy danh sách nhân viên
        public async Task<DataTable> LayDSNhanVienAsync()
        {
            try
            {
                return await nhanVien.LayDSNhanVienAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nhân viên: " + ex.Message);
            }
        }

        // Thêm nhân viên mới
        public async Task ThemNVAsync(NhanVien nhanVien)
        {
            try
            {
                await nhanVien.ThemNhanVienAsync(nhanVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message);
            }
        }

        // Cập nhật thông tin nhân viên
        public async Task CapNhatNVAsync(NhanVien nhanVien)
        {
            try
            {
                await nhanVien.CapNhatNhanVienAsync(nhanVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhân viên: " + ex.Message);
            }
        }

        // Xóa nhân viên
        public async Task XoaNVAsync(int maNV)
        {
            try
            {
                await nhanVien.XoaNhanVienAsync(maNV);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        // Thêm lại nhân viên đã xóa
        public async Task ThemLaiNVAsync(string maNV)
        {
            try
            {
                await nhanVien.ThemLaiNhanVienAsync(int.Parse(maNV));
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm lại nhân viên: " + ex.Message);
            }
        }
    }
}