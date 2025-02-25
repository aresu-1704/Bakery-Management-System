using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class NhaBep
    {
        public int MaHH { get; set; }
        public int MaHoaDon { get; set; }
        public int? SoLuong { get; set; }
        public byte TrangThai { get; set; }

        private Connections data = new Connections();

        public async Task ThemVaoBepAsync(int maHD, int maHH, int soLuongNau)
        {
            string query = "sp_ThemVaoBep @MaHH, @MaHD, @SoLuong";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHH", maHH },
                { "@MaHD", maHD },
                { "@SoLuong", soLuongNau }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayDSDonBepAsync()
        {
            string query = "sp_LayDonBep";
            return await data.GetDataAsync(query);
        }

        public async Task CapNhatDonBepAsync(int maHD, int maHH, int trangThai)
        {
            string query = "sp_CapNhatDonBep @MaHoaDon, @MaHH, @TrangThai";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHoaDon", maHD },
                { "@MaHH", maHH },
                { "@TrangThai", trangThai }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayDSDonBepDaHoanThanhAsync()
        {
            string query = "sp_LayDonBepDaHoanThanh";
            return await data.GetDataAsync(query);
        }
    }
}
