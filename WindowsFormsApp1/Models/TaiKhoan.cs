using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Models
{
    public class TaiKhoan
    {
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string Muoi { get; set; }
        public int SoLanDangNhap { get; set; }
        public bool TrangThai { get; set; }

        private static readonly Connections data = new Connections("UserTaiKhoan", "12345678An!");

        public async Task<DataTable> LayTaiKhoanAsync(string tenDangNhap)
        {
            string query = "EXEC sp_LayTaiKhoan @TenDangNhap";

            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", tenDangNhap }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task<DataTable> TimTaiKhoanAsync(string email)
        {
            string query = "EXEC sp_TimEmail @Email";

            var parameters = new Dictionary<string, object>
            {
                { "@Email", email }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task TaoTaiKhoanAsync(string tenDangNhap, byte[] matKhau,byte[] salt, int maNV)
        {
            string query = "EXEC sp_TaoTaiKhoan @TenDangNhap, @MatKhau, @MaNV, @Muoi";

            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", tenDangNhap },
                { "@MatKhau", matKhau },
                { "@Muoi", salt },
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async void DoiMatKhauAsync(string tenDangNhap, byte[] matKhauMoi, byte[] salt)
        {
            string query = "EXEC sp_CapNhatMatKhau @TenDangNhap, @MatKhauMoi, @Muoi";

            var parameters = new Dictionary<string, object>
            {
                { "@TenDangNhap", tenDangNhap },
                { "@MatKhauMoi", matKhauMoi },
                { "@Muoi", salt }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
