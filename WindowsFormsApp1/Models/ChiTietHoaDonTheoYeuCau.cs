using Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class ChiTietHoaDonTheoYeuCau
    {
        public int MaHH { get; set; }
        public int MaHoaDon { get; set; }
        public int SoLuong { get; set; }
        public double GiaTien { get; set; }
        public string YeuCau { get; set; }
        public double PhuThu { get; set; }

        private Connections data = new Connections();

        public ChiTietHoaDonTheoYeuCau()
        {
        }

        public ChiTietHoaDonTheoYeuCau(int maHH, int maHoaDon, double giaTien)
        {
            MaHH = maHH;
            MaHoaDon = maHoaDon;
            SoLuong = 1;
            GiaTien = giaTien;
        }

        public async Task ThemCTHDTheoYeuCauAsync(int maHD, int maHH, int soLuong, float giaTien, string yeuCau, float phuThu)
        {
            string query = "sp_ThemVaoHoaDonTheoYeuCau @MaHD, @MaHH, @SoLuong, @GiaTien, @YeuCau, @PhuThu";
            var parameters = new Dictionary<string, object>
            {
                { "@MaHD", maHD },
                { "@MaHH", maHH },
                { "@SoLuong", soLuong },
                { "@GiaTien", giaTien },
                { "@Yeucau", yeuCau },
                { "@PhuThu", phuThu }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}

