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
    public partial class UclXemKhoNguyenLieu : DevExpress.XtraEditors.XtraUserControl
    {

        private QuanLyKho nguyenLieu = new QuanLyKho();
        private PhieuNhapHang phieuNhapHang = new PhieuNhapHang();

        public UclXemKhoNguyenLieu()
        {
            InitializeComponent();
        }

        #region Load nguyên liệu còn sử dụng được
        private async void loadNLCoTheSD()
        {

            dgvNguyenLieuCoTheSD.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return nguyenLieu.LayDanhSachNguyenLieuAsync();
            });

            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["TrangThai"] == true)
                {
                    // Thêm một hàng mới vào DataGridView
                    dgvNguyenLieuCoTheSD.Rows.Add();

                    // Lấy chỉ số hàng vừa được thêm vào DataGridView
                    int newRowIdx = dgvNguyenLieuCoTheSD.Rows.Count - 1;
                    // Gán các giá trị khác
                    dgvNguyenLieuCoTheSD.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaNL"].ToString();
                    dgvNguyenLieuCoTheSD.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenNL"].ToString();
                    dgvNguyenLieuCoTheSD.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvNguyenLieuCoTheSD.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["DonViTinh"].ToString();
                    dgvNguyenLieuCoTheSD.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["TenNCC"].ToString();
                }
            }
        }
        #endregion

        #region Load Nguyên liệu không còn sử dụng được
        private async void loadNLKhongSD()
        {
            dgvNguyenLieuKhongSD.Rows.Clear();

            System.Data.DataTable dt = await Task.Run(() =>
            {
                return nguyenLieu.LayDanhSachNguyenLieuAsync();
            });

            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["TrangThai"] == false)
                {
                    // Thêm một hàng mới vào DataGridView
                    dgvNguyenLieuKhongSD.Rows.Add();

                    // Lấy chỉ số hàng vừa được thêm vào DataGridView
                    int newRowIdx = dgvNguyenLieuKhongSD.Rows.Count - 1;
                    // Gán các giá trị khác
                    dgvNguyenLieuKhongSD.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaNL"].ToString();
                    dgvNguyenLieuKhongSD.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenNL"].ToString();
                    dgvNguyenLieuKhongSD.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvNguyenLieuKhongSD.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["DonViTinh"].ToString();
                    dgvNguyenLieuKhongSD.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["TenNCC"].ToString();
                }
            }
        }
        #endregion

        private void UclXemKhoNguyenLieu_Load(object sender, EventArgs e)
        {
            loadNLCoTheSD();
            loadNLKhongSD();
        }

        public void activited()
        {
            loadNLCoTheSD();
            loadNLKhongSD();
            dgvChiTietPhieuNhap.Rows.Clear();
            lblMaPhieu.Text = null;
            lblNgay.Text = null;
            lblTenNV.Text = null;
            lblTongTien.Text = "0 VNĐ";
            this.Visible = true;
        }

        private async void dgvDSNguyenLieuCoTheSD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvChiTietPhieuNhap.Rows.Clear();
                int maNL = int.Parse(dgvNguyenLieuCoTheSD.Rows[e.RowIndex].Cells[0].Value?.ToString());
                
                DataTable dt = await Task.Run(() =>
                {
                    return phieuNhapHang.LayChiTietPNAsync(maNL);
                });

                lblMaPhieu.Text = dt.Rows[0]["MaPhieu"].ToString();
                lblNgay.Text = ((DateTime)dt.Rows[0]["ThoiGian"]).ToString("dd/MM/yyyy");
                lblTenNV.Text = dt.Rows[0]["TenNV"].ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvChiTietPhieuNhap.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvChiTietPhieuNhap.Rows.Count - 1;
                        // Gán các giá trị khác
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["TenNL"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["SoLuongNhap"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["DonViTinh"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[3].Value = double.Parse(dt.Rows[i]["TongTien"].ToString()).ToString("N0") + " VNĐ";
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["MaNCC"].ToString();
                    }
                }

                dt = await Task.Run(() =>
                {
                    return phieuNhapHang.LayTongTienAsync(int.Parse(lblMaPhieu.Text));
                });

                lblTongTien.Text = double.Parse(dt.Rows[0][1].ToString()).ToString("N0") + " VNĐ";
            }
            catch(Exception ex)
            {
            }
        }

        private async void dgvNLKhongSD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dgvChiTietPhieuNhap.Rows.Clear();
                int maNL = int.Parse(dgvNguyenLieuKhongSD.Rows[e.RowIndex].Cells[0].Value?.ToString());

                DataTable dt = await Task.Run(() =>
                {
                    return phieuNhapHang.LayChiTietPNAsync(maNL);
                });

                lblMaPhieu.Text = dt.Rows[0]["MaPhieu"].ToString();
                lblNgay.Text = ((DateTime)dt.Rows[0]["ThoiGian"]).ToString("dd/MM/yyyy");
                lblTenNV.Text = dt.Rows[0]["TenNV"].ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        // Thêm một hàng mới vào DataGridView
                        dgvChiTietPhieuNhap.Rows.Add();

                        // Lấy chỉ số hàng vừa được thêm vào DataGridView
                        int newRowIdx = dgvChiTietPhieuNhap.Rows.Count - 1;
                        // Gán các giá trị khác
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["TenNL"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["SoLuongNhap"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["DonViTinh"].ToString();
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[3].Value = double.Parse(dt.Rows[i]["TongTien"].ToString()).ToString("N0") + " VNĐ";
                        dgvChiTietPhieuNhap.Rows[newRowIdx].Cells[4].Value = dt.Rows[i]["MaNCC"].ToString();
                    }
                }

                dt = await Task.Run(() =>
                {
                    return phieuNhapHang.LayTongTienAsync(maNL);
                });

                lblTongTien.Text = double.Parse(dt.Rows[0][1].ToString()).ToString("N0") + " VNĐ";
            }
            catch (Exception ex)
            {
            }
        }
    }
}
