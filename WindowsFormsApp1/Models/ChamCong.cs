using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class ChamCong
    {
        public int SoChamCong { get; set; }
        public int MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public bool? TinhTrangTraLuong { get; set; }
        public TimeSpan? Giovao { get; set; }
        public TimeSpan? Giotan { get; set; }
        public int MaPC { get; set; }

        private Connections data = new Connections();

        //Coi chừng khúc này
        public async Task<DataTable> LayDSChamCongAsync(string maNV, string ngayBatDau, string ngayKetThuc)
        {
            string query = "EXEC sp_LayLichChamCong @MaNV, @NgayBatDau, @NgayKetThuc";

            DateTime? startDate = DateTime.TryParse(ngayBatDau, out DateTime start) ? start : (DateTime?)null;
            DateTime? endDate = DateTime.TryParse(ngayKetThuc, out DateTime end) ? end : (DateTime?)null;

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@NgayBatDau", startDate.HasValue ? (object)startDate.Value : DBNull.Value },
                { "@NgayKetThuc", endDate.HasValue ? (object)endDate.Value : DBNull.Value }
            };

            return await data.GetDataAsync(query, parameters);
        }


        public async Task CapNhatTinhTrangLuongAsync(string ngayBatDau, string ngayKetThuc, int maNV)
        {
            string query = "EXEC sp_CapNhatTinhTrangLuong @MaNV, @NgayBatDau, @NgayKetThuc";

            DateTime? startDate = DateTime.TryParse(ngayBatDau, out DateTime start) ? start : (DateTime?)null;
            DateTime? endDate = DateTime.TryParse(ngayKetThuc, out DateTime end) ? end : (DateTime?)null;

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@NgayBatDau", startDate.HasValue ? (object)startDate.Value : DBNull.Value },
                { "@NgayKetThuc", endDate.HasValue ? (object)endDate.Value : DBNull.Value }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task DiemDanhAsync(int maNV, int maPC)
        {
            string query = "EXEC sp_ChamCongVaoCa @MaNV, @MaPC";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@MaPC", maPC }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task HuyDiemDanhAsync(int maNV, int maPC)
        {
            string query = "EXEC sp_HuyDiemDanh @MaNV, @MaPC";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV },
                { "@MaPC", maPC }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
