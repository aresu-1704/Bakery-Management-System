using BakeryManagementSystem.Models;
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

namespace BakeryManagementSystem.Views.Usercontrol
{
    public partial class UclNhaCungCap : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private NhaCungCap nhaCungCap = new NhaCungCap();
        private NguyenLieu nguyenLieu = new NguyenLieu();
        private bool themMoi = false;
        #endregion

        public UclNhaCungCap()
        {
            InitializeComponent();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
        }

        private Image chuyenByteSangAnh(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        #region Load nhà cung cấp
        private async void loadDSNhaCungCap(int filter)
        {

            dgvDanhSachNCC.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return nhaCungCap.LayDSNCCAsync();
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
                        dgvDanhSachNCC.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDanhSachNCC.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDanhSachNCC.Rows[newRowIdx].Cells[0].Value = chuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }
                        // Gán các giá trị khác
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaNCC"].ToString();
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["TenNCC"].ToString();
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SoLanCungCap"].ToString();
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
                        dgvDanhSachNCC.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDanhSachNCC.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDanhSachNCC.Rows[newRowIdx].Cells[0].Value = chuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }

                        // Gán các giá trị khác
                        // Gán các giá trị khác
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaNCC"].ToString();
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["TenNCC"].ToString();
                        dgvDanhSachNCC.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SoLanCungCap"].ToString();
                    }
                }
            }
        }
        #endregion

        private void UclQLNV_Load(object sender, EventArgs e)
        {
            loadDSNhaCungCap(cmbLoc.SelectedIndex);
            dgvDanhSachNCC.ClearSelection();
            cmbLoc.SelectedIndex = 1;
        }

        private void setEnable(bool enable)
        {
            gbxNhanVien.Enabled = enable;
            gbxNLCC.Enabled = enable;
            gbxThongTinLienLac.Enabled = enable;
        }


        private async void loadNguyenLieu(string maNCC)
        {
            gctNguyenLieu.DataSource = null;
            DataTable dt = await Task.Run(() =>
            {
                return nguyenLieu.LayNguyenLieuTungCCAsync(maNCC);
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            gctNguyenLieu.DataSource = dt;
            dgvNguyenLieu.Columns["MaNL"].Caption = "Mã nguyên liệu";
            dgvNguyenLieu.Columns["TenNL"].Caption = "Tên nguyên liệu";
            dgvNguyenLieu.Columns["ThoiGian"].Caption = "Thời gian nhập";
            dgvNguyenLieu.Columns["ThoiGian"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dgvNguyenLieu.Columns["ThoiGian"].DisplayFormat.FormatString = "dd/MM/yyyy";
        }

        #region Kiểm tra dữ liệu rỗng
        private bool CheckNull()
        {
            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtSoDienThoai.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                return false; // Trả về false nếu có trường nào rỗng
            }

            return true; // Trả về true nếu tất cả các trường đều có giá trị
        }
        #endregion

        private async void dgvDanhSachNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            loadNguyenLieu (dgvDanhSachNCC.Rows[e.RowIndex].Cells[1].Value?.ToString());
            themMoi = false;
            btnLamMoi.Enabled = true;
            btnThem.Enabled = false;
            setEnable(false);
            gbxNLCC.Enabled = true;

            DataTable dt = await Task.Run(() =>
            {

                return nhaCungCap.LayNCCAsync(dgvDanhSachNCC.Rows[e.RowIndex].Cells[1].Value?.ToString());
            });
            if (dt.Rows.Count > 0)
            {
                picAnh.Image = dt.Rows[0]["HinhAnh"] != DBNull.Value ? chuyenByteSangAnh(dt.Rows[0]["HinhAnh"] as byte[]) : Properties.Resources._22_223863_no_avatar_png_circle_transparent_png;
                txtTen.Text = dt.Rows[0]["TenNCC"].ToString();
                txtSoDienThoai.Text = dt.Rows[0]["SoDienThoai"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
                txtDiaChi.Text = dt.Rows[0]["DiaChi"].ToString();
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
            txtTen.Text = null;
            txtSoDienThoai.Text = null;
            txtEmail.Text = null;
            txtDiaChi.Text = null;
            gctNguyenLieu.DataSource = null;
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
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
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
                MessageBox.Show("Email không được vượt quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }
        #endregion

        #region Ràng buộc Tên
        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 50 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Tên nhà cung cấp không được vượt quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
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
                    NhaCungCap nhaCungCap = new NhaCungCap()
                    {
                        TenNCC = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        Email = txtEmail.Text,
                        DiaChi = txtDiaChi.Text,
                        HinhAnh = ImageToByteArray(picAnh.Image),
                        TrangThai = true,
                    };
                    await nhaCungCap.ThemNhaCCAsync(nhaCungCap);
                    themMoi = false;
                    MessageBox.Show("Thêm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    NhaCungCap nhaCungCap = new NhaCungCap()
                    {
                        MaNCC = int.Parse(dgvDanhSachNCC.CurrentRow.Cells[1].Value.ToString()),
                        TenNCC = txtTen.Text.Trim(),
                        SoDienThoai = txtSoDienThoai.Text,
                        Email = txtEmail.Text,
                        DiaChi = txtDiaChi.Text,
                        HinhAnh = ImageToByteArray(picAnh.Image),
                    };
                    await nhaCungCap.CapNhatNCCAsync(nhaCungCap);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                setDataNull();
                loadDSNhaCungCap(cmbLoc.SelectedIndex);
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
                MessageBox.Show(ex.Message);
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
            foreach (DataGridViewRow row in dgvDanhSachNCC.Rows)
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
            dgvDanhSachNCC.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn ngừng hoạt động nhà cung cấp này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await nhaCungCap.XoaNhaCCAsync(dgvDanhSachNCC.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSNhaCungCap(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                dgvDanhSachNCC.ClearSelection();
            }
        }

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSNhaCungCap(cmbLoc.SelectedIndex);
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            dgvDanhSachNCC.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnThemLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thêm lại nhà cung cấp này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await nhaCungCap.ThemLaiNCCAsync(dgvDanhSachNCC.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Đã thêm vào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSNhaCungCap(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                btnThemLai.Visible = false;
                dgvDanhSachNCC.ClearSelection();
            }
        }

        private void txtTimTheoMa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTheoMa.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDanhSachNCC.Rows)
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
            loadDSNhaCungCap(1);
            setDataNull();
            cmbLoc.SelectedIndex = 1;
            setEnable(false);
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThemLai.Visible = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            dgvDanhSachNCC.ClearSelection();
            this.Visible = true;
        }

        private async void btnXuatRaExcel_Click(object sender, EventArgs e)
        {
            try
            {

                // Gọi phương thức để lấy danh sách

                DataTable dt = await Task.Run(() =>
                {
                    return nhaCungCap.LayDSNCCAsync();
                });

                if (dt.Columns.Contains("HinhAnh"))
                {
                    dt.Columns.Remove("HinhAnh");
                }

                if (dt.Columns.Contains("TrangThai"))
                {
                    dt.Columns.Remove("TrangThai");
                }

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
                saveFileDialog.Title = "Danh sách nhà cung cấp";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Xuất file thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Xuất file thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
