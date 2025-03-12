using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class KhachHang
    {
        public int MaKH { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public bool GioiTinh { get; set; }
        public int LoaiKH { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> TimKhachHangAsync(int maKH)
        {
            string query = "EXEC sp_LayKH @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task<DataTable> LayDSKhachHangAsync()
        {
            string query = "EXEC sp_LayDSKhachHang";
            return await data.GetDataAsync(query, null);
        }

        public async Task ThemKhachHangAsync(KhachHang khachHang)
        {
            string query = "EXEC sp_ThemKhachHang @Ho, @Ten, @NgaySinh, @DiaChi, @SoDienThoai, @GioiTinh, @LoaiKH";
            var parameters = new Dictionary<string, object>
            {
                { "@Ho", khachHang.Ho },
                { "@Ten", khachHang.Ten },
                { "@NgaySinh", khachHang.NgaySinh?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value },
                { "@DiaChi", khachHang.DiaChi ?? (object)DBNull.Value },
                { "@SoDienThoai", khachHang.SoDienThoai ?? (object)DBNull.Value },
                { "@GioiTinh", khachHang.GioiTinh ? 1 : 0 },
                { "@LoaiKH", khachHang.LoaiKH }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task CapNhatKhachHangAsync(KhachHang khachHang)
        {
            string query = "EXEC sp_CapNhatKhachHang @MaKH, @Ho, @Ten, @NgaySinh, @DiaChi, @SoDienThoai, @GioiTinh, @LoaiKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", khachHang.MaKH },
                { "@Ho", khachHang.Ho },
                { "@Ten", khachHang.Ten },
                { "@NgaySinh", khachHang.NgaySinh?.ToString("yyyy-MM-dd") ?? (object)DBNull.Value },
                { "@DiaChi", khachHang.DiaChi ?? (object)DBNull.Value },
                { "@SoDienThoai", khachHang.SoDienThoai ?? (object)DBNull.Value },
                { "@GioiTinh", khachHang.GioiTinh ? 1 : 0 },
                { "@LoaiKH", khachHang.LoaiKH }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaKhachHangAsync(int maKH)
        {
            string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
            var parameters = new Dictionary<string, object>
            {
                { "@MaKH", maKH }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
