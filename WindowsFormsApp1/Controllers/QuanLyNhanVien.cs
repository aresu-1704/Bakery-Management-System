using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyNhanVien
    {
        private NhanVien nhanVien = new NhanVien();

        public async Task<DataTable> LayNhanVienAsync(string maNV)
        {
            return await nhanVien.LayNhanVienAsync(int.Parse(maNV));
        }

        public async Task<DataTable> LayDSMucLuongNVAsync()
        {
            return await nhanVien.LayDSMucLuongNVAsync();
        }

        public async Task<DataTable> LayDSNhanVienAsync()
        {
            return await nhanVien.LayDSNhanVienAsync();
        }

        public async Task ThemNVAsync(NhanVien nhanVien)
        {
            await nhanVien.ThemNhanVienAsync(nhanVien);
        }

        public async Task CapNhatNVAsync(NhanVien nhanVien)
        {
            await nhanVien.CapNhatNhanVienAsync(nhanVien);
        }

        public async Task XoaNVAsync(int maNV)
        {
            await nhanVien.XoaNhanVienAsync(maNV);
        }

        public async Task ThemLaiNVAsync(string maNV)
        {
            await nhanVien.ThemLaiNhanVienAsync(int.Parse(maNV));
        }

    }
}
