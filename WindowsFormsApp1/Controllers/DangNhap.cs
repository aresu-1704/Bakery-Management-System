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
using System.ComponentModel;

namespace BakeryManagementSystem.Controllers
{
    public class DangNhap
    {
        private TaiKhoan taiKhoan = new TaiKhoan();
        private BamMatKhau bamMatKhau = new BamMatKhau();

        //Đăng nhập
        public async Task<short> KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            DataTable dt = await taiKhoan.LayTaiKhoanAsync(tenDangNhap);

            if (dt.Rows.Count == 0) return 0;

            byte[] hashPasswordDB = (byte[])dt.Rows[0]["MatKhau"];
            byte[] hashPassword = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhau), (byte[])dt.Rows[0]["Muoi"]);

            if (hashPassword.SequenceEqual(hashPasswordDB))
            {
                return 2;
            }
            else
            {
                await taiKhoan.CapNhatSoLanDangNhapAsync(tenDangNhap);
                return 1;
            }
        }

        //Xem trạng thái tài khoản
        public async Task<bool> KiemTraTaiKhoan(string tenDangNhap)
        {
            DataTable dt = await taiKhoan.LayTaiKhoanAsync(tenDangNhap);

            if (dt.Rows.Count == 0) return false;

            if (!(bool)(dt.Rows[0]["TrangThai"])) return false;

            return true;
        }

        public async Task<int> KiemTraSoLanDangNhapConLaiAsync(string tenDangNhap)
        {
            return await taiKhoan.KiemTraSoLanDangNhappAsync(tenDangNhap);
        }
    }
}
