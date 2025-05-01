using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyBanAn
    {
        private Ban ban = new Ban();

        public async Task<DataTable> LayDSBanAsync()
        {
            return await ban.LayDSBanAsync();
        }

        public async Task ThemBanAsync()
        {
            await ban.ThemBanAsync();
        }

        public async Task<DataTable> LayDSToanBoBanAsync()
        {
            return await ban.LayDSToanBoBanAsync();
        }

        public async Task<DataTable> LayTTHoaDonBanAsync(int maBan)
        {
            return await ban.LayTTHoaDonBanAsync(maBan);
        }

        public async Task DonBanAsync(int maBan)
        {
            await ban.DonBanAsync(maBan);
        }

        public async Task CapNhatTinhTrangBanAsync(int maBan, int maHoaDon)
        {
            await ban.CapNhatTinhTrangBanAsync(maHoaDon, maBan);
        }
    }

}
