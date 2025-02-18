using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class DoiMatKhau
    {
        private string tenDangNhap = null;

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }

        private TaiKhoan taiKhoan = new TaiKhoan();
        private DangKy kiemTraTaiKhoan = new DangKy();
        private BamMatKhau bamMatKhau = new BamMatKhau();

        public DoiMatKhau(string tenDangNhap)
        {
            this.tenDangNhap = tenDangNhap;
        }
        public async Task<bool> DoiMatKhauAsync(string tenDangNhap, string matKhauMoi)
        {
            if (await kiemTraTaiKhoan.KiemTraTaiKhoan(tenDangNhap))
            {
                return false;
            }
            else
            {
                try
                {
                    byte[] salt = null;
                    byte[] hashPassword = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhauMoi), salt);
                    taiKhoan.DoiMatKhauAsync(tenDangNhap, hashPassword, salt);
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                }
            }
        }
    }
}
