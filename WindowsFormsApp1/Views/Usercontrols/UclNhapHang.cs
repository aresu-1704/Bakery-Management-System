using DevExpress.XtraEditors;
using BakeryManagementSystem.Views.Forms;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using BakeryManagementSystem.Models;
using BakeryManagementSystem.Controllers;

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclNhapHang : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyNhaCungCap nhaCungCap = new QuanLyNhaCungCap();
        private QuanLyPhieuNhapHang quanlyphieuNhapHang = new QuanLyPhieuNhapHang();
        private int maNVThuNgan = 0;

        public UclNhapHang()
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

        #region Load nhà cung cấp
        private async void loadDSNhaCungCap()
        {
            dgvDanhSachNCC.Rows.Clear();
            System.Data.DataTable dt = await Task.Run(() =>
            {
                return nhaCungCap.LayDSNCCAsync();
            });

            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["TrangThai"] != false)
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
            cmbNhaCungCap.DataSource = dt;
            cmbNhaCungCap.ValueMember = "MaNCC";
            cmbNhaCungCap.DisplayMember = "TenNCC";
            cmbNhaCungCap.SelectedIndex = -1;
        }
        #endregion

    
        private void UclPOS_Load(object sender, EventArgs e)
        {
            loadDSNhaCungCap();
        }

        private void btnTaoHoaDonMoi_Click(object sender, EventArgs e)
        {
            lblMaPhieu.Text = GenerateUniqueNineDigitNumber();
            gbxHoaDon.Enabled = true;
            lblNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            gbxSanPham.Enabled = true;
            gbxLoaiHoaDon.Enabled = true;
            btnTinhTien.Enabled = true;
        }

        public static string GenerateUniqueNineDigitNumber()
        {
            Random random = new Random();
            // Danh sách chứa các chữ số từ 0 đến 9
            var digits = Enumerable.Range(0, 10).ToList();
            // Trộn ngẫu nhiên danh sách chữ số
            digits = digits.OrderBy(x => random.Next()).ToList();
            // Lấy 9 chữ số đầu tiên sau khi trộn
            var uniqueNumber = string.Join("", digits.Take(9));
            return uniqueNumber;
        }

        private void dgvHoaDon_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Kiểm tra nếu chuột di chuyển vào cột thứ 5
            if (e.ColumnIndex == 6)
            {
                dgvChiTietPhieuNhap.Cursor = Cursors.Hand; // Đổi con trỏ thành hình bàn tay
            }
            else
            {
                dgvChiTietPhieuNhap.Cursor = Cursors.Default; // Trở về con trỏ mặc định
            }
        }

        public void activited(int maNV)
        {
            loadDSNhaCungCap();
            this.maNVThuNgan = maNV;
            this.Visible = true;
            dptHSD.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dgvChiTietPhieuNhap.Rows.RemoveAt(e.RowIndex);
            }
            lblTongTien.Text = tongTien().ToString("N0") + " VNĐ";
        }

        #region Ràng buộc thanh số lượng
        private void txtKHTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true; // Ngăn không cho dán
            }
        }

        private void txtKHTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào không phải là điều khiển và không phải số
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không phải số
            }

            // Kiểm tra độ dài tối đa
            if (txtSoLuong.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập thêm ký tự nếu đã đạt 9 ký tự
            }
        }
        #endregion

        #region Ràng buộc giá mua
        private void txtGiaTien_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Kiểm tra nếu ký tự nhập vào không phải là điều khiển, không phải số, và không phải dấu chấm
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ngăn không cho nhập ký tự không phải số
            }

            // Kiểm tra độ dài tối đa
            if (txtGiaTien.Text.Length >= 9 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập thêm ký tự nếu đã đạt 9 ký tự
            }
        }
        #endregion


        private decimal tongTien()
        {
            decimal tong = 0;

            // Duyệt qua từng hàng trong DataGridView
            foreach (DataGridViewRow row in dgvChiTietPhieuNhap.Rows)
            {
                // Lấy giá trị từ cell[3]
                var cellValue = row.Cells[3].Value;

                // Kiểm tra giá trị có hợp lệ không
                if (cellValue != null)
                {
                    // Chuyển đổi giá trị sang chuỗi và loại bỏ " VNĐ" và ký tự không cần thiết
                    string giaTri = cellValue.ToString().Replace(" VNĐ", "").Replace(",", "").Trim();

                    // Cố gắng chuyển đổi sang decimal và cộng vào tổng
                    if (decimal.TryParse(giaTri, out decimal giaTriDecimal))
                    {
                        tong += giaTriDecimal;
                    }
                }
            }

            return tong; // Trả về tổng
        }

        private bool checkHSD()
        {
            if (dptHSD.DateTime.Date > DateTime.Today)
            {
                return true;
            }
            return false;
        }

        private void reLoad(object sender, EventArgs e)
        {
            loadDSNhaCungCap();
            dgvChiTietPhieuNhap.Rows.Clear();
            txtTenNL.Text = "";
            txtGiaTien.Text = "";
            txtDonViTInh.Text = "";
            txtSoLuong.Text = "";
            lblMaPhieu.Text = null;
            lblNgayNhap.Text = null;
            dptHSD.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
            lblTongTien.Text = "0 VNĐ";
            gbxHoaDon.Enabled = false;
            gbxSanPham.Enabled = false;
            gbxLoaiHoaDon.Enabled = false;
            btnTinhTien.Enabled = false;
        }

        private bool checkNull()
        {
            if (string.IsNullOrEmpty(txtTenNL.Text) ||
                string.IsNullOrEmpty(txtSoLuong.Text) ||
                string.IsNullOrEmpty(txtDonViTInh.Text) ||
                string.IsNullOrEmpty(txtGiaTien.Text))
            {
                return false;
            }
            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!checkNull())
            {
                MessageBox.Show("Vui lòng không để trống dữ liệu. Hãy nhập đầy đủ thông tin.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(cmbNhaCungCap.SelectedIndex == -1)
            {
                MessageBox.Show("Nhà cung cấp không tồn tại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!checkHSD())
            {
                MessageBox.Show("Hạn sử dụng không hợp lệ. Vui lòng chọn ngày lớn hơn hôm nay.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(txtTenNL.Text.Length > 50)
            {
                MessageBox.Show("Tên nguyên liệu không quá 50 kí tự !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(txtDonViTInh.Text.Length > 15)
            {
                MessageBox.Show("Đơn vị tính không quá 15 kí tự !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dgvChiTietPhieuNhap.Rows.Add();
            int newIndex = dgvChiTietPhieuNhap.Rows.Count - 1;
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[0].Value = txtTenNL.Text;
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[1].Value = txtSoLuong.Text;
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[2].Value = txtDonViTInh.Text;
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[3].Value = float.Parse(txtGiaTien.Text).ToString("N0") + " VNĐ";
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[5].Value = cmbNhaCungCap.SelectedValue;
            dgvChiTietPhieuNhap.Rows[newIndex].Cells[4].Value = dptHSD.DateTime.ToString("dd/MM/yyyy");
            lblTongTien.Text = tongTien().ToString("N0") + " VNĐ";
        }

        private async void btnTinhTien_Click(object sender, EventArgs e)
        {
            frmThanhToanPhieuNhap thanhToan = new frmThanhToanPhieuNhap();
            await thanhToan.LoadDuLieu(maNVThuNgan, lblMaPhieu.Text, lblTongTien.Text, dgvChiTietPhieuNhap.Rows);
            thanhToan.choice += reLoad;
            thanhToan.ShowDialog();
        }

        private void btnXoaDuLieu_Click(object sender, EventArgs e)
        {
            txtTenNL.Text = null;
            txtSoLuong.Text = null;
            txtDonViTInh.Text = null;
            txtGiaTien.Text = null;
            cmbNhaCungCap.SelectedIndex = -1;
            dptHSD.EditValue = DateTime.Now.ToString("dd/MM/yyyy");
        }

        #region Ràng buộc tên đưa vào CSDL
        private void txtTenNL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\'')
            {
                e.Handled = true;
            }
        }
        #endregion

        private void ckcHSD_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcHSD.Checked)
            {
                dgvChiTietPhieuNhap.Columns[4].Visible = true;
            }
            else
            {
                dgvChiTietPhieuNhap.Columns[4].Visible = false;
            }
        }
    }
}
