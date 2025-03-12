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
    public partial class UclPhanCong : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private QuanLyChucVu qlChucVu = new QuanLyChucVu();
        private QuanLyPhanCong qlPhanCong = new QuanLyPhanCong();
        private bool themMoi = false;
        private string maPC = null;
        #endregion

        public UclPhanCong()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnXoaGroupBox.Enabled = true;
            themMoi = true;
            setEnable(themMoi);
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            gbxLichLam.Enabled = false;
        }

        #region Load lịch làm
        private async void loadLichLam()
        {
            gctLichLam.DataSource = null;
            int maNV = int.Parse(dgvDanhSachNV.GetRowCellValue(dgvDanhSachNV.FocusedRowHandle, "MaNV").ToString());
            DataTable dt = await Task.Run(() =>
            {
                return qlPhanCong.LayDSPhanCongAsync(maNV);
            });

            if (dt.Rows.Count != 0)
            {
                // Chuyển đổi giá trị thời gian sang TimeSpan
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GioVaoCa"] is DateTime gioVao)
                    {
                        row["GioVaoCa"] = gioVao.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                    if (row["GioTanCa"] is DateTime gioTan)
                    {
                        row["GioTanCa"] = gioTan.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                }
                gctLichLam.DataSource = dt;

                // Cấu hình tiêu đề cột
                dgvDSPhanCong.Columns["MaPC"].Caption = "Mã phân công";
                dgvDSPhanCong.Columns["HoVaTen"].Caption = "Tên nhân viên";
                dgvDSPhanCong.Columns["Ngay"].Caption = "Thứ";
                dgvDSPhanCong.Columns["GioVaoCa"].Caption = "Giờ vào ca";
                dgvDSPhanCong.Columns["GioTanCa"].Caption = "Giờ tan ca";
                //Cấu hình cột họ và tên
                dgvDSPhanCong.Columns["HoVaTen"].Width = 250;
                // Cấu hình định dạng hiển thị cho cột Giờ
                dgvDSPhanCong.Columns["GioVaoCa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvDSPhanCong.Columns["GioVaoCa"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị

                dgvDSPhanCong.Columns["GioTanCa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvDSPhanCong.Columns["GioTanCa"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị
            }
            dgvDSPhanCong.ClearSelection();
        }
        #endregion

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
            loadDSNhanVien();
        }

        public void activited()
        {
            this.Visible = true;
            loadDSNhanVien();
            setDataNull();
            setEnable(false);
            btnXoaGroupBox.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        #region Load nhân viên
        private async void loadDSNhanVien()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayDSNhanVienAsync();
            });
            DataView dv = new DataView(dt);
            dv.RowFilter = "TrangThai = true";
            gctNhanVien.DataSource = dv.ToTable();
            dgvDanhSachNV.PopulateColumns();
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in dgvDanhSachNV.Columns)
            {
                if (column.FieldName != "MaNV" && column.FieldName != "HoVaTen" && column.FieldName != "TenCV")
                {
                    column.Visible = false;  // Ẩn các cột không cần thiết
                }
            }
            dgvDanhSachNV.Columns["MaNV"].Caption = "Mã nhân viên";
            dgvDanhSachNV.Columns["HoVaTen"].Caption = "Tên nhân viên";
            dgvDanhSachNV.Columns["TenCV"].Caption = "Chức vụ";
            dgvDanhSachNV.Columns["MaNV"].Width = 130;
            dgvDanhSachNV.Columns["TenCV"].Width = 160;
            dgvDanhSachNV.ClearSelection();
        }
        #endregion

        private void dgvDanhSachCV_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                btnSua.Enabled = false;
                txtTenNV.Text = dgvDanhSachNV.GetRowCellValue(e.RowHandle, "HoVaTen").ToString();
                loadLichLam();
                gbxLichLam.Enabled = true;
                btnThem.Enabled = true;
                btnXoaGroupBox.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private void setEnable(bool val)
        {
            gbxLichLam.Enabled = val;
            gbxPhanCong.Enabled = val;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = true;
            themMoi = false;
            setEnable(true);
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
            cmbNgayLam.Focus();
        }

        private bool checkNgay()
        {
            DateTime time1 = tedGioVaoCa.Time;
            DateTime time2 = tedGioTanCa.Time;
            if (time1 >= time2)
            {
                return false;
            }
            return true;
        }

        private bool checkNull()
        {
            if (string.IsNullOrEmpty(txtTenNV.Text) ||
                string.IsNullOrEmpty(cmbNgayLam.Text))
            {
                return true;
            }
            return false;

        }

        #region Nút lưu
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkNgay() == false)
                {
                    MessageBox.Show("Giờ tan ca vào lớn hơn giờ vào ca !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (checkNull())
                {
                    MessageBox.Show("Dữ liệu không được bỏ trống !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool checkThayDoi = false;
                int ngayPhanCong = cmbNgayLam.SelectedIndex + 1;
                if(ngayPhanCong == 7)
                {
                    ngayPhanCong = 1;
                }
                if (themMoi)
                {
                    PhanCong phanCong = new PhanCong()
                    {
                        MaNV = int.Parse(dgvDanhSachNV.GetRowCellValue(dgvDanhSachNV.FocusedRowHandle, "MaNV").ToString()),
                        Ngay = ngayPhanCong,
                        GioVaoCa = Convert.ToDateTime(tedGioVaoCa.EditValue).TimeOfDay,
                        GioTanCa = Convert.ToDateTime(tedGioTanCa.EditValue).TimeOfDay
                    };
                    checkThayDoi = await qlPhanCong.ThemLichLamAsync(phanCong);
                    if (checkThayDoi)
                    {
                        MessageBox.Show("Đã thêm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    PhanCong phanCong = new PhanCong()
                    {
                        MaPC = int.Parse(maPC),
                        Ngay = ngayPhanCong,
                        GioVaoCa = Convert.ToDateTime(tedGioVaoCa.EditValue).TimeOfDay,
                        GioTanCa = Convert.ToDateTime(tedGioTanCa.EditValue).TimeOfDay
                    };
                    maPC = null;
                    checkThayDoi = await qlPhanCong.CapNhatLichLamAsync(phanCong);
                    if (checkThayDoi)
                    {
                        MessageBox.Show("Đã cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (checkThayDoi)
                {
                    themMoi = false;
                    loadLichLam();
                    btnLuu.Enabled = false;
                    btnThem.Enabled = true;
                    btnXoa.Enabled = false;
                    setEnable(false);
                    gbxLichLam.Enabled = true;
                }
                else
                {
                    cmbNgayLam.Focus();
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        //Đặt dữ liệu và mặc định
        private void setDataNull()
        {
            txtTenNV.Text = "";
            cmbNgayLam.Text = "";
            tedGioTanCa.EditValue = "23:00:00";
            tedGioVaoCa.EditValue = "00:00:00";
            gctLichLam.DataSource = null;
            dgvDSPhanCong.ClearSelection();
            dgvDSPhanCong.FocusedRowHandle = -1;
            themMoi = false;
        }

        private void btnXoaGroupBox_Click(object sender, EventArgs e)
        {
            setDataNull();
            setEnable(false);
            btnLuu.Enabled = false;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            themMoi = false;
            btnXoaGroupBox.Enabled = false;
        }

        private void dgvDSPhanCong_RowClick(object sender, RowClickEventArgs e)
        {
            try
            {
                dgvDSPhanCong.GetRowCellValue(e.RowHandle, "HoVaTen").ToString();
                try
                {
                    cmbNgayLam.SelectedIndex = int.Parse(dgvDSPhanCong.GetRowCellValue(e.RowHandle, "Ngay").ToString()) - 1;
                }
                catch (Exception ex)
                {
                    cmbNgayLam.SelectedIndex = 6;
                }
                maPC = dgvDSPhanCong.GetRowCellValue(e.RowHandle, "MaPC").ToString();
                tedGioVaoCa.EditValue = dgvDSPhanCong.GetRowCellValue(e.RowHandle, "GioVaoCa").ToString();
                tedGioTanCa.EditValue = dgvDSPhanCong.GetRowCellValue(e.RowHandle, "GioTanCa").ToString();
                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
            }
            catch (Exception ex)
            {
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa lịch phân công này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlPhanCong.XoaLichLamAsync(int.Parse(dgvDSPhanCong.GetRowCellValue(dgvDanhSachNV.FocusedRowHandle, "MaPC").ToString()));
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                themMoi = false;
                loadLichLam();
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = false;
                setEnable(false);
                gbxLichLam.Enabled = true;
                setDataNull();
            }
        }
    }
}
