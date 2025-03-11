using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmCapNhatThongTinCaNhan : DevExpress.XtraEditors.XtraForm
    {
        private QuanLyNhanVien quanLyNhanVien = new QuanLyNhanVien();
        private int maNV = -1;
        public event EventHandler refresh;
        public frmCapNhatThongTinCaNhan(int maNV)
        {
            InitializeComponent();
            this.maNV = maNV;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnLuu.Enabled = true;
            btnSua.Enabled = false;
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

        private Image chuyenByteSangAnh(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void checkGioiTinh(bool val)
        {
            ckcNam.Checked = val;
            ckcNu.Checked = !val;
        }

        private async void setData()
        {
            setEnable(false);

            DataTable dt = await Task.Run(() =>
            {
                return quanLyNhanVien.LayNhanVienAsync(maNV.ToString());
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
                dptNgayThue.EditValue = Convert.ToDateTime(dt.Rows[0]["NgayThue"]);
            }
        }


        private void setEnable(bool enable)
        {
            gbxNhanVien.Enabled = enable;
            gbxThongTinCaNhan.Enabled = enable;
            gbxThongTinLienLac.Enabled = enable;
        }

        public void activited()
        {
            setData();
            setEnable(false);
            btnLuu.Enabled = false;
            btnSua.Enabled = true;
            this.Visible = true;
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
                NhanVien nhanVien = new NhanVien()
                {
                    MaNV = maNV,
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
                    MaCV = -1,
                    HinhAnh = ImageToByteArray(picAnh.Image),
                };
                await quanLyNhanVien.CapNhatNVAsync(nhanVien);
                MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnLuu.Enabled = false;
                btnSua.Enabled = true;
                setEnable(false);
                refresh?.Invoke(sender, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thông tin đang chứa những kí tự không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCapNhatThongTinCaNhan_Load(object sender, EventArgs e)
        {
            setData();
            setEnable(false);
            btnSua.Enabled = true;
            btnLuu.Enabled = false;
        }
    }
}