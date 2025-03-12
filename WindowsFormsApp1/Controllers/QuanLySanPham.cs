using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLySanPham
    {
        private HangHoa hangHoa = new HangHoa();

        public async Task<DataTable> LayDSHangHoaAsync()
        {
            return await hangHoa.LayDSHangHoaAsync();
        }

        public async Task<DataTable> LayDSHangHoaBinhThuongAsync()
        {
            return await hangHoa.LayDSHangHoaBinhThuongAsync();
        }

        public async Task<DataTable> LayDSHangHoaTheoYeuCauAsync()
        {
            return await hangHoa.LayDSHangHoaTheoYeuCauAsync();
        }

        public async Task CapNhatTTSPAsync(HangHoa hangHoa)
        {
            await hangHoa.CapNhatTTSPAsync(hangHoa);
        }

        public async Task<DataTable> LaySanPhamAsync(string maHH)
        {
            return await hangHoa.LaySanPhamAsync(int.Parse(maHH));
        }

        public async Task ThemSPAsync(HangHoa hangHoa)
        {
            await hangHoa.ThemSPAsync(hangHoa);
        }

        public async Task XoaSPAsync(string maHH)
        {
            await hangHoa.XoaSPAsync(int.Parse(maHH));
        }

        public async Task ThemLaiSPAsync(string maHH)
        {
            await hangHoa.BanLaiSPAsync(int.Parse(maHH));
        }

        public async Task<DataTable> LayDSSPKhuyenMaiAsync(string maKM)
        {
            return await hangHoa.LaySanPhamKMAsync(int.Parse(maKM));
        }

        public async Task CapNhatSoLuongAsync(int maHH, int soLuong)
        {
            await hangHoa.CapNhatSoLuongSanCoAsync(maHH, soLuong);
        }

    }
}
