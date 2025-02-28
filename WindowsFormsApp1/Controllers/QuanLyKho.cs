﻿using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyKho
    {
        private KhoNguyenLieu khoNguyenLieu = new KhoNguyenLieu();
        private NguyenLieu nguyenLieu = new NguyenLieu();

        public async Task<DataTable> LayDSKhoNLAsync()
        {
            return await khoNguyenLieu.LayDanhSachKeNguyenLieuAsync();
        }

        public async Task<DataTable> LayDSNguyenLieuTrenKeAsync(int maKhuVuc)
        {
            return await khoNguyenLieu.LayDanhSachNguyenLieuAsync(maKhuVuc);
        }

        public async Task CapNhatViTriAsync(int maNL, int maKhuVuc)
        {
            await nguyenLieu.CapNhatViTriNLAsync(maNL, maKhuVuc);
        }

        public async Task ThemViTriAsync()
        {
            await khoNguyenLieu.ThemKeAsync();
        }

        public async Task DoiTrangThaiAsync(int maKhuVuc)
        {
            await khoNguyenLieu.DoiTrangThaiAsync(maKhuVuc);
        }

        public async Task XoaKeAsync(int maKhuVuc)
        {
            await khoNguyenLieu.XoaKeAsync(maKhuVuc);
        }
    }
}
