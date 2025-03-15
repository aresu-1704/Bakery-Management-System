using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyTaiKhoan
    {
        private readonly TaiKhoan _taiKhoan = new TaiKhoan();

        public async Task<DataTable> LayDSTaiKhoanAsync()
        {
            return await _taiKhoan.LayDSTaiKhoanAsync();
        }

        public async Task CapNhatKhoiPhucTKAsync(string tenDangNhap)
        {
            BamMatKhau bamMK = new BamMatKhau();
            byte[] _muoi = bamMK.TaoMuoi(16);
            byte[] _matKhau = await bamMK.BamMatKhauAsync(Encoding.UTF8.GetBytes("1234567890"), _muoi);
            await _taiKhoan.CapNhatKhoiPhucAsync(tenDangNhap, _matKhau, _muoi);
        }
    }
}
