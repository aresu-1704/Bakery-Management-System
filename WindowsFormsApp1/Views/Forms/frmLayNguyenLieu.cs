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

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmLayNguyenLieu : DevExpress.XtraEditors.XtraForm
    {
        private NguyenLieu qlNguyenLieu = new NguyenLieu();
        public frmLayNguyenLieu()
        {
            InitializeComponent();
        }

        private async void frmLayNguyenLieu_Load(object sender, EventArgs e)
        {
            loadNLCoTheSD();
        }

        #region Load nguyên liệu
        private async void loadNLCoTheSD()
        {
            dgvDSNguyenLieu.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlNguyenLieu.LayDSNLAsync();
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["TrangThai"] == true)
                {
                    // Thêm một hàng mới vào DataGridView
                    dgvDSNguyenLieu.Rows.Add();

                    // Lấy chỉ số hàng vừa được thêm vào DataGridView
                    int newRowIdx = dgvDSNguyenLieu.Rows.Count - 1;
                    // Gán các giá trị khác
                    dgvDSNguyenLieu.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaNL"].ToString();
                    dgvDSNguyenLieu.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenNL"].ToString();
                    dgvDSNguyenLieu.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvDSNguyenLieu.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["DonViTinh"].ToString();
                }
            }
        }
        #endregion

        private void dgvDSNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblDonViTinh.Text = dgvDSNguyenLieu.Rows[e.RowIndex].Cells[3].Value.ToString();
                lblMaNL.Text = dgvDSNguyenLieu.Rows[e.RowIndex].Cells[0].Value.ToString();
                lblTenNL.Text = dgvDSNguyenLieu.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtSoLuong.Enabled = true;
                btnXacNhan.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        #region Ràng buộc tìm kiếm
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem ký tự nhập vào có phải là số không
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không phải là số
            }

            // Kiểm tra độ dài tối đa là 9 ký tự
            if (txtSoLuong.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập thêm nếu quá 9 ký tự
            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            // Chặn thao tác dán (Ctrl + V)
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDSNguyenLieu.Rows)
            {
                if (row.Cells[1].Value != null &&
                    row.Cells[1].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true; // Hiển thị hàng nếu tìm thấy
                }
                else
                {
                    row.Visible = false; // Ẩn hàng nếu không tìm thấy
                }
            }
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                await qlNguyenLieu.CapNhatLayNguyenLieuAsync(int.Parse(lblMaNL.Text), float.Parse(txtSoLuong.Text)); //layNguyenLieu
                MessageBox.Show("Đã cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnXacNhan.Enabled = false;
                txtSoLuong.Enabled = false;
                lblMaNL.Text = null;
                lblDonViTinh.Text = null;
                lblTenNL.Text = null;
                txtSoLuong.Text = null;
                dgvDSNguyenLieu.ClearSelection();
                loadNLCoTheSD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số lượng lấy nhiều hơn trong kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
    }
}