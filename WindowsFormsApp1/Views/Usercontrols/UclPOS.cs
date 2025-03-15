using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Views.Forms;
using DevExpress.XtraEditors;
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

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclPOS : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLySanPham qlSanPham = new QuanLySanPham();
        private QuanLyBanAn qlBanAn = new QuanLyBanAn();
        private QuanLyBanHang qlBanHang = new QuanLyBanHang();
        private QuanLyKhachHang qlKhachHang = new QuanLyKhachHang();
        private int maNVThuNgan = 0;
        private int maKH = -1;

        public UclPOS()
        {
            InitializeComponent();
        }

        #region Load sản phẩm
        private async void loadDSSanPham()
        {
            dgvDSSanPham.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlSanPham.LayDSHangHoaBinhThuongAsync();
            });

            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["TrangThai"] == true)
                {
                    dgvDSSanPham.Rows.Add();

                    int newRowIdx = dgvDSSanPham.Rows.Count - 1;

                    if (dt.Rows[i]["HinhAnh"] as byte[] != null)
                    {
                        dgvDSSanPham.Rows[newRowIdx].Cells[0].Value = ChuyenAnh.ChuyenByteSangAnh(dt.Rows[i]["HinhAnh"] as byte[]);
                    }

                    dgvDSSanPham.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["MaHH"].ToString();
                    dgvDSSanPham.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["TenHH"].ToString();
                    dgvDSSanPham.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SanCo"].ToString();
                    dgvDSSanPham.Rows[newRowIdx].Cells[4].Value = float.Parse(dt.Rows[i]["GiaTien"].ToString()).ToString("N0") + " VNĐ";
                    dgvDSSanPham.Rows[newRowIdx].Cells[5].Value = dt.Rows[i]["ChietKhau"] != DBNull.Value ? dt.Rows[i]["ChietKhau"].ToString() : "0";
                }
            }
        }
        #endregion

        #region Load bàn ăn
        private async void loadBanVaoCMB()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlBanAn.LayDSBanAsync();
            });

            if (dt.Rows.Count > 0)
            {
                cmbBan.DataSource = dt;
                cmbBan.DisplayMember = "MaBan";
                cmbBan.ValueMember = "MaBan";
                cmbBan.SelectedIndex = 0;
            }
        }
        #endregion

        private void UclPOS_Load(object sender, EventArgs e)
        {
            loadBanVaoCMB();
        }

        private void btnTaoHoaDonMoi_Click(object sender, EventArgs e)
        {
            qlBanHang.DanhSachSP.Clear();
            loadDSSanPham();
            dgvHoaDon.Rows.Clear();
            int maHDMoi = int.Parse(qlBanHang.GenerateUniqueNineDigitNumber());
            qlBanHang.MaHoaDon = maHDMoi;
            dgvDSSanPham.Enabled = true;
            gbxHoaDon.Enabled = true;
            lblMaHD.Text = maHDMoi.ToString();
            lblNgayMua.Text = DateTime.Now.ToString("dd/MM/yyyy");
            gbxSanPham.Enabled = true;
            gbxKHTT.Enabled = true;
            gbxLoaiHoaDon.Enabled = true;
            btnTinhTien.Enabled = true;
        }

        private void dgvDSSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblMaHD.Text))
                {
                    MessageBox.Show("Vui lòng tạo 1 hóa đơn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int sanCo = int.Parse(dgvDSSanPham.Rows[e.RowIndex].Cells[3].Value?.ToString());
                int viTri = -1;

                string maHH = dgvDSSanPham.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string giaGocStr = dgvDSSanPham.Rows[e.RowIndex].Cells[4].Value?.ToString();
                double giaGoc = double.Parse(giaGocStr.Replace("VNĐ", "").Replace(",", "").Trim());
                double phanTramGiamGia = double.Parse(dgvDSSanPham.Rows[e.RowIndex].Cells[5].Value?.ToString());
                double giaBan = giaGoc * ((100 - phanTramGiamGia) / 100);
                bool themMoi;

                themMoi = qlBanHang.ThemSanPham(maHH, giaBan, sanCo, ref viTri);
                if (themMoi == true)
                {
                    dgvHoaDon.Rows.Add();
                    dgvHoaDon.Rows[viTri].Cells[0].Value = dgvDSSanPham.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    dgvHoaDon.Rows[viTri].Cells[1].Value = giaBan.ToString("N0") + " VNĐ";
                    dgvHoaDon.Rows[viTri].Cells[2].Value = qlBanHang.DanhSachSP[viTri].SoLuong.ToString();
                    dgvHoaDon.Rows[viTri].Cells[3].Value = (giaBan * qlBanHang.DanhSachSP[viTri].SoLuong).ToString("N0") + " VNĐ";
                    dgvHoaDon.Rows[viTri].Cells[5].Value = dgvDSSanPham.Rows[e.RowIndex].Cells[1].Value?.ToString();
                }

                lblTenSP.Text = dgvDSSanPham.Rows[e.RowIndex].Cells[2].Value?.ToString();
                lblGiaGoc.Text = giaGocStr;
                lblGiaBan.Text = giaBan.ToString("N0") + " VNĐ";
                if (dgvDSSanPham.Rows[e.RowIndex].Cells[0].Value is Image image)
                {
                    picAnhSP.Image = image;
                }
                else
                {
                    picAnhSP.Image = null;
                }

                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void dgvHoaDon_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dgvHoaDon.Cursor = Cursors.Hand;
            }
            else
            {
                dgvHoaDon.Cursor = Cursors.Default;
            }
        }

        public void activited(int maNV)
        {
            loadDSSanPham();
            loadBanVaoCMB();
            this.maNVThuNgan = maNV;
            cmbLoai.SelectedIndex = 0;
            this.Visible = true;
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                bool xoaSP = false;
                int maSPXoa = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[5].Value?.ToString());
                qlBanHang.XoaSanPham(int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[5].Value.ToString()));
                if (xoaSP)
                {
                    dgvHoaDon.Rows.RemoveAt(e.RowIndex);
                }

                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
            else
            {
                txtSoLuong.Text = dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString();
                btnLuuSoLuong.Enabled = true;
                txtSoLuong.Enabled = true;
            }
        }

        #region Ràng buộc thanh tìm KHTT
        private async void txtKHTT_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = await Task.Run(() =>
                {
                    return qlKhachHang.TimKhachHangAsync(txtKHTT.Text);
                });

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKHTT.Focus();
                }
                else
                {
                    txtKHTT.Enabled = false;
                    maKH = int.Parse(txtKHTT.Text);
                    txtKHTT.Text = dt.Rows[0]["TenKH"].ToString();
                    lblKHTT.Text = "Tên khách hàng:";
                    btnXoaKHTT.Enabled = true;
                }
            }
        }

        private void txtKHTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtKHTT.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }
        #endregion

        private void btnXoaKHTT_Click(object sender, EventArgs e)
        {
            txtKHTT.Enabled = true;
            txtKHTT.Text = null;
            btnXoaKHTT.Enabled = false;
            lblKHTT.Text = "Mã khách hàng:";
            maKH = -1;
        }

        private async void btnThemBan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đã thêm 1 bàn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await Task.Run(() =>
            {
                return qlBanAn.ThemBanAsync();
            });
            loadBanVaoCMB();
        }

        private void reLoad(object sender, EventArgs e)
        {
            loadBanVaoCMB();
            loadDSSanPham();
            lblGiaBan.Text = null;
            lblGiaGoc.Text = null;
            lblTenSP.Text = null;
            lblMaHD.Text = null;
            lblNgayMua.Text = null;
            picAnhSP.Image = Properties.Resources.no_image_icon_6;
            dgvHoaDon.Rows.Clear();
            lblKHTT.Text = "Mã khách hàng:";
            txtKHTT.Text = "";
            btnXoaKHTT.Enabled = false;
            lblTongTien.Text = "0 VNĐ";
            cmbLoai.SelectedIndex = 0;
            gbxHoaDon.Enabled = false;
            gbxSanPham.Enabled = false;
            gbxKHTT.Enabled = false;
            gbxLoaiHoaDon.Enabled = false;
            btnTinhTien.Enabled = false;
            txtKHTT.Enabled = true;
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtTimKiem.Text.ToLower();
            foreach (DataGridViewRow row in dgvDSSanPham.Rows)
            {
                if (row.Cells[2].Value != null &&
                    row.Cells[2].Value.ToString().ToLower().Contains(searchText))
                {
                    row.Visible = true;
                }
                else
                {
                    row.Visible = false;
                }
            }
        }

        private async void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.Rows.Count != 0)
            {
                // Lấy dữ liệu UI trước khi vào Task.Run
                int maBan = int.Parse(cmbBan.SelectedValue.ToString());
                int loaiHoaDon = cmbLoai.SelectedIndex;
                string maHD = lblMaHD.Text;
                string tongTien = lblTongTien.Text;
                int maKhachHang = txtKHTT.Text != "" ? maKH : -1;

                frmThanhToan thanhToan = new frmThanhToan();
                thanhToan.choice += reLoad;

                await Task.Run(() =>
                {
                    return thanhToan.LoadDuLieu(qlBanHang, null, maNVThuNgan, maBan, loaiHoaDon, maHD, tongTien, dgvHoaDon.Rows, maKhachHang);
                });

                thanhToan.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(txtSoLuong.Text, out _) && txtSoLuong.Text != "")
            {

            }
        }

        private void txtSoLuong_KeyDown(object sender, KeyEventArgs e)
        {
            // Cho phép các phím chức năng: Delete, Backspace, phím mũi tên, Enter, Tab
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete ||
                e.KeyCode == Keys.Left || e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                return;
            }

            // Kiểm tra nếu không phải là số (phím 0-9) thì ngăn không cho nhập
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Nếu là phím số nhưng ở bàn phím số (NumPad) thì vẫn cho nhập
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    e.SuppressKeyPress = true; // Ngăn nhập ký tự vào TextBox
                }
            }
        }

        private void btnLuuSoLuong_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.SelectedRows.Count > 0)
            {
                dgvHoaDon.SelectedRows[0].Cells[3].Value = qlBanHang.CapNhatSoLuongMoi(dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString(), txtSoLuong.Text);
                dgvHoaDon.SelectedRows[0].Cells[2].Value = txtSoLuong.Text;
                btnLuuSoLuong.Enabled = false;
                txtSoLuong.Enabled = false;
                txtSoLuong.Text = null;
                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                dgvHoaDon.SelectedRows[0].Cells[3].Value = qlBanHang.CapNhatSoLuongMoi(dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString(), txtSoLuong.Text);
                dgvHoaDon.SelectedRows[0].Cells[2].Value = txtSoLuong.Text;
                btnLuuSoLuong.Enabled = false;
                txtSoLuong.Enabled = false;
                txtSoLuong.Text = null;
                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
        }
    }
}
