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

        public async Task<DataTable> LayThongTinChamCongChuaHoanThanhAsync(int maNV)
        {
            string query = "EXEC sp_LayLichChamCongChuaHoanThanh @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task ChamCongVaoCaAsync(int maNV)
        {
            string query = "EXEC sp_ChamCongVaoCa @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ChamCongTanCaAsync(int maNV)
        {
            string query = "EXEC sp_ChamCongTanCa @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
