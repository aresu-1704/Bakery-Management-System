
using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyNguyenLieu
    {
        private readonly NguyenLieu _nguyenLieu = new NguyenLieu();

        public async Task<DataTable> LayNguyenLieuTungCCAsync(string maNCC)
        {
            try
            {
                return await _nguyenLieu.LayNguyenLieuTungCCAsync(maNCC);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy nguyên liệu từ nhà cung cấp: " + ex.Message);
            }
        }

        public async Task ThemNguyenLieuAsync(NguyenLieu nguyenLieu)
        {
            try
            {
                await _nguyenLieu.ThemNguyenLieuAsync(nguyenLieu);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nguyên liệu: " + ex.Message);
            }
        }

        public async Task<DataTable> LayDSNLAsync()
        {
            try
            {
                return await _nguyenLieu.LayDSNLAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách nguyên liệu: " + ex.Message);
            }
        }

        public async Task CapNhatLayNguyenLieuAsync(int maNL, float soLuong)
        {
            try
            {
                await _nguyenLieu.CapNhatLayNguyenLieuAsync(maNL, soLuong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật số lượng nguyên liệu: " + ex.Message);
            }
        }

        public async Task CapNhatViTriNLAsync(int maNL, int maKhuVuc)
        {
            try
            {
                await _nguyenLieu.CapNhatViTriNLAsync(maNL, maKhuVuc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật vị trí nguyên liệu: " + ex.Message);
            }
        }
    }
}
