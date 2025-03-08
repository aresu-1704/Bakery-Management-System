using BakeryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class QuanLyDiemDanh
    {
        private PhanCong phanCong = new PhanCong();
        private ChamCong chamCong = new ChamCong();

        public async Task<DataTable> LayLichLamHomNay()
        {
            return await phanCong.LayLichLamViecHomNay();
        }

        public async Task DiemDanh(string maNV, string maPC)
        {
            await chamCong.DiemDanhAsync(int.Parse(maNV), int.Parse(maPC));
        }
    }
}
