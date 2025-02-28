using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class NguyenLieu
    {
        public int MaNL { get; set; }
        public string TenNL { get; set; }
        public string DonViTinh { get; set; }
        public bool TrangThai { get; set; }
        public float SoLuong { get; set; }
        public int MaNCC { get; set; }
        public float TongTien { get; set; }
        public float SoLuongNhap { get; set; }
        public int MaPhieu { get; set; }
        public DateTime? HSD { get; set; }
        public int MaKhuVuc { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayNguyenLieuTungCCAsync(string maNCC)
        {
            string query = "EXEC sp_LayNguyenLieuTungCC @MaNCC";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNCC", maNCC }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task ThemNguyenLieuAsync(NguyenLieu nguyenLieu)
        {
            string query = "EXEC sp_ThemNguyenLieu @TenNL, @DonViTinh, @TrangThai, @MaNCC, @SoLuong, @HSD , @SoLuongNhap, @MaPhieu, @TongTien";

            DateTime? hanSuDung = DateTime.TryParse(nguyenLieu.HSD?.ToString(), out DateTime start) ? start : (DateTime?)null;

            var parameters = new Dictionary<string, object>
            {
                { "@TenNL", nguyenLieu.TenNL },
                { "@DonViTinh", nguyenLieu.DonViTinh },
                { "@TrangThai", nguyenLieu.TrangThai ? 1 : 0 },
                { "@MaNCC", nguyenLieu.MaNCC },
                { "@HSD", hanSuDung.HasValue ? (object)hanSuDung.Value : DBNull.Value },
                { "@SoLuong", nguyenLieu.SoLuong },
                { "@SoLuongNhap", nguyenLieu.SoLuongNhap },
                { "@TongTien", nguyenLieu.TongTien },
                { "@MaPhieu", nguyenLieu.MaPhieu }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task<DataTable> LayDSNLAsync()
        {
            string query = "EXEC sp_LayDSNguyenLieu";
            return await data.GetDataAsync(query, null);
        }

        public async Task CapNhatLayNguyenLieuAsync(int maNL, float soLuong)
        {
            string query = "EXEC sp_CapNhatLayNguyenLieu @MaNL, @SoLuong";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNL", maNL },
                { "@SoLuong", soLuong }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task CapNhatViTriNLAsync(int maNL, int maKhuVuc)
        {
            string query = "EXEC sp_CapNhatViTriNguyenLieu @MaKhuVuc, @MaNL";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNL", maNL },
                { "@MaKhuVuc", maKhuVuc }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
