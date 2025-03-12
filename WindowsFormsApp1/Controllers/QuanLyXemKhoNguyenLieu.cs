using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyXemKhoNguyenLieu
    {
        private readonly NguyenLieu nguyenLieu = new NguyenLieu();

        public async Task<DataTable> LayDanhSachNguyenLieuAsync()
        {
            try
            {
                return await nguyenLieu.LayDSNLAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nguyên liệu: " + ex.Message);
            }
        }

        public async Task<DataTable> LayNguyenLieuTheoNCCAsync(string maNCC)
        {
            try
            {
                return await nguyenLieu.LayNguyenLieuTungCCAsync(maNCC);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy nguyên liệu theo nhà cung cấp: " + ex.Message);
            }
        }
    }
}