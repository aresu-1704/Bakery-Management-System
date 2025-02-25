using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;

namespace BakeryManagementSystem.Models
{
    public class Ban
    {
        public int MaBan { get; set; }
        public bool TrangThai { get; set; }
        public int? MaHoaDon { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayDSBanAsync()
        {
            string query = "sp_LayDanhSachBan";
            return await data.GetDataAsync(query);
        }

        public async Task<DataTable> LayDSToanBoBanAsync()
        {
            string query = "sp_LayDSToanBoBan";
            return await data.GetDataAsync(query);
        }

        public async Task CapNhatTinhTrangBanAsync(int maHD, int maBan)
        {
            string query = "sp_CapNhatTinhTrangBan @MaBan, @MaHoaDon";

            var parameters = new Dictionary<string, Object>
            {
                { "@MaBan", maBan},
                { "@MaHoaDon", maHD }
            };
            
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ThemBanAsync()
        {
            string query = "INSERT INTO Ban(TrangThai) VALUES (@TrangThai)";

            var parameters = new Dictionary<string, object>
            {
                { "@TrangThai", 0 }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayTTHoaDonBanAsync(int maBan)
        {
            string query = "sp_LayThongTinHoaDonBan @MaBan";

            var parameters = new Dictionary<string, object>
            {
                { "@MaBan", maBan }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task DonBanAsync(int maBan)
        {
            string query = "sp_CapNhatDonBan @MaBan";

            var parameters = new Dictionary<string, object>
            {
                { "@MaBan", maBan }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

    }
}
