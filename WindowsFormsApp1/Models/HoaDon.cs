using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public DateTime? ThoiGian { get; set; }
        public bool? LoaiHoaDon { get; set; }
        public int? MaKH { get; set; }
        public int MaNV { get; set; }

        private Connections data = new Connections();

        public async Task TaoHoaDonMoiAsync(int maHD, int maNV, int maBan, int loaiHD, int maKH)
        {
            string query;
            var parameters = new Dictionary<string, object>
            {
                { "@MaHoaDon", maHD },
                { "@MaNV", maNV },
                { "@MaBan", maBan },
                { "@LoaiHoaDon", loaiHD }
            };

            if (maKH != -1)
            {
                parameters.Add("@MaKH", maKH);
                query = "sp_ThemHoaDon @MaHoaDon, @MaNV, @LoaiHoaDon, @MaKH";
            }
            else
            {
                query = "sp_ThemHoaDon @MaHoaDon, @MaNV, @LoaiHoaDon";
            }

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayThongTinHoaDonCuaKHAsync(int maKH)
        {
            string query = "sp_LayThongTinHoaDon @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH }
            };
            return await data.GetDataAsync(query, parameters);
        }
    }
}
