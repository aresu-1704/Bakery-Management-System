using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyDonBep
    {
        private NhaBep _nhaBep = new NhaBep();
        public async Task<DataTable> LayDonBepAsync()
        {
            return await _nhaBep.LayDSDonBepAsync();
        }

        public async Task CapNhatDonBepAsync(int maHD, int maHH, int trangThai)
        {
            await _nhaBep.CapNhatDonBepAsync(maHD, maHH, trangThai);
        }

        public async Task<DataTable> LayDSDonBepDaHoanThanhAsync()
        {
            return await _nhaBep.LayDSDonBepDaHoanThanhAsync();
        }
    }
}
