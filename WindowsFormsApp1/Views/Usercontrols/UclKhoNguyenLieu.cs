using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Usercontrols
{
    public partial class UclKhoNguyenLieu : DevExpress.XtraEditors.XtraUserControl
    {
        int maNL = 0;
        int maKhuVuc = 0;   
        private QuanLyKho qlKho = new QuanLyKho();

        public UclKhoNguyenLieu()
        {
            InitializeComponent();
        }

        private async void LoadDSKhoNguyenLieu()
        {
            flpDanhSachKeNL.Controls.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlKho.LayDSKhoNLAsync();
            });

            UclNutChon hangHoaChuaCoViTri = new UclNutChon(0, false, "Chưa xếp");
            hangHoaChuaCoViTri.click += XemNguyenLieu;
            flpDanhSachKeNL.Controls.Add(hangHoaChuaCoViTri);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                UclNutChon nutMoi = new UclNutChon(int.Parse(dt.Rows[i]["MaKhuVuc"].ToString()), (bool)dt.Rows[i]["TrangThai"], "Kệ số");
                nutMoi.click += XemNguyenLieu;
                flpDanhSachKeNL.Controls.Add(nutMoi);
                cmbViTri.Items.Add(dt.Rows[i]["MaKhuVuc"].ToString());
                cmbViTri.SelectedIndex = -1;
            }
        }

        private void UclBan_Load(object sender, EventArgs e)
        {
            LoadDSKhoNguyenLieu();
        }

        public void activited()
        {
            LoadDSKhoNguyenLieu();
            this.Visible = true;
        }

        private async void XemNguyenLieu(int maKhuVuc)
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlKho.LayDSNguyenLieuTrenKeAsync(maKhuVuc);
            });

            dgvNguyenLieu.Rows.Clear();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvNguyenLieu.Rows.Add();
                    int newRowIndex = dgvNguyenLieu.Rows.Count - 1;
                    dgvNguyenLieu.Rows[newRowIndex].Cells[0].Value = dt.Rows[i]["TenNL"].ToString();
                    dgvNguyenLieu.Rows[newRowIndex].Cells[1].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvNguyenLieu.Rows[newRowIndex].Cells[2].Value = double.Parse(dt.Rows[i]["DonViTinh"].ToString()).ToString("N0");
                    dgvNguyenLieu.Rows[newRowIndex].Cells[3].Value = ((DateTime)dt.Rows[i]["HSD"]).ToString("dd/MM/yyyy");
                    dgvNguyenLieu.Rows[newRowIndex].Cells[4].Value = (bool)dt.Rows[i]["TrangThai"] ? "Còn sử dụng " : "Không thể sử dụng";
                    dgvNguyenLieu.Rows[newRowIndex].Cells[5].Value = dt.Rows[i]["MaKhuVuc"].ToString();
                    dgvNguyenLieu.Rows[newRowIndex].Cells[6].Value = dt.Rows[i]["MaNL"].ToString();
                }
                btnLuu.Enabled = true;                          
            }
            this.maKhuVuc = maKhuVuc;
            btnXoaKe.Enabled = true;
            btnDoiTrangThai.Enabled = true;
        }

        private void dgvNguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int maKhuVuc = int.Parse(dgvNguyenLieu.Rows[e.RowIndex].Cells[5].Value?.ToString());
                int maNL = int.Parse(dgvNguyenLieu.Rows[e.RowIndex].Cells[6].Value?.ToString());
                cmbViTri.SelectedIndex = maKhuVuc;
                this.maNL = maNL; 
                btnLayNguyenLieu.Enabled = true;
                btnLuu.Enabled = true;
                cmbViTri.Enabled = true;
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Cập nhật vị trí ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                LoadDSKhoNguyenLieu();

                await Task.Run(() =>
                {
                    return qlKho.CapNhatViTriAsync(this.maNL, cmbViTri.SelectedIndex);
                });

                MessageBox.Show("Đã cập nhật !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XemNguyenLieu(maKhuVuc);
            }
        }

        private async void btnThemKe_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                return qlKho.ThemViTriAsync();
            });
            LoadDSKhoNguyenLieu();
        }

        private async void btnXoaKe_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Xóa mã kệ này, toàn bộ hàng hóa sẽ được đưa vào mục chưa xếp ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                await Task.Run(() =>
                {
                    return qlKho.XoaKeAsync(maKhuVuc);
                });

                MessageBox.Show("Đã xóa thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadDSKhoNguyenLieu();
        }

        private async void btnDoiTrangThai_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                return qlKho.DoiTrangThaiAsync(maKhuVuc);
            });
            LoadDSKhoNguyenLieu();
            btnDoiTrangThai.Enabled = false;
            btnXoaKe.Enabled = false;
        }
    }
}
