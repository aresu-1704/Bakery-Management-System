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

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmGiaoDienChinh : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        private int maNVDangNhap = -1;
        //private NhanVienBLL nhanVienBLL = new NhanVienBLL();    
        //private ChamCongBLL chamCongBLL = new ChamCongBLL();
        private bool trangThaiDX = false;

        public frmGiaoDienChinh(int maNVDangNhap)
        {
            InitializeComponent();
            this.maNVDangNhap = maNVDangNhap;
        }

        #region Cập nhật thông tin cá nhân
        private void btnThongTinCaNhan_Click(object sender, EventArgs e)
        {
            //frmCapNhatThongTinCaNhan capNhatTT = new frmCapNhatThongTinCaNhan(maNVDangNhap);
            //capNhatTT.refresh += reLoadNV;
            //capNhatTT.ShowDialog();
        }

        private void reLoadNV(object sender, EventArgs e)
        {
            //if (uclQuanLyNV.Visible == true)
            //{
            //    setVisible();
            //    uclQuanLyNV.activited();
            //}
        }
        #endregion

        private void setVisible()
        {
            //uclQuanLyNV.Visible = false;
            //uclChucVu.Visible = false;
            //uclLichLamViec.Visible = false;
            //uclNhaCungCap.Visible = false;
            //uclLuong.Visible = false;
            //uclQLSanPham.Visible = false;
            //uclKhuyenMai.Visible = false;
            uclPOS.Visible = false;
            uclBan.Visible = false;
            //uclNhapHang.Visible = false;
            //uclXemKhoNguyenLieu.Visible = false;
            //uclKhachHangThanThiet.Visible = false;
            //uclLichLam.Visible = false;
            //uclLichSuMua.Visible = false;
            //uclNhaBep.Visible = false;
            //uclTinhTrangBep.Visible = false;

            picBackGr.Visible = false;
            lblLoGo.Visible = false;
            lblTieuDe.Visible = false;
        }

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

        #region Các nút trong Menu
        private void btnQLNV_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclQuanLyNV.activited();
        }

        private void btnChucVu_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclChucVu.activited();
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclLichLamViec.activited();
        }

        private void btnNhaCungCap_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclNhaCungCap.activited();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclLuong.activited();
        }

        private void btnQLSanPham_Click(object sender, EventArgs e)
        {
            setVisible();
            uclQLSanPham.activited();
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclKhuyenMai.activited();
        }

        private void btnPOS_Click(object sender, EventArgs e)
        {
            setVisible();
            uclPOS.activited(maNVDangNhap);
        }

        private void btnBan_Click(object sender, EventArgs e)
        {
            setVisible();
            uclBan.activited();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclNhapHang.activited(maNVDangNhap);
        }

        private void btnQLNL_Click(object sender, EventArgs e)
        {
            setVisible();
            uclKhoNguyenLieu.activited();
        }

        private void btnKHTT_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclKhachHangThanThiet.activited();
        }

        private void btnXemLichLam_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclLichLam.activited(maNVDangNhap);
        }

        private void btnLichSuMuaHang_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclLichSuMua.activited(maNVDangNhap);
        }

        private void btnNhaBep_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclNhaBep.activited();
        }

        private void btnTinhTrangBep_Click(object sender, EventArgs e)
        {
            setVisible();
            //uclTinhTrangBep.activited();
        }
        #endregion

        #region Phân quyền
        public void quyenQuanLy()
        {
            gbtnNhanVien.Visible = true;
            gbtnLichLamViec.Visible = true;
            gbtnKhoNguyenLieu.Visible = true;
            btnNhapHang.Visible = false;
            gbtnKhachHang.Visible = true;
            gbtnSanPham.Visible = true;
        }

        public void quyenNhanVien()
        {
            gbtnBanHang.Visible = true;
            gbtnNhaBep.Visible = true;
            btnNhaBep.Visible = false;
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnLuong.Visible = false;
            gbtnKhoNguyenLieu.Visible = true;
            btnNhaCungCap.Visible = false;
            gbtnKhachHang.Visible = true;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
        }

        public void quyenBep()
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
        }

        public void quyenBinhThuong()
        {
            gbtnNhanVien.Visible = true;
            btnQLNV.Visible = false;
            btnChucVu.Visible = false;
            btnLuong.Visible = false;
            gbtnLichLamViec.Visible = true;
            btnPhanCong.Visible = false;
        }
        #endregion

        #region Đổi mật khẩu
        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            //DataTable dt = nhanVienBLL.layNhanVien(maNVDangNhap.ToString());
            //string tenDangNhap = dt.Rows[0]["TenDangNhap"].ToString();
            //frmDoiMatKhau doiMatKhau = new frmDoiMatKhau(true, tenDangNhap);
            //doiMatKhau.Owner = this;
            //doiMatKhau.ShowDialog();
        }
        #endregion

        #region Chấm công
        private void btnChamCong_Click(object sender, EventArgs e)
        {
            //DataTable dt = chamCongBLL.layTTChamCongChuaHoanThanh(maNVDangNhap);
            //if (dt.Rows.Count > 0)
            //{
            //    try
            //    {
            //        chamCongBLL.chamCongTanCa(maNVDangNhap);
            //        MessageBox.Show(string.Format("Ngày: {0} - Đã tan ca - Thời gian tan ca là : {1} !",
            //            DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss")), "Chấm công",
            //            MessageBoxButtons.OK,
            //            MessageBoxIcon.Information);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Bạn đã vào ca trước đó,  30 phút sau mới được chấm công lại !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //else
            //{
            //    chamCongBLL.chamCongVaoCa(maNVDangNhap);
            //    MessageBox.Show(string.Format("Ngày: {0} - Đã vào ca - Thời gian vào ca là : {1} !",
            //        DateTime.Now.ToString("dd/MM/yyyy"), DateTime.Now.ToString("hh:mm:ss")), "Chấm công",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Information);
            //}
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

        private void frmGiaoDienChinh_Load(object sender, EventArgs e)
        {
            quyenBep();
        }
    }
}
