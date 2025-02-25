using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class PhieuNhapHang
    {
        public int MaPhieu { get; set; }
        public DateTime? ThoiGian { get; set; }

        private Connections data = new Connections();

        public async Task ThemPhieuNhapAsync(string maPhieu, int maNV)
        {
            string query = "EXEC sp_ThemPhieuNhap @MaPhieu, @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu },
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayChiTietPNAsync(int maNL)
        {
            string query = "EXEC sp_LayChiTietPhieuNhap @MaNL";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNL", maNL }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task<DataTable> LayTongTienAsync(int maPhieu)
        {
            string query = "EXEC sp_TinhTongTienPhieu @MaPhieu";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPhieu", maPhieu }
            };

            return await data.GetDataAsync(query, parameters);
        }
    }
}
