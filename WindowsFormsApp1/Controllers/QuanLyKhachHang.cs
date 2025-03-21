﻿using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyKhachHang
    {
        private KhachHang khachHang = new KhachHang();
        private HoaDon hoaDon = new HoaDon();

        public async Task<DataTable> TimKhachHangAsync(string maKH)
        {
            return await khachHang.TimKhachHangAsync(int.Parse(maKH));
        }

        public async Task<DataTable> LayDSKhachHangAsync()
        {
            return await khachHang.LayDSKhachHangAsync();
        }

        public async Task ThemKHAsync(KhachHang khachHang)
        {
            await khachHang.ThemKhachHangAsync(khachHang);
        }

        public async Task CapNhatKhachHangAsync(KhachHang khachHang)
        {
            await khachHang.CapNhatKhachHangAsync(khachHang);
        }

        public async Task XoaKHAsync(string maKH)
        {
            await khachHang.XoaKhachHangAsync(int.Parse(maKH));
        }

        public async Task<DataTable> LayThongTinHoaDonCuaKHAsync(int maKH)
        {
            try
            {
                return await hoaDon.LayThongTinHoaDonCuaKHAsync(maKH);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy thông tin hóa đơn của khách hàng: " + ex.Message);
            }
        }

    }
}
