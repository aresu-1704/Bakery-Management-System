using BakeryManagementSystem.Controllers;
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

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclKhuyenMai : DevExpress.XtraEditors.XtraUserControl
    {
        #region Thuộc tính
        private QuanLyKhuyenMai qlKhuyenMai = new QuanLyKhuyenMai();
        private QuanLySanPham qlSanPham = new QuanLySanPham();
        private bool themMoi = false;
        #endregion

        public UclKhuyenMai()
        {
            InitializeComponent();
        }

        private Image chuyenByteSangAnh(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            setEnable(true);
            btnSua.Enabled = false;
            btnLuu.Enabled = true;
            btnThoat.Enabled = true;
        }

        private async void loadDSKhuyenMai()
        {
            dgvDSKhuyenMai.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlKhuyenMai.LayThongTinKMAsync();
            });
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvDSKhuyenMai.Rows.Add();
                    int newRowIndex = dgvDSKhuyenMai.Rows.Count - 1;
                    dgvDSKhuyenMai.Rows[newRowIndex].Cells[0].Value = dt.Rows[i]["Mã"].ToString();
                    dgvDSKhuyenMai.Rows[newRowIndex].Cells[1].Value = dt.Rows[i]["Tên khuyến mãi"].ToString();
                    dgvDSKhuyenMai.Rows[newRowIndex].Cells[2].Value = DateTime.Parse(dt.Rows[i]["Ngày bắt đầu"].ToString()).ToString("dd/MM/yyyy");
                    dgvDSKhuyenMai.Rows[newRowIndex].Cells[3].Value = DateTime.Parse(dt.Rows[i]["Ngày kết thúc"].ToString()).ToString("dd/MM/yyyy");
                    dgvDSKhuyenMai.Rows[newRowIndex].Cells[4].Value = dt.Rows[i]["Chiết khấu"].ToString() + " %";
                }
            }
        }

        private void UclQLNV_Load(object sender, EventArgs e)
        {
            loadDSKhuyenMai();
            dgvDSKhuyenMai.ClearSelection();
        }

        private void setEnable(bool enable)
        {
            gbxSPKhuyenMai.Enabled = enable;
            gbxTTKhuyenMai.Enabled = enable;
        }

        private async void loadSanPhamKM(string maKM)
        {
            dgvSPKM.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return qlSanPham.LayDSSPKhuyenMaiAsync(maKM);
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvSPKM.Rows.Add();
                int newRowIndex = dgvSPKM.Rows.Count - 1;
                // Kiểm tra và gán hình ảnh
                if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                {
                    dgvSPKM.Rows[newRowIndex].Cells[0].Value = chuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                }
                dgvSPKM.Rows[newRowIndex].Cells[1].Value = dt.Rows[i]["MaHH"].ToString();
                dgvSPKM.Rows[newRowIndex].Cells[2].Value = dt.Rows[i]["TenHH"].ToString();
            }
        }

        #region Kiểm tra dữ liệu rỗng
        private bool CheckNull()
        {
            if (string.IsNullOrWhiteSpace(txtTenKM.Text) ||
                string.IsNullOrWhiteSpace(txtChietKhau.Text))
            {
                return false;
            }
            return true;
        }
        #endregion

        private async void dgvDanhSachKM_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                loadSanPhamKM(dgvDSKhuyenMai.Rows[e.RowIndex].Cells[0].Value?.ToString());
                themMoi = false;
                btnLamMoi.Enabled = true;
                btnSua.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = true;
                setEnable(false);
                gbxSPKhuyenMai.Enabled = true;
                DataTable dt = await Task.Run(() =>
                {
                    return qlKhuyenMai.LayTTKMChiDinhAsync(dgvDSKhuyenMai.Rows[e.RowIndex].Cells[0].Value?.ToString());
                });
                if (dt.Rows.Count > 0)
                {
                    txtTenKM.Text = dt.Rows[0]["Tên khuyến mãi"].ToString();
                    dptNgayBatDau.EditValue = Convert.ToDateTime(dt.Rows[0]["Ngày bắt đầu"]);
                    dptNgayKetThuc.EditValue = Convert.ToDateTime(dt.Rows[0]["Ngày kết thúc"]);
                    txtChietKhau.Text = dt.Rows[0]["Chiết khấu"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private bool kiemTraNgay()
        {
            if (dptNgayKetThuc.DateTime < dptNgayBatDau.DateTime)
            {
                return false;
            }
            return true;
        }

        private bool kiemTraChietKhau()
        {
            if (int.Parse(txtChietKhau.Text) > 100)
            {
                return false;
            }
            return true;
        }

        private void setDataNull()
        {
            txtTenKM.Text = null;
            dptNgayBatDau.DateTime = DateTime.Now.Date;
            dptNgayKetThuc.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            txtChietKhau.Text = null;
            dgvSPKM.Rows.Clear();
        }

        #region Chiết khấu
        private void txtSoDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete && e.KeyChar != '.')
            {
                e.Handled = true; // Ngăn chặn ký tự không hợp lệ
            }

            if (textBox.Text.Length >= 3 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
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

            // Kiểm tra nếu độ dài đã đạt 50 và phím nhấn không phải là Backspace
            if (textBox.Text.Length >= 50 && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                MessageBox.Show("Tên đợt khuyến mãi không quá 50 kí tự !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true; // Ngăn chặn nhập thêm ký tự
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

            if (!kiemTraNgay())
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!kiemTraChietKhau())
            {
                MessageBox.Show("Chiết khấu không vượt quá 100% !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (themMoi)
                {
                    KhuyenMai khuyenMai = new KhuyenMai()
                    {
                        TenKM = txtTenKM.Text,
                        NgayBatDau = dptNgayBatDau.DateTime,
                        NgayKetThuc = dptNgayKetThuc.DateTime,
                        ChietKhau = float.Parse(txtChietKhau.Text),
                    };
                    await qlKhuyenMai.ThemKMAsync(khuyenMai);
                    themMoi = false;
                    MessageBox.Show("Thêm mới thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    KhuyenMai khuyenMai = new KhuyenMai()
                    {
                        MaDotKhuyenMai = int.Parse(dgvDSKhuyenMai.CurrentRow.Cells[0].Value.ToString()),
                        TenKM = txtTenKM.Text,
                        NgayBatDau = dptNgayBatDau.DateTime,
                        NgayKetThuc = dptNgayKetThuc.DateTime,
                        ChietKhau = float.Parse(txtChietKhau.Text),
                    };
                    await qlKhuyenMai.CapNhatKMAsync(khuyenMai);
                    MessageBox.Show("Cập nhật thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                loadDSKhuyenMai();
                setDataNull();
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
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Visible = false;
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.ToLower();
            foreach (DataGridViewRow row in dgvDSKhuyenMai.Rows)
            {
                // Kiểm tra nếu cell[1] chứa văn bản tìm kiếm
                if (row.Cells[1].Value != null &&
                    row.Cells[1].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
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
            dgvDSKhuyenMai.ClearSelection();
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
                    return qlKhuyenMai.LayThongTinKMAsync();
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
                saveFileDialog.FileName = "Danh sách đợt khuyến mãi";

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
            DialogResult result = MessageBox.Show("Bạn có muốn xóa đợt giảm giá này, toàn bộ chiết khấu của những sản phẩm sẽ bị xóa ?", "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await qlKhuyenMai.XoaKMAsync(dgvDSKhuyenMai.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("Đã xóa !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDSKhuyenMai();
                setDataNull();
                btnThem.Enabled = true;
                btnSua.Enabled = false;
                btnLuu.Enabled = false;
                btnXoa.Enabled = false;
                setEnable(false);
                btnLamMoi.Enabled = false;
                dgvDSKhuyenMai.ClearSelection();
            }
        }

        private void txtTimTheoMa_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimTheoMa.Text.ToLower();
            foreach (DataGridViewRow row in dgvDSKhuyenMai.Rows)
            {
                // Kiểm tra nếu cell[1] chứa văn bản tìm kiếm
                if (row.Cells[0].Value != null &&
                    row.Cells[0].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        public void activited()
        {
            loadDSKhuyenMai();
            themMoi = false;
            setDataNull();
            setEnable(false);
            btnLamMoi.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            dgvDSKhuyenMai.ClearSelection();
            this.Visible = true;
        }
    }
}