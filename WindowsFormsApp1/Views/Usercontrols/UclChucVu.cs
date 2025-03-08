using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BakeryManagementSystem.Views.Usercontrol
{
    public partial class UclChucVu : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private ChucVu qlChucVu = new ChucVu();
        private bool themMoi = false;
        #endregion

        public UclChucVu()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoaGroupBox.Enabled = true;
            themMoi = true;
            setEnable(themMoi);
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra phản hồi từ hộp thoại
            if (result == DialogResult.Yes)
            {
                // Thoát chương trình nếu người dùng chọn "Yes"
                this.Visible = false;
            }
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            loadDSChucVu();
        }

        public void activited()
        {
            this.Visible = true;
            loadDSChucVu();
            setDataNull();
            setEnable(false);
            btnThem.Enabled = true;
            btnXoaGroupBox.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
        private async void loadDSChucVu()
        {
            gctChucVu.DataSource = null;
            DataTable dt = await Task.Run(() =>
            {
                return qlChucVu.LayDSChucVuAsync();
            });
            gctChucVu.DataSource = dt;
            dgvDanhSachCV.Columns["Mức lương"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            dgvDanhSachCV.Columns["Mức lương"].DisplayFormat.FormatString = "N0";
            dgvDanhSachCV.RefreshData();
            dgvDanhSachCV.ClearSelection();
            dgvDanhSachCV.FocusedRowHandle = -1;
        }

        private void dgvDanhSachCV_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            try
            {
                themMoi = false;
                txtTenChucVu.Text = dgvDanhSachCV.GetRowCellValue(e.RowHandle, "Tên chức vụ").ToString();
                txtMucLuong.Text = dgvDanhSachCV.GetRowCellValue(e.RowHandle, "Mức lương").ToString();
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnXoaGroupBox.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void setEnable(bool val)
        {
            gbxChucVu.Enabled = val;
        }

        #region Ràng buộc Mức lương
        private void txtMucLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra xem có phải là số hoặc dấu chấm
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự khác
            }

            // Kiểm tra xem số ký tự hiện tại có vượt quá 100 hay không
            if (txtMucLuong.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập thêm ký tự
            }

            // Kiểm tra nếu đã có dấu chấm rồi thì không cho nhập dấu chấm nữa
            if (e.KeyChar == '.' && txtMucLuong.Text.Contains("."))
            {
                e.Handled = true; // Ngăn không cho nhập dấu chấm nếu đã có
            }
        }

        private void txtMucLuong_KeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn chặn hành động sao chép (Ctrl + C), dán (Ctrl + V), và cắt (Ctrl + X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void btnSua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
            btnSua.Enabled = false;
            btnXoaGroupBox.Enabled = true;
        }

        private bool checkNull()
        {
            if (string.IsNullOrEmpty(txtMucLuong.Text) ||
                string.IsNullOrEmpty(txtTenChucVu.Text))
            {
                return true;
            }
            return false;

        }
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNull())
                {
                    MessageBox.Show("Dữ liệu không được bỏ trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (themMoi)
                {
                    ChucVu chucVu = new ChucVu()
                    {
                        TenCV = txtTenChucVu.Text,
                        MucLuong = float.Parse(txtMucLuong.Text)
                    };
                    await chucVu.ThemChucVuAsync(chucVu);
                    themMoi = false;
                }
                else
                {
                    ChucVu chucVu = new ChucVu()
                    {
                        MaCV = int.Parse(dgvDanhSachCV.GetRowCellValue(dgvDanhSachCV.FocusedRowHandle, "Mã chức vụ").ToString()),
                        TenCV = txtTenChucVu.Text,
                        MucLuong = float.Parse(txtMucLuong.Text)
                    };
                    await chucVu.CapNhatCVAsync(chucVu);
                }
                loadDSChucVu();
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                setEnable(false);
                setDataNull();
                btnXoaGroupBox.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tên chức vụ không chứa kí tự đặc biệt !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void setDataNull()
        {
            txtMucLuong.Text = "";
            txtTenChucVu.Text = "";
            dgvDanhSachCV.ClearSelection();
            dgvDanhSachCV.FocusedRowHandle = -1;
        }

        private void btnXoaGroupBox_Click(object sender, EventArgs e)
        {
            setDataNull();
            setEnable(false);
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            themMoi = false;
            btnXoaGroupBox.Enabled = false;
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa chức vụ này không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlChucVu.XoaChucVuAsync(int.Parse(dgvDanhSachCV.GetRowCellValue(dgvDanhSachCV.FocusedRowHandle, "Mã chức vụ").ToString()));
                MessageBox.Show("Đã xóa !", "Tành công", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                loadDSChucVu();
                setDataNull();
                setEnable(false);
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                themMoi = false;
                btnXoaGroupBox.Enabled = false;
            }
        }

        #region Ràng buộc tên CV
        private void txtTenChucVu_KeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn chặn hành động sao chép (Ctrl + C), dán (Ctrl + V), và cắt (Ctrl + X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtTenChucVu_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu độ dài vượt quá 50 ký tự
            if (txtTenChucVu.Text.Length >= 50 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Tên chức vụ không được vượt quá 50 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
        #endregion
    }
}
