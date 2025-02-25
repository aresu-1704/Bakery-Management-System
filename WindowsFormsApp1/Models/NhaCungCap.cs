using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class NhaCungCap
    {
        public int MaNCC { get; set; }
        public string TenNCC { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public bool TrangThai { get; set; }
        public byte[] HinhAnh { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayDSNCCAsync()
        {
            string query = "EXEC sp_LayDanhSachNCC";
            return await data.GetDataAsync(query, null);
        }

        public async Task<DataTable> LayNCCAsync(string maNCC)
        {
            string query = "EXEC sp_LayNCC @MaNCC";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNCC", maNCC }
            };
            return await data.GetDataAsync(query, parameters);
        }

        public async Task ThemNhaCCAsync(NhaCungCap nhaCungCap)
        {
            string query = "EXEC sp_ThemNCC @TenNCC, @DiaChi, @Email, @SoDienThoai, @HinhAnh";
            var parameters = new Dictionary<string, object>
            {
                { "@DiaChi", nhaCungCap.DiaChi },
                { "@Email", nhaCungCap.Email },
                { "@SoDienThoai", nhaCungCap.SoDienThoai },
                { "@TenNCC", nhaCungCap.TenNCC },
                { "@HinhAnh", nhaCungCap.HinhAnh }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task CapNhatNCCAsync(NhaCungCap nhaCungCap)
        {
            string query = "EXEC sp_CapNhatNCC @MaNCC, @TenNCC, @DiaChi, @Email, @SoDienThoai, @HinhAnh";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNCC", nhaCungCap.MaNCC },
                { "@DiaChi", nhaCungCap.DiaChi },
                { "@Email", nhaCungCap.Email },
                { "@SoDienThoai", nhaCungCap.SoDienThoai },
                { "@TenNCC", nhaCungCap.TenNCC },
                { "@HinhAnh", nhaCungCap.HinhAnh }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaNhaCCAsync(string maNCC)
        {
            string query = "EXEC sp_XoaNCC @MaNCC";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNCC", maNCC }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ThemLaiNCCAsync(string maNCC)
        {
            string query = "UPDATE NhaCungCap SET TrangThai = 1 WHERE MaNCC = @MaNCC";
            var parameters = new Dictionary<string, object>
            {
                { "@MaNCC", maNCC }
            };
            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
