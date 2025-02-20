using Connection;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace BakeryManagementSystem.Models
{
    public partial class NhanVien
    {
        private readonly Connections data = new Connections("UserNhanVien", "12345678An!");

        public int MaNV { get; set; }
        public string TenDangNhap { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime? NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string QuocTich { get; set; }
        public string QueQuan { get; set; }
        public DateTime NgayThue { get; set; }
        public bool TrangThai { get; set; }
        public int? MaCV { get; set; }
        public string CCCD { get; set; }
        public byte[] HinhAnh { get; set; }


        public async Task<DataTable> LayNhanVienAsync(int maNV)
        {
            string query = "EXEC sp_LayNhanVien @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task<DataTable> LayDSMucLuongNVAsync()
        {
            string query = "EXEC sp_LayDSMucLuongNV";
            return await data.GetDataAsync(query);
        }

        public async Task<DataTable> LayDSNhanVienAsync()
        {
            string query = "EXEC sp_LayDanhSachNV";
            return await data.GetDataAsync(query);
        }

        public async Task ThemNhanVienAsync(NhanVien nhanVien)
        {
            try
            {
                string query = "EXEC sp_ThemNhanVien @Ho, @Ten, @SoDienThoai, @Email, @DiaChi, @NgaySinh, @GioiTinh, @QueQuan, @CCCD, @QuocTich, @NgayThue, @MaCV, @HinhAnh";

                var parameters = new Dictionary<string, object>
                {
                    { "@Ho", nhanVien.Ho },
                    { "@Ten", nhanVien.Ten },
                    { "@SoDienThoai", nhanVien.SoDienThoai },
                    { "@Email", nhanVien.Email },
                    { "@DiaChi", nhanVien.DiaChi },
                    { "@NgaySinh", nhanVien.NgaySinh?.ToString("yyyy-MM-dd") },
                    { "@GioiTinh", nhanVien.GioiTinh },
                    { "@QueQuan", nhanVien.QueQuan },
                    { "@CCCD", nhanVien.CCCD },
                    { "@QuocTich", nhanVien.QuocTich },
                    { "@NgayThue", nhanVien.NgayThue.ToString("yyyy-MM-dd") },
                    { "@MaCV", nhanVien.MaCV },
                    { "@HinhAnh", nhanVien.HinhAnh }
                };

                await data.ExecuteQueryAsync(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public async Task CapNhatNhanVienAsync(NhanVien nhanVien)
        {
            string query = "EXEC sp_CapNhatNhanVien @MaNV, @Ho, @Ten, @SoDienThoai, @Email, @DiaChi, @NgaySinh, @GioiTinh, @QueQuan, @CCCD, @QuocTich, @NgayThue, @MaCV, @HinhAnh";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", nhanVien.MaNV },
                { "@Ho", nhanVien.Ho },
                { "@Ten", nhanVien.Ten },
                { "@SoDienThoai", nhanVien.SoDienThoai },
                { "@Email", nhanVien.Email },
                { "@DiaChi", nhanVien.DiaChi },
                { "@NgaySinh", nhanVien.NgaySinh?.ToString("yyyy-MM-dd") },
                { "@GioiTinh", nhanVien.GioiTinh },
                { "@QueQuan", nhanVien.QueQuan },
                { "@CCCD", nhanVien.CCCD },
                { "@QuocTich", nhanVien.QuocTich },
                { "@NgayThue", nhanVien.NgayThue.ToString("yyyy-MM-dd") },
                { "@MaCV", nhanVien.MaCV },
                { "@HinhAnh", nhanVien.HinhAnh }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task XoaNhanVienAsync(int maNV)
        {
            string query = "EXEC sp_XoaNhanVien @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }

        public async Task ThemLaiNhanVienAsync(int maNV)
        {
            string query = "UPDATE NhanVien SET TrangThai = 1 WHERE MaNV = @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}

