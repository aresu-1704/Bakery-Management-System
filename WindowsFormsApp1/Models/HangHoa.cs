using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class HangHoa
    {
        public int MaHH { get; set; }

        public string TenHH { get; set; }

        public double GiaTien { get; set; }

        public int SanCo { get; set; }

        public byte[] HinhAnh { get; set; }

        public bool TrangThai { get; set; }

        public int? MaDotKhuyenMai { get; set; }
        public int DanhMuc {  get; set; }      

        private Connections data = new Connections();

        public async Task<DataTable> LayDSHangHoaAsync()
        {
            string query = "sp_LayThongTinSP";
            return await data.GetDataAsync(query);
        }

        public async Task<DataTable> LayDSHangHoaBinhThuongAsync()
        {
            string query = "sp_LaySPBinhThuong";
            return await data.GetDataAsync(query);
        }

        public async Task<DataTable> LayDSHangHoaTheoYeuCauAsync()
        {
            string query = "sp_LaySPTheoYeuCau";
            return await data.GetDataAsync(query);
        }

        public async Task CapNhatTTSPAsync(HangHoa hangHoa)
        {
            string query = "sp_CapNhatTTSanPham @MaHH, @TenHH, @GiaTien, @SanCo, @HinhAnh, @MaKM, @DanhMuc";
            var parameters = new Dictionary<string, object>
            {
                { "@TenHH", hangHoa.TenHH },
                { "@GiaTien", hangHoa.GiaTien },
                { "@SanCo", hangHoa.SanCo },
                { "@HinhAnh", hangHoa.HinhAnh },
                { "@MaKM", hangHoa.MaDotKhuyenMai == -1 ? 0 : hangHoa.MaDotKhuyenMai},
                { "@MaHH", hangHoa.MaHH },
                { "@DanhMuc", hangHoa.DanhMuc }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LaySanPhamAsync(int maHH)
        {
            string query = "sp_LayTTChiDinhSanPham @MaHH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHH", maHH }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task ThemSPAsync(HangHoa hangHoa)
        {
            string query = "sp_ThemSP @TenHH, @SanCo, @HinhAnh, @GiaTien, @MaKM, @DanhMuc";
            var parameters = new Dictionary<string, object>
            {
                { "@TenHH", hangHoa.TenHH },
                { "@GiaTien", hangHoa.GiaTien },
                { "@SanCo", hangHoa.SanCo },
                { "@HinhAnh", hangHoa.HinhAnh },
                { "@MaKM", hangHoa.MaDotKhuyenMai == -1 ? 0 : hangHoa.MaDotKhuyenMai},
                { "@DanhMuc", hangHoa.DanhMuc }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaSPAsync(int maHH)
        {
            string query = "sp_XoaSP @MaHH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHH", maHH }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task BanLaiSPAsync(int maHH)
        {
            string query = "sp_BanLai @MaHH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHH", maHH }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LaySanPhamKMAsync(int maKM)
        {
            string query = "sp_LayDSSPDangKM @MaKM";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", maKM }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task CapNhatSoLuongSanCoAsync(int maHH, int soLuong)
        {
            string query = "sp_CapNhatSoLuongSanCo @MaHH, @SoLuong";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHH", maHH },
                { "@SoLuong", soLuong }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}