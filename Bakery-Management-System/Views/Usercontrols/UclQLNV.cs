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
using System.Globalization;
using BakeryManagementSystem.Models;
using BakeryManagementSystem.Controllers;

namespace BakeryManagementSystem.Views.Usercontrol
{
    public partial class UclQLNV : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private QuanLyChucVu qlChucVu = new QuanLyChucVu();
        private bool themMoi = false;
        #endregion

        public UclQLNV()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            cmbChucVu.Enabled = true;
            dptNgayThue.Enabled = true;
            btnXoaChucVu.Enabled = true;
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
        }

        private void checkGioiTinh(bool val)
        {
            ckcNam.Checked = val;
            ckcNu.Checked = !val;
        }

        private Image chuyenByteSangAnh(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }



        private async void loadDSNhanVien(int filter)
        {
            dgvDanhSachNV.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayDSNhanVienAsync();
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            if (filter == 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bool)dt.Rows[i]["TrangThai"] == false)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDanhSachNV.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDanhSachNV.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDanhSachNV.Rows[newRowIdx].Cells[0].Value = chuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }
                        // Gán các giá trị khác
                        dgvDanhSachNV.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaNV"].ToString();
                        dgvDanhSachNV.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["HoVaTen"].ToString();
                        dgvDanhSachNV.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["TenCV"] != DBNull.Value ? dt.Rows[i]["TenCV"].ToString() : "Không có";
                    }
                }
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bool)dt.Rows[i]["TrangThai"] == true)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDanhSachNV.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDanhSachNV.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDanhSachNV.Rows[newRowIdx].Cells[0].Value = chuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }

                        // Gán các giá trị khác
                        dgvDanhSachNV.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaNV"].ToString();
                        dgvDanhSachNV.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["HoVaTen"].ToString();
                        dgvDanhSachNV.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["TenCV"] != DBNull.Value ? dt.Rows[i]["TenCV"].ToString() : "Không có";
                    }
                }
            }
        }

        private void UclQLNV_Load(object sender, EventArgs e)
        {
            loadDSNhanVien(cmbLoc.SelectedIndex);
            loadChucVu();
            dgvDanhSachNV.ClearSelection();
            ckcNam.Checked = true;
            cmbLoc.SelectedIndex = 1;
        }

        private void setEnable(bool enable)
        {
            gbxNhanVien.Enabled = enable;
            gbxThongTinCaNhan.Enabled = enable;
            gbxThongTinLienLac.Enabled = enable;
        }

        private async void loadChucVu()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlChucVu.LayChucVuAsync();
            });

            if (dt.Rows.Count > 0)
            {
                cmbChucVu.DataSource = dt;
                cmbChucVu.ValueMember = "MaCV";
                cmbChucVu.DisplayMember = "TenCV";
                cmbChucVu.Enabled = true;
                cmbChucVu.SelectedIndex = -1;
            }
            else
            {
                cmbChucVu.Enabled = false;
            }
        }


        #region Kiểm tra dữ liệu rỗng
        private bool CheckNull()
        {
            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtHo.Text) ||
                string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text) ||
                string.IsNullOrWhiteSpace(txtCCCD.Text) ||
                string.IsNullOrWhiteSpace(cmbQuocTich.Text) ||
                string.IsNullOrWhiteSpace(txtQueQuan.Text))
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
                setEnable(false);
                DataTable dt = await Task.Run(() =>
                {
                    return qlNhanVien.LayNhanVienAsync(dgvDanhSachNV.Rows[e.RowIndex].Cells[1].Value?.ToString());
                });
                if (dt.Rows.Count > 0)
                {
                    picAnh.Image = dt.Rows[0]["HinhAnh"] != DBNull.Value ? chuyenByteSangAnh(dt.Rows[0]["HinhAnh"] as byte[]) : Properties.Resources._22_223863_no_avatar_png_circle_transparent_png;
                    txtHo.Text = dt.Rows[0]["Ho"].ToString();
                    txtTen.Text = dt.Rows[0]["Ten"].ToString();
                    txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    dptNgaySinh.EditValue = Convert.ToDateTime(dt.Rows[0]["NgaySinh"]);
                    txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
                    if (dt.Rows[0]["GioiTinh"].ToString() == "Nam") checkGioiTinh(true);
                    else checkGioiTinh(false);
                    txtQueQuan.Text = dt.Rows[0]["QueQuan"].ToString();
                    txtCCCD.Text = dt.Rows[0]["CCCD"].ToString();
                    cmbQuocTich.Text = dt.Rows[0]["QuocTich"].ToString();
                    cmbChucVu.SelectedValue = dt.Rows[0]["MaCV"];
                    dptNgayThue.EditValue = Convert.ToDateTime(dt.Rows[0]["NgayThue"]);
                    if ((bool)dt.Rows[0]["TrangThai"] == false)
                    {
                        btnThemLai.Visible = true;
                        btnXoa.Enabled = false;
                        btnSua.Enabled = false;
                    }
                    else
                    {
                        btnXoa.Enabled = true;
                        btnSua.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
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

        private void btnMoAnh_Click(object sender, EventArgs e)
        {
            // Mở hộp thoại để chọn file ảnh
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Title = "Chọn ảnh";

                // Kiểm tra nếu người dùng đã chọn file ảnh
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Gán ảnh được chọn vào PictureBox
                    picAnh.Image = Image.FromFile(openFileDialog.FileName);

                    // Điều chỉnh kích thước ảnh theo PictureBox (tuỳ chọn)
                    picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void setDataNull()
        {
            picAnh.Image = Properties.Resources._22_223863_no_avatar_png_circle_transparent_png;
            txtHo.Text = null;
            txtTen.Text = null;
            txtSoDienThoai.Text = null;
            txtQueQuan.Text = null;
            txtEmail.Text = null;
            txtCCCD.Text = null;
            dptNgaySinh.DateTime = Convert.ToDateTime("1/1/2000");
            dptNgayThue.DateTime = DateTime.Now;
            txtDiaChi.Text = null;
            cmbQuocTich.SelectedIndex = -1;
            ckcNam.Checked = true;
            ckcNu.Checked = false;
            cmbChucVu.SelectedIndex = -1;
            cmbChucVu.Enabled = false;
            dptNgayThue.Enabled = false;
            btnXoaChucVu.Enabled = false;
        }

        public byte[] ImageToByteArray(Image image)
        {
            if (image != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    // Lưu ảnh vào MemoryStream dưới định dạng PNG (hoặc bạn có thể thay đổi format)
                    image.Save(ms, ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            return null;
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

        #region Ràng buộc Email
        private bool checkEmail()
        {
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Định dạng email không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }
            return true;
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            // Kiểm tra nếu độ dài vượt quá 50 ký tự
            if (textBox.Text.Length > 50 && e.KeyChar != (char)Keys.Delete && e.KeyChar != (char)Keys.Back)
            {
                MessageBox.Show("Địa chỉ Email không được vượt quá 50 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
            }
        }
        // Hàm kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
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

        #region Ràng buộc quê quán
        private void txtQueQuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 50 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Quê quán không được vượt quá 50 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }


        #endregion

        #region Ràng buộc Quốc tịch nhập vào
        private void cmbQuocTich_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBoxEdit textBox = sender as ComboBoxEdit;
            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 50 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Quốc tịch không được vượt quá 50 ký tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        #region Ràng buộc ngày thuê và Ngày sinh
        private void dptNgaySinh_EditValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ DateEdit của DevExpress
            DateTime ngaySinh = Convert.ToDateTime(dptNgaySinh.EditValue);
            DateTime ngayThue = Convert.ToDateTime(dptNgayThue.EditValue);

            // Kiểm tra nếu ngày thuê phải hơn ngày sinh ít nhất 18 năm
            if ((ngayThue - ngaySinh).TotalDays / 365 < 18)
            {
                // Hiển thị thông báo lỗi
                XtraMessageBox.Show("Ngày thuê phải lớn hơn ngày sinh ít nhất 18 năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Đặt lại ngày thuê đúng yêu cầu (lớn hơn ngày sinh 18 năm)
                dptNgayThue.EditValue = ngaySinh.AddYears(18);
                dptNgaySinh.Focus();
            }

        }

        private void dptNgayThue_EditValueChanged(object sender, EventArgs e)
        {
            // Lấy giá trị từ DateEdit của DevExpress
            DateTime ngaySinh = Convert.ToDateTime(dptNgaySinh.EditValue);
            DateTime ngayThue = Convert.ToDateTime(dptNgayThue.EditValue);

            // Kiểm tra nếu ngày thuê phải hơn ngày sinh ít nhất 18 năm
            if ((ngayThue - ngaySinh).TotalDays / 365 < 18)
            {
                // Hiển thị thông báo lỗi
                XtraMessageBox.Show("Ngày thuê phải lớn hơn ngày sinh ít nhất 18 năm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Đặt lại ngày thuê đúng yêu cầu (lớn hơn ngày sinh 18 năm)
                dptNgayThue.EditValue = ngaySinh.AddYears(18);
                dptNgayThue.Focus();
            }
        }
        #endregion

        #region Ràng buộc căn cước công dân
        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải là phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            // Kiểm tra nếu độ dài ký tự đã đạt 12 và không phải là phím Backspace
            if (textBox.Text.Length >= 12 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn nhập thêm
            }
        }
        #endregion

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkEmail() == false)
            {
                return;
            }

            if (CheckNull() == false)
            {
                MessageBox.Show("Không bỏ trống bất cứ thông tin nào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (themMoi)
                {
                    // Tạo đối tượng nhân viên mới
                    NhanVien nhanVien = new NhanVien()
                    {
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        Email = txtEmail.Text,
                        DiaChi = txtDiaChi.Text,
                        NgaySinh = dptNgaySinh.DateTime,
                        GioiTinh = ckcNam.Checked,
                        QueQuan = txtQueQuan.Text,
                        CCCD = txtCCCD.Text,
                        QuocTich = cmbQuocTich.Text,
                        NgayThue = dptNgayThue.DateTime,
                        MaCV = cmbChucVu.DataSource != null && cmbChucVu.SelectedIndex != -1 ? int.Parse(cmbChucVu.SelectedValue.ToString()) : -1,
                        HinhAnh = ImageToByteArray(picAnh.Image),
                        TrangThai = true,
                    };
                    await qlNhanVien.ThemNVAsync(nhanVien);
                    themMoi = false;
                    MessageBox.Show("Thêm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NhanVien nhanVien = new NhanVien()
                    {
                        MaNV = int.Parse(dgvDanhSachNV.CurrentRow.Cells[1].Value.ToString()),
                        Ho = txtHo.Text.Trim(),
                        Ten = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        Email = txtEmail.Text,
                        DiaChi = txtDiaChi.Text,
                        NgaySinh = dptNgaySinh.DateTime,
                        GioiTinh = ckcNam.Checked ? true : false,
                        QueQuan = txtQueQuan.Text,
                        CCCD = txtCCCD.Text,
                        QuocTich = cmbQuocTich.Text,
                        NgayThue = dptNgayThue.DateTime,
                        MaCV = cmbChucVu.DataSource != null && cmbChucVu.SelectedIndex != -1 ? int.Parse(cmbChucVu.SelectedValue.ToString()) : -1,
                        HinhAnh = ImageToByteArray(picAnh.Image),
                    };
                    await qlNhanVien.CapNhatNVAsync(nhanVien);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                setDataNull();
                loadDSNhanVien(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                btnLamMoi.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 102)
                {
                    MessageBox.Show("Thông tin đang chứa những kí tự không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (ex.Number == 547)
                {
                    MessageBox.Show("Nhân viên chưa đủ 18 tuổi !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnLamMoi.Enabled = true;
            themMoi = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            cmbChucVu.Enabled = true;
            dptNgayThue.Enabled = true;
            btnXoaChucVu.Enabled = true;
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
            foreach (DataGridViewRow row in dgvDanhSachNV.Rows)
            {
                // Kiểm tra nếu cell[2] chứa văn bản tìm kiếm
                if (row.Cells[2].Value != null &&
                    row.Cells[2].Value.ToString().ToLower().Contains(searchText))
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
            dgvDanhSachNV.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnXuatRaExcel_Click(object sender, EventArgs e)
        {
            try
            {

                // Gọi phương thức để lấy danh sách nhân viên
                DataTable dtNhanVien = await Task.Run(() =>
                {
                    return qlNhanVien.LayDSNhanVienAsync();
                });

                if (dtNhanVien.Columns.Contains("HinhAnh"))
                {
                    dtNhanVien.Columns.Remove("HinhAnh");
                }

                if (dtNhanVien.Columns.Contains("TrangThai"))
                {
                    dtNhanVien.Columns.Remove("TrangThai");
                }


                // Tạo một ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false; // Không hiển thị Excel trong quá trình xuất

                // Tạo một workbook và worksheet mới
                Excel.Workbook workbook = excelApp.Workbooks.Add();
                Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Sheets[1];

                // Xuất tiêu đề cột
                for (int i = 0; i < dtNhanVien.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1] = dtNhanVien.Columns[i].ColumnName; // Gán tên cột
                }

                // Xuất dữ liệu
                for (int i = 0; i < dtNhanVien.Rows.Count; i++)
                {
                    for (int j = 0; j < dtNhanVien.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = dtNhanVien.Rows[i][j]; // Gán giá trị
                    }
                }

                // Lưu file Excel
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|All Files|*.*";
                saveFileDialog.Title = "Save an Excel File";
                saveFileDialog.FileName = "Danh sách nhân viên";

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
                await qlNhanVien.XoaNVAsync(int.Parse(dgvDanhSachNV.CurrentRow.Cells[1].Value.ToString()));
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSNhanVien(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                dgvDanhSachNV.ClearSelection();
            }
        }

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSNhanVien(cmbLoc.SelectedIndex);
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            cmbChucVu.Enabled = false;
            dptNgayThue.Enabled = false;
            btnXoaChucVu.Enabled = false;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            dgvDanhSachNV.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnThemLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm lại nhân viên này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlNhanVien.ThemLaiNVAsync(dgvDanhSachNV.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Đã thêm vào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSNhanVien(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                cmbChucVu.Enabled = false;
                dptNgayThue.Enabled = false;
                btnXoaChucVu.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                btnThemLai.Visible = false;
                dgvDanhSachNV.ClearSelection();
            }
        }

        private void txtTimTheoMa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTheoMa.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDanhSachNV.Rows)
            {
                // Kiểm tra nếu cell[1] chứa văn bản tìm kiếm
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

        public void activited()
        {
            themMoi = false;
            loadChucVu();
            loadDSNhanVien(1);
            setDataNull();
            cmbLoc.SelectedIndex = 1;
            setEnable(false);
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThemLai.Visible = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            cmbChucVu.Enabled = false;
            dptNgayThue.Enabled = false;
            btnXoaChucVu.Enabled = false;
            dgvDanhSachNV.ClearSelection();
            this.Visible = true;
        }

        private async void btnImportExcel_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Chọn tệp Excel";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    // Kiểm tra xem tệp có tồn tại không
                    if (!File.Exists(filePath))
                        throw new FileNotFoundException("Tệp Excel không tồn tại.");

                    // Thiết lập để đọc dữ liệu từ tệp Excel
                    using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                    {
                        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        using (var reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            var dataset = reader.AsDataSet();
                            var table = dataset.Tables[0]; // Lấy sheet đầu tiên
                            for (int i = 1; i < table.Rows.Count; i++) // Bắt đầu từ hàng thứ 2 bỏ qua tiêu đề
                            {
                                try
                                {
                                    // Lấy dữ liệu từ các cột và kiểm tra dữ liệu hợp lệ
                                    string ho = table.Rows[i][0].ToString().Trim();
                                    string ten = table.Rows[i][1].ToString().Trim();
                                    string soDienThoai = table.Rows[i][2].ToString();
                                    string email = table.Rows[i][3].ToString();
                                    if (!IsValidEmail(email))
                                    {
                                        MessageBox.Show($"Email không hợp lệ . Hãy kiểm tra lại dữ liệu ở dòng thứ {i} !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        continue;
                                    }
                                    string diaChi = table.Rows[i][4].ToString();

                                    // Kiểm tra ngày hợp lệ cho NgaySinh và NgayThue
                                    string dateString = table.Rows[i][5].ToString().Trim(); // Chuỗi ngày tháng cần phân tích
                                    DateTime ngaySinh;

                                    DateTime.TryParseExact(dateString, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaySinh);

                                    dateString = table.Rows[i][10].ToString().Trim();
                                    DateTime ngayThue;
                                    DateTime.TryParseExact(dateString, "M/d/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngayThue);

                                    // Các trường thông tin khác
                                    bool gioiTinh = table.Rows[i][6].ToString().ToLower() == "nam";
                                    string queQuan = table.Rows[i][7].ToString();
                                    string cccd = table.Rows[i][8].ToString();
                                    string quocTich = table.Rows[i][9].ToString();

                                    // Gán dữ liệu vào đối tượng NhanVien
                                    NhanVien nhanVien = new NhanVien()
                                    {
                                        Ho = ho,
                                        Ten = ten,
                                        SoDienThoai = soDienThoai,
                                        Email = email,
                                        DiaChi = diaChi,
                                        NgaySinh = ngaySinh,
                                        GioiTinh = gioiTinh,
                                        QueQuan = queQuan,
                                        CCCD = cccd,
                                        QuocTich = quocTich,
                                        NgayThue = ngayThue,
                                        MaCV = -1,
                                        TrangThai = true,
                                        HinhAnh = ImageToByteArray(picAnh.Image),
                                    };
                                    await qlNhanVien.ThemNVAsync(nhanVien);
                                }
                                catch (SqlException ex)
                                {
                                    // Kiểm tra mã lỗi để xác định loại lỗi cụ thể
                                    switch (ex.Number)
                                    {
                                        case 2627: // Lỗi cho ràng buộc độc nhất (Unique constraint violation)
                                            MessageBox.Show($"Email hoặc số điện thoại bị trùng . Hãy kiểm tra lại dữ liệu ở dòng thứ {i} !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;

                                        case 8152: // Lỗi cho chiều dài chuỗi quá lớn
                                            MessageBox.Show($"Lỗi: Chiều dài dữ liệu vượt quá giới hạn cho phép. Hãy kiểm tra lại dữ liệu ở dòng thứ {i} !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        case 547:
                                            MessageBox.Show($"Lỗi: Nhân viên không đủ 18 tuổi. Hãy kiểm tra lại dữ liệu ở dòng thứ {i} !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                        default:
                                            MessageBox.Show($"Lỗi không xác định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            loadDSNhanVien(cmbLoc.SelectedIndex);
        }

        private void btnXoaChucVu_Click(object sender, EventArgs e)
        {
            cmbChucVu.SelectedIndex = -1;
        }
    }
}
