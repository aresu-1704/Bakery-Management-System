using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyKhuyenMai
    {
        private KhuyenMai khuyenMai = new KhuyenMai();

        public async Task<DataTable> LayThongTinKMAsync()
        {
            return await khuyenMai.LayDSKhuyenMaiAsync();
        }

        public async Task<DataTable> LayTTKMChiDinhAsync(string maKM)
        {
            return await khuyenMai.LayTTKhuyenMaiAsync(int.Parse(maKM));
        }

        public async Task CapNhatKMAsync(KhuyenMai khuyenMai)
        {
            await khuyenMai.CapNhatKhuyenMaiAsync(khuyenMai);
        }

        public async Task ThemKMAsync(KhuyenMai khuyenMai)
        {
            await khuyenMai.ThemKhuyenMaiAsync(khuyenMai);
        }

        public async Task XoaKMAsync(string maKM)
        {
            await khuyenMai.XoaDotKhuyenMaiAsync(int.Parse(maKM));
        }
    }
}