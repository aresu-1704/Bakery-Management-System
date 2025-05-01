using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class ChucVu
    {
        public int MaCV { get; set; }
        public string TenCV { get; set; }
        public double? MucLuong { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayChucVuAsync()
        {
            string query = "EXEC sp_LayChucVu";
            return await data.GetDataAsync(query, null);
        }

        public async Task<DataTable> LayDSChucVuAsync()
        {
            string query = "EXEC sp_LayDanhSachChucVu";
            return await data.GetDataAsync(query, null);
        }

        public async Task CapNhatCVAsync(ChucVu chucVu)
        {
            string query = "EXEC sp_CapNhatChucVu @TenCV, @MucLuong, @MaCV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCV", chucVu.MaCV },
                { "@TenCV", chucVu.TenCV },
                { "@MucLuong", chucVu.MucLuong }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ThemChucVuAsync(ChucVu chucVu)
        {
            string query = "EXEC sp_ThemChucVu @TenCV, @MucLuong";
            var parameters = new Dictionary<string, object>
            {
                { "@TenCV", chucVu.TenCV },
                { "@MucLuong", chucVu.MucLuong }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaChucVuAsync(int maCV)
        {
            string query = "EXEC sp_XoaChucVu @MaCV";
            var parameters = new Dictionary<string, object>
            {
                { "@MaCV", maCV }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
