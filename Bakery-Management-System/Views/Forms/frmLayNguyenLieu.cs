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
        public event EventHandler refresh;
        private NguyenLieu qlNguyenLieu = new NguyenLieu();
        public frmLayNguyenLieu(string maNL, string tenNL)
        {
            InitializeComponent();
            lblMaNL.Text = maNL;
            lblTenNL.Text = tenNL;
        }

        #region Ràng buộc thanh nhập số lượng
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

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                await qlNguyenLieu.CapNhatLayNguyenLieuAsync(int.Parse(lblMaNL.Text), float.Parse(txtSoLuong.Text));
                MessageBox.Show("Đã cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                refresh?.Invoke(this, EventArgs.Empty);

                btnXacNhan.Enabled = false;
                txtSoLuong.Enabled = false;
                lblMaNL.Text = null;
                lblDonViTinh.Text = null;
                lblTenNL.Text = null;
                txtSoLuong.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Số lượng lấy nhiều hơn trong kho !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
    }
}