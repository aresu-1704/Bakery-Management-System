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
    public class DangNhap
    {
        private TaiKhoan taiKhoan = new TaiKhoan();
        private KmsEncryptionService kmsEncryptionService = new KmsEncryptionService();
        private BamMatKhau bamMatKhau = new BamMatKhau();
        //Đăng nhập
        public async Task<bool> KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            DataTable dt = await taiKhoan.LayTaiKhoanAsync(tenDangNhap);

            if (dt.Rows.Count == 0) return false;

            byte[] hashPasswordDB = (byte[])dt.Rows[0]["MatKhau"];
            byte[] hashPassword = await bamMatKhau.BamMatKhauAsync(Encoding.UTF8.GetBytes(matKhau), (byte[])dt.Rows[0]["Muoi"]);

            return hashPassword.SequenceEqual(hashPasswordDB);
        }
    }
}
