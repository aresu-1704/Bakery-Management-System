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
    public partial class UclBanHangTheoYeuCau : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLySanPham qlSanPham = new QuanLySanPham();
        private QuanLyBanAn qlBanAn = new QuanLyBanAn();
        private QuanLyDonTheoYeuCau qlBanHang = new QuanLyDonTheoYeuCau();
        private QuanLyKhachHang qlKhachHang = new QuanLyKhachHang();
        private int maNVThuNgan = 0;
        private int maKH = -1;

        public UclBanHangTheoYeuCau()
        {
            InitializeComponent();
        }

        #region Load sản phẩm
        private async void loadDSSanPham()
        {
            dgvDSSanPham.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlSanPham.LayDSHangHoaTheoYeuCauAsync();
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

                int viTri = -1;

                string maHH = dgvDSSanPham.Rows[e.RowIndex].Cells[1].Value?.ToString();
                string giaGocStr = dgvDSSanPham.Rows[e.RowIndex].Cells[4].Value?.ToString();
                double giaGoc = double.Parse(giaGocStr.Replace("VNĐ", "").Replace(",", "").Trim());
                double giaBan = giaGoc;
                bool themMoi;

                themMoi = qlBanHang.ThemSanPham(maHH, giaBan, ref viTri);
                if (themMoi == true)
                {
                    dgvHoaDon.Rows.Add();
                    dgvHoaDon.Rows[viTri].Cells[0].Value = dgvDSSanPham.Rows[e.RowIndex].Cells[2].Value?.ToString();
                    dgvHoaDon.Rows[viTri].Cells[1].Value = giaBan.ToString("N0") + " VNĐ";
                    dgvHoaDon.Rows[viTri].Cells[2].Value = qlBanHang.DanhSachSP[viTri].SoLuong.ToString();
                    dgvHoaDon.Rows[viTri].Cells[3].Value = (giaBan * qlBanHang.DanhSachSP[viTri].SoLuong).ToString("N0") + " VNĐ";
                    dgvHoaDon.Rows[viTri].Cells[5].Value = dgvDSSanPham.Rows[e.RowIndex].Cells[1].Value?.ToString();
                    dgvHoaDon.Rows[viTri].Cells[7].Value = "0";
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
                int maSPXoa = int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[5].Value?.ToString());
                qlBanHang.XoaSanPham(int.Parse(dgvHoaDon.Rows[e.RowIndex].Cells[5].Value.ToString()));
                dgvHoaDon.Rows.RemoveAt(e.RowIndex);         

                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
            else
            {
                txtGhiChu.Text = dgvHoaDon.Rows[e.RowIndex].Cells[6].Value?.ToString();
                txtPhuThu.Text = dgvHoaDon.Rows[e.RowIndex].Cells[7].Value.ToString();
                txtSoLuong.Text = dgvHoaDon.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhuThu.Enabled = true;
                txtGhiChu.Enabled = true;
                txtSoLuong.Enabled = true;
                btnLuuSoLuong.Enabled = true;
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
            lblMaHD.Text = null;
            lblNgayMua.Text = null;
            dgvHoaDon.Rows.Clear();
            lblKHTT.Text = "Mã khách hàng:";
            txtKHTT.Text = "";
            btnXoaKHTT.Enabled = false;
            lblTongTien.Text = "0 VNĐ";
            cmbLoai.SelectedIndex = 0;
            gbxHoaDon.Enabled = false;
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
                // Trích xuất dữ liệu từ UI trước khi chạy Task.Run
                int maBan = int.Parse(cmbBan.SelectedValue.ToString());
                int loaiHoaDon = cmbLoai.SelectedIndex;
                string maHD = lblMaHD.Text;
                string tongTien = lblTongTien.Text;
                int maKhachHang = txtKHTT.Text != "" ? maKH : -1;

                frmThanhToan thanhToan = new frmThanhToan();
                thanhToan.choice += reLoad;

                await Task.Run(() =>
                {
                    return thanhToan.LoadDuLieu(null, qlBanHang, maNVThuNgan, maBan, loaiHoaDon, maHD, tongTien, dgvHoaDon.Rows, maKhachHang);
                });

                thanhToan.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hóa đơn rỗng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnLuuSoLuong_Click(object sender, EventArgs e)
        {
            if(dgvHoaDon.SelectedRows.Count > 0)
            {
                var result = qlBanHang.CapNhatSoLuongMoi(dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString(), txtSoLuong.Text,
                    txtGhiChu.Text, float.Parse(txtPhuThu.Text));
                dgvHoaDon.SelectedRows[0].Cells[3].Value = result.Item1;
                dgvHoaDon.SelectedRows[0].Cells[2].Value = txtSoLuong.Text.ToString();
                dgvHoaDon.SelectedRows[0].Cells[6].Value = result.Item2;
                dgvHoaDon.SelectedRows[0].Cells[7].Value = result.Item3;
                txtSoLuong.Text = null;
                txtPhuThu.Text = null;
                txtGhiChu.Text = null;
                txtSoLuong.Enabled = txtGhiChu.Enabled = txtPhuThu.Enabled = btnLuuSoLuong.Enabled = false;
                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }            
        }
        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var result = qlBanHang.CapNhatSoLuongMoi(dgvHoaDon.SelectedRows[0].Cells[5].Value.ToString(), txtSoLuong.Text,
                    txtGhiChu.Text, float.Parse(txtPhuThu.Text));
                dgvHoaDon.SelectedRows[0].Cells[3].Value = result.Item1;
                dgvHoaDon.SelectedRows[0].Cells[2].Value = txtSoLuong.Text.ToString();
                dgvHoaDon.SelectedRows[0].Cells[6].Value = result.Item2;
                dgvHoaDon.SelectedRows[0].Cells[7].Value = result.Item3;
                txtSoLuong.Text = null;
                txtPhuThu.Text = null;
                txtGhiChu.Text = null;
                txtSoLuong.Enabled = txtGhiChu.Enabled = txtPhuThu.Enabled = btnLuuSoLuong.Enabled = false;
                lblTongTien.Text = qlBanHang.TongTien(dgvHoaDon).ToString("N0") + " VNĐ";
            }
            else if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }
        }

        private void txtPhuThu_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Chỉ cho phép nhập số (0-9), dấu thập phân (.), Backspace và Delete
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; // Ngăn không cho nhập ký tự này
            }

            // Chỉ cho phép nhập một dấu chấm (.)
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true; // Ngăn nhập thêm dấu chấm thứ hai
            }
        }
    }
}
