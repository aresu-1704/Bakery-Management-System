using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using BakeryManagementSystem.Views.Forms;
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
    public partial class UclNhaBep : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyDonBep qlNhaBep = new QuanLyDonBep();
        public UclNhaBep()
        {
            InitializeComponent();
        }

        #region Load đơn bếp
        private async void loadDonBep()
        {
            dgvDangChoNhan.Rows.Clear();
            dgvDangNau.Rows.Clear();
            dgvDaHoanThanh.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlNhaBep.LayDonBepAsync();
            });
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (int.Parse(dt.Rows[i]["TrangThai"].ToString()) == 0)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDangChoNhan.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDangChoNhan.Rows.Count - 1;
                        // Gán các giá trị khác
                        dgvDangChoNhan.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaHoaDon"].ToString();
                        dgvDangChoNhan.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenHH"].ToString();
                        dgvDangChoNhan.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                        dgvDangChoNhan.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["MaHH"].ToString();
                    }
                    else if (int.Parse(dt.Rows[i]["TrangThai"].ToString()) == 1)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDangNau.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDangNau.Rows.Count - 1;
                        // Gán các giá trị khác
                        dgvDangNau.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaHoaDon"].ToString();
                        dgvDangNau.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenHH"].ToString();
                        dgvDangNau.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                        dgvDangNau.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["MaHH"].ToString();
                    }
                    else if (int.Parse(dt.Rows[i]["TrangThai"].ToString()) == 2)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDaHoanThanh.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDaHoanThanh.Rows.Count - 1;
                        // Gán các giá trị khác
                        dgvDaHoanThanh.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaHoaDon"].ToString();
                        dgvDaHoanThanh.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenHH"].ToString();
                        dgvDaHoanThanh.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                    }
                }
            }
            dgvDangNau.ClearSelection();
            dgvDangChoNhan.ClearSelection();
            if (dgvDangChoNhan.Rows.Count == 0)
            {
                btnNhanTatCa.Enabled = false;
            }
            else
            {
                btnNhanTatCa.Enabled = true;
            }
            if (dgvDangNau.Rows.Count == 0)
            {
                btnHoanThanhTatCa.Enabled = false;
            }
            else
            {
                btnHoanThanhTatCa.Enabled = true;
            }
        }
        #endregion

        public void activited()
        {
            loadDonBep();
            this.Visible = true;
        }

        private void dgvNguyenLieuCoTheSD_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dgvDangChoNhan.Cursor = Cursors.Hand; // Đổi con trỏ thành hình bàn tay
            }
            else
            {
                dgvDangChoNhan.Cursor = Cursors.Default; // Trở về con trỏ mặc định
            }
        }

        private void dgvDangNau_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                dgvDangNau.Cursor = Cursors.Hand; // Đổi con trỏ thành hình bàn tay
            }
            else
            {
                dgvDangNau.Cursor = Cursors.Default; // Trở về con trỏ mặc định
            }
        }

        //Nhận đơn
        private async void dgvDangChoNhan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDangChoNhan.Rows[e.RowIndex].Cells[0].Value?.ToString()),
                        int.Parse(dgvDangChoNhan.Rows[e.RowIndex].Cells[4].Value?.ToString()), 1);
                    loadDonBep();
                    MessageBox.Show("Đã nhận !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

        //Hoàn thành
        private async void dgvDangNau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDangNau.Rows[e.RowIndex].Cells[0].Value?.ToString()),
                        int.Parse(dgvDangNau.Rows[e.RowIndex].Cells[4].Value?.ToString()), 2);
                    loadDonBep();
                    MessageBox.Show("Đã hoàn thành !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private async void btnNhanTatCa_Click(object sender, EventArgs e)
        {
            for (int i = dgvDangChoNhan.Rows.Count - 1; i >= 0; i--)
            {
                await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDangChoNhan.Rows[i].Cells[0].Value?.ToString()),
                        int.Parse(dgvDangChoNhan.Rows[i].Cells[4].Value?.ToString()), 1);
            }
            loadDonBep();
            btnNhanTatCa.Enabled = false;
            btnHoanThanhTatCa.Enabled = true;
            MessageBox.Show("Đã nhận tất cả !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnHoanThanhTatCa_Click(object sender, EventArgs e)
        {
            for (int i = dgvDangNau.Rows.Count - 1; i >= 0; i--)
            {
                await qlNhaBep.CapNhatDonBepAsync(int.Parse(dgvDangNau.Rows[i].Cells[0].Value?.ToString()),
                        int.Parse(dgvDangNau.Rows[i].Cells[4].Value?.ToString()), 2);
            }
            loadDonBep();
            btnHoanThanhTatCa.Enabled = false;
            MessageBox.Show("Đã hoàn thành tất cả !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
