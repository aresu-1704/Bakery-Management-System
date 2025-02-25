using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class KhuyenMai
    {
        public int MaDotKhuyenMai { get; set; }
        public string TenKM { get; set; }
        public DateTime NgayBatDau { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public double ChietKhau { get; set; }
        
        private Connections data = new Connections();

        public async Task<DataTable> LayDSKhuyenMaiAsync()
        {
            string query = "EXEC sp_LayThongTinKM";
            return await data.GetDataAsync(query, null);
        }

        public async Task<DataTable> LayTTKhuyenMaiAsync(int maKM)
        {
            string query = "EXEC sp_LayTTKMChiDinh @MaKM";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", maKM }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task CapNhatKhuyenMaiAsync(KhuyenMai khuyenMai)
        {
            string query = "EXEC sp_CapNhatKM @MaKM, @TenKM, @NgayBatDau, @NgayKetThuc, @ChietKhau";
            var parameters = new Dictionary<string, object>
            {
                { "@TenKM", khuyenMai.TenKM },
                { "@NgayBatDau", khuyenMai.NgayBatDau },
                { "@NgayKetThuc", khuyenMai.NgayKetThuc },
                { "@ChietKhau", khuyenMai.ChietKhau },
                { "@MaKM", khuyenMai.MaDotKhuyenMai }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ThemKhuyenMaiAsync(KhuyenMai khuyenMai)
        {
            string query = "EXEC sp_ThemKhuyenMai @TenKM, @NgayBatDau, @NgayKetThuc, @ChietKhau";
            var parameters = new Dictionary<string, object>
            {
                { "@TenKM", khuyenMai.TenKM },
                { "@NgayBatDau", khuyenMai.NgayBatDau },
                { "@NgayKetThuc", khuyenMai.NgayKetThuc },
                { "@ChietKhau", khuyenMai.ChietKhau }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaDotKhuyenMaiAsync(int maKM)
        {
            string query = "EXEC sp_XoaKM @MaKM";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKM", maKM }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
