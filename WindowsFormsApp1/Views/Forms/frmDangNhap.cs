using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraExport.Xls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private DangNhap dangNhap = new DangNhap();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void thongBao(bool type, string tittle, string text)
        {
            frmThongBao thongBao = new frmThongBao(type, tittle, text);
            thongBao.Owner = this;
            thongBao.Show();
        }

        private void setEnabled(bool value)
        {
            txtTenDangNhap.Enabled = value;
            txtMatKhau.Enabled = value;
            btnDangKy.Enabled = value;
            btnDangNhap.Enabled = value;
            ckcGhiNho.Enabled = value;
            ckcHienMK.Enabled = value;
        }

        #region Đăng nhập
        private bool checkNull()
        {
            if (string.IsNullOrWhiteSpace(txtTenDangNhap.Text) || string.IsNullOrWhiteSpace(txtMatKhau.Text))
            {
                return true;
            }
            return false;
        }

        private async void logIn()
        {
            pgpLoading.Visible = true;
            bool check = checkNull();
            if (check)
            {
                thongBao(false, "Thông báo", "Nhập vào tài khoản và mật khẩu !");
                txtTenDangNhap.Focus();
                pgpLoading.Visible = false;
                return;
            }

            //Kiểm tra trạng thái tài khoản
            bool kiemTraTrangthai = await Task.Run(() =>
            {
                return dangNhap.KiemTraTaiKhoan(txtTenDangNhap.Text.Trim());
            });

            if (!kiemTraTrangthai)
            {
                pgpLoading.Visible = false;
                frmThongBao frmThongBao = new frmThongBao(true, "Thông báo", "Tài khoản của bạn đã bị khóa, lấy lại mật khẩu ?");
                frmThongBao.Owner = this;
                frmThongBao.choice += quenMK;
                frmThongBao.ShowDialog();
                return;
            }

            short kiemTraMatKhau = await Task.Run(() =>
            {
                return dangNhap.KiemTraDangNhap(txtTenDangNhap.Text.Trim(), txtMatKhau.Text);
            });

            // Lấy thông tin tài khoản từ cơ sở dữ liệu
            if (kiemTraMatKhau == 2)
            {
                pgpLoading.Visible = false;
                pgpDNThanhCong.Visible = true;
                lblDangNhapThatBai.Visible = false;
                setEnabled(false);
                await Task.Delay(500);
                //frmGiaoDienChinh giaoDienChinh = new frmGiaoDienChinh(int.Parse(dt.Rows[0]["MaNV"].ToString()));
                //giaoDienChinh.Owner = this;

                // Lưu thông tin đăng nhập nếu chọn ghi nhớ
                if (ckcGhiNho.Checked)
                {
                    Properties.Settings.Default.password = txtMatKhau.Text.Trim();
                    Properties.Settings.Default.username = txtTenDangNhap.Text;
                    Properties.Settings.Default.remember = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.password = null;
                    Properties.Settings.Default.username = null;
                    Properties.Settings.Default.remember = false;
                    Properties.Settings.Default.Save();
                }
            }
            else if(kiemTraMatKhau == 1)
            {
                ThongBaoDangNhapThatBai();
            }
            else
            {
                lblDangNhapThatBai.Text = "Tài khoản không tồn tại !";
                lblDangNhapThatBai.Visible = true;
            }
        }

        private async void ThongBaoDangNhapThatBai()
        {
            pgpLoading.Visible = true;

            int soLanDangNhap = await Task.Run(() =>
            {
                return dangNhap.KiemTraSoLanDangNhapConLaiAsync(txtTenDangNhap.Text.Trim());
            });

            pgpLoading.Visible = false;

            if (soLanDangNhap == 0)
            {
                
                frmThongBao frmThongBao = new frmThongBao(true, "Thông báo", "Tài khoản của bạn đã bị khóa, lấy lại mật khẩu ?");
                frmThongBao.Owner = this;
                frmThongBao.choice += quenMK;
                frmThongBao.ShowDialog();
                lblDangNhapThatBai.Visible = false;
            }

            lblDangNhapThatBai.Text = "Sai mật khẩu, bạn còn " + (3 - soLanDangNhap) + " lần thử !";
            lblDangNhapThatBai.Visible = true;
        }
        #endregion

        private void thoiGian_Tick(object sender, EventArgs e)
        {
            lblThoiGian.Text = "Thời gian: " + DateTime.Now.ToString("hh:mm:ss") + " - " + "Ngày " + DateTime.Now.ToString("dd") + " Tháng "
                + DateTime.Now.ToString("MM") + " Năm " + DateTime.Now.ToString("yyyy");
        }

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            frmDangKy dangKy = new frmDangKy();
            dangKy.Owner = this;
            dangKy.Show();
            this.Hide();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.remember == true)
            {
                txtTenDangNhap.Text = Properties.Settings.Default.username;
                txtMatKhau.Text = Properties.Settings.Default.password;
                ckcGhiNho.Checked = true;
                btnDangNhap.TabIndex = 1;
                btnDangNhap.Focus();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                logIn();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Không thể kết nối đến máy chủ !", "Bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void frmDangNhap_Activated(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.remember == true)
            {
                txtTenDangNhap.Text = Properties.Settings.Default.username;
                txtMatKhau.Text = Properties.Settings.Default.password;
                ckcGhiNho.Checked = true;
                btnDangNhap.TabIndex = 1;
                btnDangNhap.Focus();
            }
            else
            {
                txtTenDangNhap.Focus();
            }
            activited();
        }

        private void lklQuenMK_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            quenMK(sender, e);
        }

        private void quenMK(object sender, EventArgs e)
        {
            frmQuenMatKhau quenMatKhau = new frmQuenMatKhau();
            quenMatKhau.Owner = this;
            quenMatKhau.Show();
            this.Hide();
        }

        private void ckbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckcHienMK.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
            }
        }

        private void activited()
        {
            setEnabled(true);
            pgpDNThanhCong.Visible = false;
        }
    }
}
