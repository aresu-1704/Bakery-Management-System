using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BakeryManagementSystem.Views.Usercontrols;
using BakeryManagementSystem.Controllers;
using System.Threading.Tasks;
using BakeryManagementSystem.Models;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmGiaoDienChinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private int maNVDangNhap = -1;
        private bool trangThaiDX = false;


        public frmGiaoDienChinh(int maNVDangNhap)
        {
            InitializeComponent();
            this.maNVDangNhap = maNVDangNhap;
            PhanQuyen();
        }

        #region Cập nhật thông tin cá nhân
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            frmCapNhatThongTinCaNhan capNhatTT = new frmCapNhatThongTinCaNhan(maNVDangNhap);
            capNhatTT.refresh += reLoadNV;
            capNhatTT.ShowDialog();
        }

        private void reLoadNV(object sender, EventArgs e)
        {
            if (uclQLNV.Visible)
            {
                setVisible();
                uclQLNV.activited();
            }
        }
        #endregion

        private void setVisible()
        {

            uclQLNV.Visible = false;
            uclChucVu.Visible = false;
            uclNhaCungCap.Visible = false;
            uclLuong.Visible = false; //khong dung vao
            uclQLSanPham.Visible = false; //lehuy
            uclKhuyenMai.Visible = false; //lehuy
            uclPOS.Visible = false;
            uclBan.Visible = false;
            uclNhapHang.Visible = false;
            uclXemKhoNguyenLieu.Visible = false;
            uclKhoNguyenLieu.Visible = false;
            uclKhachHangThanThiet.Visible = false;
            uclLichLam.Visible = false;
            uclLichSuMua.Visible = false;
            uclNhaBep.Visible = false;
            uclTinhTrangBep.Visible = false;
            uclDanhSachPhanCong.Visible = false;
            uclPhanCong.Visible = false;
            uclBanHangTheoYeuCau.Visible = false;
            uclDanhSachPhanCong.Visible = false;
            uclQuanLyTaiKhoan.Visible = false;
            uclBanHangTheoYeuCau.Visible = false;
            uclDonYeuCau.Visible = false;

            picBackGr.Visible = false;
            lblLoGo.Visible = false;
            lblTieuDe.Visible = false;
        }

        #region Các nút chức năng
        private void aceDangXuat_Click(object sender, EventArgs e)
        {
            frmThongBao thongBao = new frmThongBao(true, "Đăng xuất", "Bạn có muốn đăng xuất ?");
            thongBao.Owner = this;
            thongBao.choice += dangXuat;
            thongBao.Show();
            trangThaiDX = true;
        }

        private void dangXuat(object sender, EventArgs e)
        {
            this.Owner.Activate();
            this.Owner.Show();
            this.Close();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            setVisible();
            uclQLNV.activited();
        }

        private void btnDatBanh_Click(object sender, EventArgs e)
        {
            setVisible();
            uclBanHangTheoYeuCau.activited(maNVDangNhap);
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            setVisible();
            uclChucVu.activited();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            setVisible();
            uclPhanCong.activited();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            setVisible();
            uclNhaCungCap.activited();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            setVisible();
            uclLuong.activited();
        }

        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            setVisible();
            uclQLSanPham.activited();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            setVisible();
            uclKhuyenMai.activited();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            setVisible(); // Ẩn tất cả UserControl
            uclPOS.activited(maNVDangNhap); // Kích hoạt UserControl
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            setVisible(); // Ẩn tất cả UserControl
            uclBan.activited(); // Kích hoạt UserControl
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            setVisible();
            uclNhapHang.activited(maNVDangNhap);
        }

        private void btnQLNL_Click(object sender, EventArgs e)
        {
            setVisible();
            uclKhoNguyenLieu.activited();
        }

        private void btnKHTT_Click(object sender, EventArgs e)
        {
            setVisible();
            uclKhachHangThanThiet.activited();
        }

        private void btnXemLichLam_Click(object sender, EventArgs e)
        {
            setVisible();
            uclLichLam.activited(maNVDangNhap);
        }

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            setVisible();
            uclLichSuMua.activited(maNVDangNhap);
        }

        private void btnNhaBep_Click(object sender, EventArgs e)
        {
            setVisible();
            uclNhaBep.activited();
        }

        private void btnTinhTrangBep_Click(object sender, EventArgs e)
        {
            setVisible();
            uclTinhTrangBep.activited();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            setVisible();
            uclDanhSachPhanCong.activited();
        }

        private void btnQLTaiKhoan_Click(object sender, EventArgs e)
        {
            setVisible();
            uclQuanLyTaiKhoan.activited();
        }

        private void btnDonYeuCau_Click(object sender, EventArgs e)
        {
            setVisible();
            uclDonYeuCau.activited();
        }
        #endregion

        #region Phân quyền
        private async void PhanQuyen()
        {
            QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayNhanVienAsync(maNVDangNhap.ToString());
            });

            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["TenCV"] != DBNull.Value)
                {
                    string chucVu = dt.Rows[0]["TenCV"].ToString().ToLower();
                    switch (chucVu)
                    {
                        case "quản lý":
                            quyenQuanLy();
                            break;
                        case "nhân viên thu ngân":
                            quyenNhanVienThuNgan();
                            break;
                        case "nhân viên phục vụ":
                            quyenNhanVienPhucVu();
                            break;
                        case "bếp trưởng":
                            quyenBep();
                            break;
                        default:
                            quyenBinhThuong();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Bạn chưa được cấp quyền, hệ thống sẽ thoát về giao diện đăng nhập !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private void quyenQuanLy()
        {
            gbtnNhanVien.Visible = true;
            gbtnLichLamViec.Visible = true;
            gbtnKhoNguyenLieu.Visible = true;
            btnNhapHang.Visible = false;
            gbtnKhachHang.Visible = true;
            gbtnSanPham.Visible = true;
        }

        private void quyenNhanVienThuNgan()
        {
            gbtnBanHang.Visible = true;
            gbtnNhaBep.Visible = true;
            btnNhaBep.Visible = false;
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnQLTaiKhoan.Visible = false;
            btnLuong.Visible = false;
            gbtnKhoNguyenLieu.Visible = true;
            btnNhaCungCap.Visible = false;
            gbtnKhachHang.Visible = true;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
            btnChamCong.Visible = false;
            btnDonYeuCau.Visible = false;
            btnBan.Visible = false;
        }

        private void quyenNhanVienPhucVu()
        {
            gbtnBanHang.Visible = true;
            btnPOS.Visible = false;
            btnDatBanh.Visible = false;
            gbtnNhaBep.Visible = true;
            btnNhaBep.Visible = false;
            btnDonYeuCau.Visible = false;
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnQLTaiKhoan.Visible = false;
            btnLuong.Visible = false;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
            btnChamCong.Visible = false;
        }

        private void quyenBep()
        {
            gbtnNhaBep.Visible = true;
            btnTinhTrangBep.Visible = false;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
            gbtnKhoNguyenLieu.Visible = true;
            btnNhaCungCap.Visible = false;
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnLuong.Visible = false;
            btnQLTaiKhoan.Visible = false;
            btnChamCong.Visible = false;
            btnDonYeuCau.Visible = true;
        }

        private void quyenBinhThuong()
        {
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnLuong.Visible = false;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
            btnQLTaiKhoan.Visible = false;
            btnChamCong.Visible = false;
        }

        #endregion

        #region Đổi mật khẩu
        private async void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayNhanVienAsync(maNVDangNhap.ToString());
            });
            string tenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            frmThayDoiMatKhau doiMatKhau = new frmThayDoiMatKhau(true, tenDangNhap);
            doiMatKhau.Owner = this;
            doiMatKhau.ShowDialog();
        }
        #endregion      

        #region Thoát
        private void frmGiaoDienChinh_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!trangThaiDX)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn đóng ứng dụng và đăng xuất ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    trangThaiDX = true;
                    Application.Exit();
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmThongBao thongBao = new frmThongBao(true, "Thoát", "Thoát chương trình và đăng xuất ?");
            thongBao.Owner = this;
            thongBao.choice += thoat;
            thongBao.Show();
        }

        private void thoat(object sender, EventArgs e)
        {
            trangThaiDX = true;
            Application.Exit();
        }
        #endregion
   
    }
}
