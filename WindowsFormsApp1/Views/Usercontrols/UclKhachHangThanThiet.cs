using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;
using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;

namespace BakeryManagementSystem.Views.Usercontrol
{
    public partial class UclKhachHangThanThiet : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLyKhachHang qlKhachHang = new QuanLyKhachHang();
        private bool themMoi = false;
        #endregion

        public UclKhachHangThanThiet()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            gbxKhachHang.Enabled = true;
            gbxThongTinLienLac.Enabled = true;
            gbxThongTinCaNhan.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void checkGioiTinh(bool val)
        {
            ckcNam.Checked = val;
            ckcNu.Checked = !val;
        }

        #region DS Khách hàng
        private async void loadDSKhachHang()
        {
            dgvDanhSachKH.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlKhachHang.LayDSKhachHangAsync();
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvDanhSachKH.Rows.Add();
                int newRowIdx = dgvDanhSachKH.Rows.Count - 1;
                dgvDanhSachKH.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaKH"].ToString();
                dgvDanhSachKH.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["HoVaTen"].ToString();
                dgvDanhSachKH.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoDienThoai"].ToString();
                switch(dt.Rows[i]["Loai"].ToString())
                {
                    case "0":
                        dgvDanhSachKH.Rows[newRowIdx].Cells[3].Value = "Khách vãng lai";
                        break;
                    case "1":
                        dgvDanhSachKH.Rows[newRowIdx].Cells[3].Value = "Khách thân thiết";
                        break;
                    case "2":
                        dgvDanhSachKH.Rows[newRowIdx].Cells[3].Value = "Khách mua sỉ";
                        break;
                }                
                dgvDanhSachKH.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["SoLanMua"].ToString();
            }
        }
        #endregion

        private void UclQLNV_Load(object sender, EventArgs e)
        {
            loadDSKhachHang();
            dgvDanhSachKH.ClearSelection();
            ckcNam.Checked = true;
        }

        private void setEnable(bool enable)
        {
            gbxKhachHang.Enabled = enable;
            gbxThongTinCaNhan.Enabled = enable;
            gbxThongTinLienLac.Enabled = enable;
        }

        #region Kiểm tra dữ liệu rỗng
        private bool CheckNull()
        {
            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtHo.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                cmbLoaiKH.SelectedIndex == 0)
            {
                return false; // Trả về false nếu có trường nào rỗng
            }

            return true; // Trả về true nếu tất cả các trường đều có giá trị
        }
        #endregion

        private async void dgvDanhSachNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                themMoi = false;
                btnLamMoi.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                setEnable(false);

                DataTable dt = await Task.Run(() =>
                {
                    return qlKhachHang.TimKhachHangAsync(dgvDanhSachKH.Rows[e.RowIndex].Cells[0].Value?.ToString());
                });

                if (dt.Rows.Count > 0)
                {
                    txtHo.Text = dt.Rows[0]["Ho"].ToString();
                    txtTen.Text = dt.Rows[0]["Ten"].ToString();
                    txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                    dptNgaySinh.EditValue = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]);
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    if (dt.Rows[0]["GioiTinh"].ToString() == "Nam") checkGioiTinh(true);
                    else checkGioiTinh(false);
                }
            }
            catch(Exception ex)
            {
            }
        }

        private void ckcNam_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcNam.Checked)
                ckcNu.Checked = false;
            else
                ckcNu.Checked = true;
        }

        private void ckcNu_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcNu.Checked)
                ckcNam.Checked = false;
            else
                ckcNam.Checked = true;
        }

        private void setDataNull()
        {
            txtHo.Text = null;
            txtTen.Text = null;
            txtSoDienThoai.Text = null;
            dptNgaySinh.DateTime = Convert.ToDateTime("1/1/2000");
            txtDiaChi.Text = null;
            ckcNam.Checked = true;
            ckcNu.Checked = false;
        }


        #region Ràng buộc số điện thoại
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải là phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            // Kiểm tra nếu độ dài ký tự đã đạt 10 và không phải là phím Backspace
            if (textBox.Text.Length >= 10 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn nhập thêm
            }
        }

        private void txtSoDienThoai_KeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn chặn hành động sao chép (Ctrl + C), dán (Ctrl + V), và cắt (Ctrl + X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V))
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        #region Ràng buộc địa chỉ
        private void txtDiaChi_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 255 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 255 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Địa chỉ không được vượt quá 50 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }
        #endregion

        #region Ràng buộc họ và tên
        private void txtHo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 50 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Họ không vượt quá 50 kí tự  !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }

        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 20 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Tên không được vượt quá 20 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }
        #endregion

        #region Ràng buộc ngày sinh
        public bool checkNgaySinh()
        {
            DateTime selectedDate = dptNgaySinh.DateTime; // Get the date from DateEdit control
            DateTime today = DateTime.Today;
            DateTime minimumDate = today.AddYears(-16); // Calculate the date 16 years ago from today

            // Check if the selected date is before the minimum date (16 years ago)
            return selectedDate <= minimumDate;
        }

        #endregion
       
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (CheckNull() == false)
            {
                MessageBox.Show("Không bỏ trống bất cứ thông tin nào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!checkNgaySinh())
            {
                MessageBox.Show("Chưa đủ 16 tuổi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (themMoi)
                {
                    KhachHang khachHang = new KhachHang()
                    {
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        DiaChi = txtDiaChi.Text,
                        NgaySinh = dptNgaySinh.DateTime,
                        GioiTinh = ckcNam.Checked ? true : false,
                        LoaiKH = cmbLoaiKH.SelectedIndex - 1
                    };
                    await qlKhachHang.ThemKHAsync(khachHang);
                    themMoi = false;
                    MessageBox.Show("Thêm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhachHang khachHang = new KhachHang()
                    {
                        MaKH = int.Parse(dgvDanhSachKH.CurrentRow.Cells[0].Value.ToString()),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        DiaChi = txtDiaChi.Text,
                        NgaySinh = dptNgaySinh.DateTime,
                        GioiTinh = ckcNam.Checked ? true : false,
                        LoaiKH = cmbLoaiKH.SelectedIndex -1
                    };
                    await qlKhachHang.CapNhatKhachHangAsync(khachHang);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                setDataNull();
                loadDSKhachHang();
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông tin đang chứa những kí tự không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnLamMoi.Enabled = true;
            themMoi = true;
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

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDanhSachKH.Rows)
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

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            dgvDanhSachKH.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnXuatExcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Gọi phương thức để lấy danh sách
                DataTable dt = await Task.Run(() =>
                {
                    return qlKhachHang.LayDSKhachHangAsync();
                });

                // Tạo một ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false; // Không hiển thị Excel trong quá trình xuất

                // Tạo một workbook và worksheet mới
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Xuất tiêu đề cột
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dt.Columns[i].ColumnName; // Gán tên cột
                }

                // Xuất dữ liệu
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dt.Rows[i][j]; // Gán giá trị
                    }
                }

                // Lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "Danh sách khách hàng";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xuất file thất bại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Đóng workbook và ứng dụng Excel
                workbook.Close();
                excelApp.Quit();

                // Giải phóng bộ nhớ
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exel không tồn tại trên máy hoặc không có bản quyền", "Microsoft Exel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn xóa nhân viên này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlKhachHang.XoaKHAsync(dgvDanhSachKH.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDSKhachHang();
                setDataNull();
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                dgvDanhSachKH.ClearSelection();
            }
        }

        private void txtTimTheoMa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTheoMa.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDanhSachKH.Rows)
            {
                // Kiểm tra nếu cell[1] chứa văn bản tìm kiếm
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true; // Hiển thị hàng nếu tìm thấy
                }
                else
                {
                    row.Visible = false; // Ẩn hàng nếu không tìm thấy
                }
            }
        }

        public void activited()
        {
            themMoi = false;
            loadDSKhachHang();
            setDataNull();
            setEnable(false);
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            dgvDanhSachKH.ClearSelection();
            this.Visible = true;
        }
    }
}
