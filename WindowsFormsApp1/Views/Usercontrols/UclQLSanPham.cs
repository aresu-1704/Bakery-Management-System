using BakeryManagementSystem.Controllers;
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using BakeryManagementSystem.Models;

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclQLSanPham : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLySanPham qlSanPham = new QuanLySanPham();
        private QuanLyKhuyenMai qlKhuyenMai = new QuanLyKhuyenMai();
        private bool themMoi = false;
        #endregion

        public UclQLSanPham()
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

        #region Load danh sách Sản phẩm
        private async void loadDSSanPham(int filter)
        {
            pgpLoading.Visible = true;
            dgvDSSanPham.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlSanPham.LayDSHangHoaAsync();
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
                        dgvDSSanPham.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDSSanPham.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDSSanPham.Rows[newRowIdx].Cells[0].Value = ChuyenAnh.ChuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }
                        // Gán các giá trị khác
                        dgvDSSanPham.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaHH"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["TenHH"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SanCo"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[4].Value = float.Parse(dt.Rows[i]["GiaTien"].ToString()).ToString("N0") + " VNĐ";
                        dgvDSSanPham.Rows[newRowIdx].Cells[5].Value = dt.Rows[i]["ChietKhau"] != DBNull.Value ?
                            dt.Rows[i]["ChietKhau"].ToString() : "0";
                    }
                }
            }
            else if(filter == 1)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if ((bool)dt.Rows[i]["TrangThai"] == true)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvDSSanPham.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvDSSanPham.Rows.Count - 1;

                        // Kiểm tra và gán hình ảnh
                        if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                        {
                            dgvDSSanPham.Rows[newRowIdx].Cells[0].Value = ChuyenAnh.ChuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                        }

                        // Gán các giá trị khác
                        dgvDSSanPham.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaHH"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["TenHH"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SanCo"].ToString();
                        dgvDSSanPham.Rows[newRowIdx].Cells[4].Value = float.Parse(dt.Rows[i]["GiaTien"].ToString()).ToString("N0") + " VNĐ";
                        dgvDSSanPham.Rows[newRowIdx].Cells[5].Value = dt.Rows[i]["ChietKhau"] != DBNull.Value ?
                            dt.Rows[i]["ChietKhau"].ToString() : "0";
                    }
                }
            }
            pgpLoading.Visible = false;
        }
        #endregion

        #region Load khuyến mãi đang có vào Combo Box
        private async void loadKMVaoCMB()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlKhuyenMai.LayThongTinKMAsync();
            });
            if (dt.Rows.Count > 0)
            {
                cmbKhuyenMai.DataSource = dt;
                cmbKhuyenMai.DisplayMember = "Tên khuyến mãi";
                cmbKhuyenMai.ValueMember = "Mã";
                cmbKhuyenMai.SelectedIndex = -1;
            }
        }
        #endregion
        private void UclQLNV_Load(object sender, EventArgs e)
        {
            setDataNull();
            dgvDSSanPham.ClearSelection();
            cmbLoc.SelectedIndex = 1;
        }

        private void setEnable(bool enable)
        {
            gbxNhanVien.Enabled = enable;
            gbxThongTinLienLac.Enabled = enable;
        }

        #region Load DS Khuyến mãi
        private async void loadKM()
        {
            pgpLoading.Visible = true;
            gctNguyenLieu.DataSource = null;
            DataTable dt = await Task.Run(() =>
            {
                return qlKhuyenMai.LayThongTinKMAsync();
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            gctNguyenLieu.DataSource = dt;
            dgvNguyenLieu.Columns["Mã"].Width = 40;
            dgvNguyenLieu.Columns["Chiết khấu"].Width = 50;
            dgvNguyenLieu.Columns["Ngày bắt đầu"].Visible = false;
            dgvNguyenLieu.Columns["Ngày kết thúc"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dgvNguyenLieu.Columns["Ngày kết thúc"].DisplayFormat.FormatString = "dd/MM/yyyy";
            pgpLoading.Visible = false;
        }
        #endregion

        #region Kiểm tra dữ liệu rỗng
        private bool CheckNull()
        {
            // Kiểm tra các trường nhập liệu
            if (string.IsNullOrWhiteSpace(txtTen.Text) ||
                string.IsNullOrWhiteSpace(txtGiaTien.Text) ||
                string.IsNullOrWhiteSpace(txtSanCo.Text))
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
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                setEnable(false);
                gbxNLCC.Enabled = true;
                DataTable dt = await Task.Run(() =>
                {
                    return qlSanPham.LaySanPhamAsync(dgvDSSanPham.Rows[e.RowIndex].Cells[1].Value?.ToString());
                });
                if (dt.Rows.Count > 0)
                {
                    picAnh.Image = dt.Rows[0]["HinhAnh"] != DBNull.Value ? ChuyenAnh.ChuyenByteSangAnh(dt.Rows[0]["HinhAnh"] as byte[]) : Properties.Resources.no_image_icon_6;
                    txtTen.Text = dt.Rows[0]["TenHH"].ToString();
                    txtGiaTien.Text = dt.Rows[0]["GiaTien"].ToString();
                    txtSanCo.Text = dt.Rows[0]["SanCo"].ToString();
                    cmbKhuyenMai.SelectedIndex = cmbKhuyenMai.FindStringExact(dt.Rows[0]["TenKM"].ToString());
                    if ((bool)dt.Rows[0]["TrangThai"] == false)
                    {
                        btnBan.Visible = true;
                        btnXoa.Enabled = false;
                    }
                    else
                    {
                        btnXoa.Enabled = true;
                    }
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
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
            picAnh.Image = Properties.Resources.no_image_icon_6;
            txtTen.Text = null;
            txtGiaTien.Text = null;
            txtSanCo.Text = null;
            cmbKhuyenMai.SelectedIndex = -1;
        }

        #region Ràng buộc giá tiền
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải là phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            // Kiểm tra nếu độ dài ký tự đã đạt 10 và không phải là phím Backspace
            if (textBox.Text.Length >= 9 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
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

        #region Ràng buộc Tên
        private void txtTen_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu độ dài đã đạt 255 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 255 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Tên nhà cung cấp không được vượt quá 50 ký tự.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
            }
        }
        #endregion

        #region Ràng buộc sẵn có
        private void txtSanCo_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Kiểm tra nếu ký tự nhập vào không phải là số và không phải là phím Backspace
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            // Kiểm tra nếu độ dài ký tự đã đạt 10 và không phải là phím Backspace
            if (textBox.Text.Length >= 8 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true; // Ngăn chặn nhập thêm
            }
        }

        private void txtSanCo_KeyDown(object sender, KeyEventArgs e)
        {
            // Ngăn chặn hành động sao chép (Ctrl + C), dán (Ctrl + V), và cắt (Ctrl + X)
            if (e.Control && (e.KeyCode == Keys.C || e.KeyCode == Keys.V || e.KeyCode == Keys.X))
            {
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (CheckNull() == false)
            {
                MessageBox.Show("Không bỏ trống bất cứ thông tin nào !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (themMoi)
                {
                    HangHoa hangHoa = new HangHoa()
                    {
                        TenHH = txtTen.Text.Trim(),
                        GiaTien = float.Parse(txtGiaTien.Text),
                        SanCo = int.Parse(txtSanCo.Text),
                        MaDotKhuyenMai = cmbKhuyenMai.SelectedIndex != -1 ? int.Parse(cmbKhuyenMai.SelectedValue.ToString()) : 0,
                        HinhAnh = ChuyenAnh.ImageToByteArray(picAnh.Image),
                    };
                    await qlSanPham.ThemSPAsync(hangHoa);
                    themMoi = false;
                    MessageBox.Show("Thêm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    HangHoa hangHoa = new HangHoa()
                    {
                        MaHH = int.Parse(dgvDSSanPham.CurrentRow.Cells[1].Value.ToString()),
                        TenHH = txtTen.Text.Trim(),
                        GiaTien = float.Parse(txtGiaTien.Text),
                        SanCo = int.Parse(txtSanCo.Text),
                        MaDotKhuyenMai = cmbKhuyenMai.SelectedIndex != -1 ? int.Parse(cmbKhuyenMai.SelectedValue.ToString()) : 0,
                        HinhAnh = ChuyenAnh.ImageToByteArray(picAnh.Image),
                    };
                    await qlSanPham.CapNhatTTSPAsync(hangHoa);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                setDataNull();
                loadDSSanPham(cmbLoc.SelectedIndex);
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
                MessageBox.Show("Tên sản phẩm chứa kí tự không hợp lệ !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            foreach (DataGridViewRow row in dgvDSSanPham.Rows)
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
            dgvDSSanPham.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnXuatRaExcel_Click(object sender, EventArgs e)
        {
            try
            {
                //Gọi phương thức để lấy danh sách hàng hóa
                DataTable dt = await Task.Run(() =>
                {
                    return qlSanPham.LayDSHangHoaAsync();
                });
                if (dt.Columns.Contains("HinhAnh"))
                {
                    dt.Columns.Remove("HinhAnh");
                }
                // Tạo một ứng dụng Excel mới
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = false; // Không hiển thị Excel trong quá trình xuất

                Excel.Workbook workbook = null;
                Excel.Worksheet worksheet = null;

                try
                {
                    // Tạo một workbook và worksheet mới
                    workbook = excelApp.Workbooks.Add();
                    worksheet = (Excel.Worksheet)workbook.Sheets[1];

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
                    saveFileDialog.FileName = "Danh sách sản phẩm";

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    // Đóng workbook và ứng dụng Excel
                    if (workbook != null)
                    {
                        workbook.Close();
                        Marshal.ReleaseComObject(workbook);
                    }
                    if (worksheet != null)
                    {
                        Marshal.ReleaseComObject(worksheet);
                    }
                    excelApp.Quit();
                    Marshal.ReleaseComObject(excelApp);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Exel không tồn tại trên máy hoặc không có bản quyền", "Microsoft Exel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn ngừng bán sản phẩm này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlSanPham.XoaSPAsync(dgvDSSanPham.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSSanPham(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                dgvDSSanPham.ClearSelection();
            }
        }

        private void cmbLoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDSSanPham(cmbLoc.SelectedIndex);
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnThem.Enabled = true;
            btnLamMoi.Enabled = false;
            dgvDSSanPham.ClearSelection();
            setDataNull();
            setEnable(false);
        }

        private async void btnThemLai_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn bán lại sản phẩm này ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlSanPham.ThemLaiSPAsync(dgvDSSanPham.CurrentRow.Cells[1].Value.ToString());
                MessageBox.Show("Đã bán lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setDataNull();
                loadDSSanPham(cmbLoc.SelectedIndex);
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                btnBan.Visible = false;
                dgvDSSanPham.ClearSelection();
            }
        }

        private void txtTimTheoMa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTheoMa.Text.ToLower(); // Lấy văn bản tìm kiếm và chuyển thành chữ thường
            foreach (DataGridViewRow row in dgvDSSanPham.Rows)
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
            pgpLoading.Visible = true;
            themMoi = false;
            loadKM();
            loadKMVaoCMB();
            setDataNull();            
            setEnable(false);
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnBan.Visible = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            dgvDSSanPham.ClearSelection();
            this.Visible = true;
            pgpLoading.Visible = false;
        }

        private void btnXoaChucVu_Click(object sender, EventArgs e)
        {
            cmbKhuyenMai.SelectedIndex = -1;
        }
    }
}