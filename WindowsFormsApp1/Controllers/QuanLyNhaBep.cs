using BakeryManagementSystem.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyNhaBep
    {
        private NhaBep _nhaBep = new NhaBep();

        // Thêm món vào bếp
        public async Task ThemVaoBepAsync(int maHD, int maHH, int soLuongNau)
        {
            await _nhaBep.ThemVaoBepAsync(maHD, maHH, soLuongNau);
        }

        // Lấy danh sách đơn bếp
        public async Task<DataTable> LayDSDonBepAsync()
        {
            return await _nhaBep.LayDSDonBepAsync();
        }

        // Cập nhật trạng thái đơn bếp
        public async Task CapNhatDonBepAsync(int maHD, int maHH, int trangThai)
        {
            await _nhaBep.CapNhatDonBepAsync(maHD, maHH, trangThai);
        }

        // Lấy danh sách đơn bếp đã hoàn thành
        public async Task<DataTable> LayDSDonBepDaHoanThanhAsync()
        {
            return await _nhaBep.LayDSDonBepDaHoanThanhAsync();
        }
    }
}