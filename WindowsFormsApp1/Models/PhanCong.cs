using Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Models
{
    public class PhanCong
    {
        public int MaPC { get; set; }
        public int? MaNV { get; set; }
        public int? Ngay { get; set; }
        public TimeSpan GioVaoCa { get; set; }
        public TimeSpan GioTanCa { get; set; }
        public bool? TrangThai { get; set; }

        private Connections data = new Connections();

        public async Task<DataTable> LayDSPhanCongAsync(int maNV)
        {
            string query = "EXEC sp_LayLichLam @MaNV";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", maNV }
            };

            return await data.GetDataAsync(query, parameters);
        }

        public async Task<bool> ThemLichLamAsync(PhanCong phanCong)
        {
            string query = "EXEC sp_ThemLichLam @MaNV, @Ngay, @GioVaoCa, @GioTanCa";

            var parameters = new Dictionary<string, object>
            {
                { "@MaNV", phanCong.MaNV },
                { "@Ngay", phanCong.Ngay },
                { "@GioVaoCa", phanCong.GioVaoCa },
                { "@GioTanCa", phanCong.GioTanCa }
            };

            try
            {
                await data.ExecuteQueryAsync(query, parameters);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lịch đang bị trùng với lịch phân công đã có!", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task<bool> CapNhatLichLamAsync(PhanCong phanCong)
        {
            string query = "EXEC sp_CapNhatLichLam @MaPC, @Ngay, @GioVaoCa, @GioTanCa";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPC", phanCong.MaPC },
                { "@Ngay", phanCong.Ngay },
                { "@GioVaoCa", phanCong.GioVaoCa },
                { "@GioTanCa", phanCong.GioTanCa }
            };

            try
            {
                await data.ExecuteQueryAsync(query, parameters);
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Lịch đang bị trùng với lịch phân công đã có!", "Trùng lịch", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public async Task XoaLichLamAsync(int maPC)
        {
            string query = "EXEC sp_XoaLichLam @MaPC";

            var parameters = new Dictionary<string, object>
            {
                { "@MaPC", maPC }
            };

            await data.ExecuteQueryAsync(query, parameters);
        }
    }
}
