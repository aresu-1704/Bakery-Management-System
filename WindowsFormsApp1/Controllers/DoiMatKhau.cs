using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
                DataTable dt = await taiKhoan.LayTaiKhoanAsync(tenDangNhap);

                if (dt.Rows.Count != 0)
                {
                    byte[] matKhauCu = (byte[])dt.Rows[0]["MatKhau"];
                    byte[] muoiCu = (byte[])dt.Rows[0]["Muoi"];

                    byte[] bamMatKhauMoi = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhauMoi), muoiCu);
                    if (bamMatKhauMoi.SequenceEqual(matKhauCu))
                    {
                        return false;
                    }
                }

                byte[] salt = bamMatKhau.TaoMuoi(16);
                byte[] hashPassword = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhauMoi), salt);
                await taiKhoan.DoiMatKhauAsync(tenDangNhap, hashPassword, salt);
                return true;
            }
        }
    }
}
