using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclTinhTrangBep : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyTinhTrangBep qlNhaBep = new QuanLyTinhTrangBep();

        public UclTinhTrangBep()
        {
            InitializeComponent();
        }

        #region Load đơn bếp
        private async void loadDonBep()
        {
            dgvDaHoanThanh.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlNhaBep.LayDSDonBepDaHoanThanhAsync();
            });
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // Thêm một hàng mới vào DataGridView
                    dgvDaHoanThanh.Rows.Add();

                    // Lấy chỉ số hàng vừa được thêm vào DataGridView
                    int newRowIdx = dgvDaHoanThanh.Rows.Count - 1;
                    // Gán các giá trị khác
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaHoaDon"].ToString();
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenHH"].ToString();
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["MaBan"].ToString();
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[4].Value = (bool)dt.Rows[i]["LoaiHoaDon"] == true ? "Tại chỗ" : "Mang đi";
                    dgvDaHoanThanh.Rows[newRowIdx].Cells[6].Value = dt.Rows[i]["MaHH"].ToString();
                }
                btnPhucVuTatCa.Enabled = true;
            }
            else
            {
                btnPhucVuTatCa.Enabled = false;
            }
        }
        #endregion

        private void UclTinhTrangBep_Load(object sender, EventArgs e)
        {
            loadDonBep();
        }

        private async void dgvDaHoanThanh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5)
                {
                    await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDaHoanThanh.Rows[e.RowIndex].Cells[0].Value?.ToString()),
                            int.Parse(dgvDaHoanThanh.Rows[e.RowIndex].Cells[6].Value?.ToString()), 3);
                    loadDonBep();
                    MessageBox.Show("Đã phục vụ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void dgvDaHoanThanh_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dgvDaHoanThanh.Cursor = Cursors.Hand; // Đổi con trỏ thành hình bàn tay
            }
            else
            {
                dgvDaHoanThanh.Cursor = Cursors.Default; // Trở về con trỏ mặc định
            }
        }

        private async void btnPhucVuTatCa_Click(object sender, EventArgs e)
        {
            for (int i = dgvDaHoanThanh.Rows.Count - 1; i >= 0; i--)
            {
                await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDaHoanThanh.Rows[i].Cells[0].Value?.ToString()),
                        int.Parse(dgvDaHoanThanh.Rows[i].Cells[6].Value?.ToString()), 3);
            }
            loadDonBep();
            btnPhucVuTatCa.Enabled = false;
            MessageBox.Show("Đã phục vụ tất cả !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void activited()
        {
            loadDonBep();
            this.Visible = true;
        }
    }
}
