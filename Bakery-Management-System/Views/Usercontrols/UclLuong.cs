using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Views.Forms;
using DevExpress.Data;
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
    public partial class UclLuong : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private QuanLyTienLuong qlTienLuong = new QuanLyTienLuong();
        private float luongNV = 0;
        private string tenNV = null;
        private int maNV = -1;
        #endregion

        public UclLuong()
        {
            InitializeComponent();
        }


        #region Load lịch Chấm công
        private async void LoadLSChamCong()
        {
            gctLichChamCong.DataSource = null;
            string maNV = dgvDanhSachNV.GetRowCellValue(dgvDanhSachNV.FocusedRowHandle, "MaNV").ToString();
            DataTable dt;
            if (ckbTatCa.Checked)
            {
                dt = await Task.Run(() =>
                {
                    return qlTienLuong.LayDSChamCongAsync(maNV, null, null);
                });
            }
            else
            {
                DateTime ngayBatDau = dptNgayBatDau.EditValue != null ? Convert.ToDateTime(dptNgayBatDau.EditValue) : DateTime.MinValue;
                DateTime ngayKetThuc = dptNgayKetThuc.EditValue != null ? Convert.ToDateTime(dptNgayKetThuc.EditValue) : DateTime.MinValue;

                dt = await Task.Run(() =>
                {
                    return qlTienLuong.LayDSChamCongAsync(maNV, ngayBatDau, ngayKetThuc);
                });
            }

            if (dt.Rows.Count != 0)
            {
                // Chuyển đổi giá trị thời gian sang TimeSpan
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Giờ vào"] is DateTime gioVao)
                    {
                        row["Giờ vào"] = gioVao.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                    if (row["Giờ tan"] is DateTime gioTan)
                    {
                        row["Giờ tan"] = gioTan.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                }
                gctLichChamCong.DataSource = dt;
                // Cấu hình định dạng hiển thị cho cột Giờ và Ngày
                dgvLSChamCong.Columns["Giờ vào"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvLSChamCong.Columns["Giờ vào"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị
                dgvLSChamCong.Columns["Giờ tan"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvLSChamCong.Columns["Giờ tan"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị
                dgvLSChamCong.Columns["Ngày"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvLSChamCong.Columns["Ngày"].DisplayFormat.FormatString = "dd/MM/yyyy"; // Định dạng hiển thị
            }
            dgvLSChamCong.ClearSelection();
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
            gctLichChamCong.DataSource = null;
            dptNgayBatDau.Enabled = dptNgayKetThuc.Enabled = false;
        }

        #region Load nhân viên
        private async void loadDSNhanVien()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayDSMucLuongNVAsync();
            });

            gctNhanVien.DataSource = dt;
            dgvDanhSachNV.PopulateColumns();

            dgvDanhSachNV.Columns["MaNV"].Caption = "Mã nhân viên";
            dgvDanhSachNV.Columns["MaNV"].Width = 180;
            dgvDanhSachNV.Columns["TrangThai"].Width = 200;
            dgvDanhSachNV.Columns["HoVaTen"].Caption = "Tên nhân viên";
            dgvDanhSachNV.Columns["TrangThai"].Caption = "Trạng thái hiện tại";
            dgvDanhSachNV.ClearSelection();
        }
        #endregion

        #region Click vào DS Nhân viên
        private void dgvDanhSachCV_RowClick(object sender, RowClickEventArgs e)
        {
            try 
            { 
                tenNV = dgvDanhSachNV.GetRowCellValue(e.RowHandle, "HoVaTen").ToString();
                maNV = int.Parse(dgvDanhSachNV.GetRowCellValue(e.RowHandle, "MaNV").ToString());
                LoadLSChamCong();
                txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
                gbxChamCong.Enabled = true;
                btnXoaGroupBox.Enabled = true;
                setDataNull();
                setEnable(true);
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        private bool checkNgay()
        {
            DateTime time1 = dptNgayBatDau.DateTime;
            DateTime time2 = dptNgayKetThuc.DateTime;
            if (time1 > time2)
            {
                return false;
            }
            return true;
        }

        //Đặt dữ liệu và mặc định
        private void setDataNull()
        {
            ckbTatCa.Checked = true;
            dptNgayKetThuc.EditValue = DateTime.Now;
            dptNgayBatDau.EditValue = "01/01/2024";
            dgvLSChamCong.ClearSelection();
            dgvLSChamCong.FocusedRowHandle = -1;
        }

        private void setEnable(bool enable)
        {
            ckbChuaTra.Enabled = enable;
            ckbTatCa.Enabled = enable;
            gbxChamCong.Enabled = enable;
        }

        private void btnXoaGroupBox_Click(object sender, EventArgs e)
        {
            setDataNull();
            setEnable(false);
            btnXoaGroupBox.Enabled = false;
        }

        private void ckbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTatCa.Checked == true)
            {
                dptNgayBatDau.Enabled = false;
                dptNgayKetThuc.Enabled = false;
                anDaTra();
                txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
                btnTraLuong.Enabled = false;
            }
            else
            {
                dptNgayBatDau.Enabled = true;
                dptNgayKetThuc.Enabled = true;
                loadDSNhanVien();
                txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
                btnTraLuong.Enabled = true;
            }

        }

        private void dptNgayKetThuc_EditValueChanged(object sender, EventArgs e)
        {
            if (checkNgay() == false)
            {
                MessageBox.Show("Ngày sau phải lớn hơn hoặc bằng ngày trước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
            if (ckbTatCa.Checked == true)
            {
                anDaTra();
                txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
            }
        }

        private void dptNgayBatDau_EditValueChanged(object sender, EventArgs e)
        {
            if (checkNgay() == false)
            {
                MessageBox.Show("Ngày sau phải lớn hơn hoặc bằng ngày trước !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
            if (ckbTatCa.Checked == true)
            {
                anDaTra();
                txtTongLuong.Text = qlTienLuong.TinhLuong(dgvLSChamCong).ToString("N0");
            }
        }

        private void btnTraLuong_Click(object sender, EventArgs e)
        {
            if (ckbTatCa.Checked)
            {
                MessageBox.Show("Vui lòng nhập ngày cụ thể !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                frmPhieuLuong phieuLuong = new frmPhieuLuong();
                phieuLuong.setData(tenNV, dptNgayBatDau, dptNgayKetThuc, maNV, qlTienLuong.TinhLuong(dgvLSChamCong));
                phieuLuong.changed += refresh;
                phieuLuong.ShowDialog();
            }
        }

        private void refresh(object sender, EventArgs e)
        {
            LoadLSChamCong();
            setDataNull();
        }

        private void anDaTra()
        {
            // Lặp từ dưới lên trên để tránh vấn đề thay đổi chỉ số khi xóa hàng
            for (int i = dgvLSChamCong.RowCount - 1; i >= 0; i--)
            {
                if (dgvLSChamCong.GetRowCellValue(i, "Tình trạng lương").ToString() != "Chưa trả")
                {
                    dgvLSChamCong.DeleteRow(i);
                }
            }
        }
        private void ckbChuaTra_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbChuaTra.Checked)
            {
                anDaTra();
            }
            else
            {
                LoadLSChamCong();
            }
        }

    }
}