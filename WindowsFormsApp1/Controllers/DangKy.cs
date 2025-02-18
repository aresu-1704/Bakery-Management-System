using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BakeryManagementSystem.Models;
using BakeryManagementSystem.Security;
using DevExpress.XtraExport.Xls;
using BakeryManagementSystem;
using Google.Api;
using System.Security.Cryptography;

namespace BakeryManagementSystem.Controllers
{
    public class DangKy
    {
        private TaiKhoan taiKhoan = new TaiKhoan();
        private NhanVien nhanVien = new NhanVien();
        private BamMatKhau bamMatKhau = new BamMatKhau();

        //Kiểm tra nhân viên còn làm việc hay không
        public async Task<bool> KiemTraNhanVien(int maNV)
        {
            DataTable dt = await nhanVien.LayNhanVienAsync(maNV);
            if (dt.Rows.Count == 0) return false;
            if (!(bool)dt.Rows[0]["TrangThai"]) return false;
            return true;
        }

        //Kiểm tra tài khoản đã tồn tại chưa
        public async Task<bool> KiemTraTaiKhoan(string tenDangNhap)
        {
            DataTable dt = await taiKhoan.LayTaiKhoanAsync(tenDangNhap);
            if (dt.Rows.Count == 0) return true;
            return false;
        }

        //Đăng ký
        public async Task TaoTaiKhoan(string tenDangNhap, string matKhau, int maNV)
        {
            try
            {
                byte[] salt = null;
                byte[] hashedPassword = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhau), salt);

                await taiKhoan.TaoTaiKhoanAsync(tenDangNhap, hashedPassword, salt, maNV);
                Console.WriteLine("Tạo tài khoản thành công!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi tạo tài khoản: {ex.Message}");
            }
        }
    }
}
