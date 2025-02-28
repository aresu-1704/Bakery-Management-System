using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class KhoNguyenLieu
    {
        public int MaKe {  get; set; }
        public bool TrangThai { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayDanhSachKeNguyenLieuAsync()
        {
            string query = "EXEC sp_LayDanhSachKeNL";

            return await data.GetDataAsync(query);
        }
        
        public async Task<DataTable> LayDanhSachNguyenLieuAsync(int maKhuVuc)
        {
            string query = "EXEC sp_LayDanhSachNL @MaKhuVuc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhuVuc", maKhuVuc }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task ThemKeAsync()
        {
            string query = "EXEC sp_ThemKe";

            await data.ExecuteQueryAsync(query);
        }

        public async Task DoiTrangThaiAsync(int maKhuVuc)
        {
            string query = "EXEC sp_DoiTrangThaiKe @MaKhuVuc";

            var parameters = new Dictionary<string, object>
            {
                { "@MaKhuVuc", maKhuVuc }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
