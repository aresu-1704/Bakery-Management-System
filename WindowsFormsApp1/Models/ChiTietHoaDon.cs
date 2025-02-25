using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connection;

namespace BakeryManagementSystem.Models
{
    public class ChiTietHoaDon
    {
        public int MaHH { get; set; }
        public int MaHoaDon { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }

        public int SoLuongSanCo = 0;

        private Connections data = new Connections();

        public ChiTietHoaDon()
        {
        }

        public ChiTietHoaDon(int maHH, int maHoaDon, double giaTien)
        {
            MaHH = maHH;
            MaHoaDon = maHoaDon;
            SoLuong = 0;
            GiaTien = giaTien;
        }

        public async Task ThemCTHDAsync(int maHD, int maHH, int soLuong, float giaTien)
        {
            string query = "sp_ThemVaoHoaDon @MaHD, @MaHH, @SoLuong, @GiaTien";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHD", maHD },
                { "@MaHH", maHH },
                { "@SoLuong", soLuong },
                { "@GiaTien", giaTien }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayChiTietHoaDonAsync(int maHD)
        {
            string query = "sp_LayChiTietHoaDon @MaHD";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHD", maHD }
            };
            return await data.GetDataAsync(query, parameters);
        }
    }
}
