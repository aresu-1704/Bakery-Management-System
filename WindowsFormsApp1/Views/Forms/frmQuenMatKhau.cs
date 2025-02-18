using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmQuenMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private string tenDangNhap = null;
        private LayLaiMatKhau layMatKhau = new LayLaiMatKhau();
        public frmQuenMatKhau()
        {
            InitializeComponent();
        }

        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void SendEmailAsync(string recipientEmail)
        {
            LayLaiMatKhau.SendEmail(recipientEmail);
        }

        private async void btnGuiOTP_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsValidEmail(txtEmail.Text) || txtEmail.Text.Length > 50)
                {
                    frmThongBao thongBao = new frmThongBao(false, "Thông báo", "Định dạng Email không hợp lệ !");
                    thongBao.Owner = this;
                    thongBao.ShowDialog();
                    return;
                }

                string taiKhoanTonTai = await Task.Run(() => layMatKhau.TimTaiKhoan(txtEmail.Text));
                if (string.IsNullOrEmpty(taiKhoanTonTai))
                {
                    this.tenDangNhap = taiKhoanTonTai;
                    btnGuiOTP.Enabled = false;
                    tmrDemNguocGuiOTP.Enabled = true;
                    tmrDemNguocGuiOTP.Start();
                    lblThongBaoGuiLai.Visible = true;
                    frmThongBao thongBao = new frmThongBao(false, "Thông báo", "Đã gửi OTP, nếu chưa nhận được, vui lòng thử lại sau 60 giây !");
                    thongBao.ShowDialog();
                    await Task.Run(() =>
                    {
                        SendEmailAsync(txtEmail.Text);
                    });
                }
                else
                {
                    frmThongBao thongBao = new frmThongBao(false, "Thông báo", "Không tìm thấy tài khoản !");
                    thongBao.Owner = this;
                    thongBao.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                frmThongBao thongBao = new frmThongBao(false, "Thông báo", "Không thể kết nối đến máy chủ !");
                thongBao.Owner = this;
                thongBao.ShowDialog();
            }
        }

        private void hienLaiDangNhap()
        {
            this.Owner.Show();
        }

        private void frmQuenMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            hienLaiDangNhap();
        }

        private void tmrDemNguocGuiOTP_Tick(object sender, EventArgs e)
        {
            if (LayLaiMatKhau.LastSentTime == null)
            {
                return;
            }

            double secondsElapsed = (DateTime.Now - LayLaiMatKhau.LastSentTime.Value).TotalSeconds;
            btnGuiOTP.Text = Math.Max(0, 60 - (int)secondsElapsed).ToString() + " giây";

            if (secondsElapsed >= 60)
            {
                tmrDemNguocGuiOTP.Enabled = false;
                tmrDemNguocGuiOTP.Stop();
                lblThongBaoGuiLai.Visible = false;
                LayLaiMatKhau.LastSentTime = null;
                btnGuiOTP.Enabled = true;
                btnGuiOTP.Text = "Gửi lại OTP";
            }
        }

        private void txtOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtOTP.Text.Length == 6)
            {
                if (txtOTP.Text == LayLaiMatKhau.getOTP)
                {
                    frmThayDoiMatKhau frmThayDoiMatKhau = new frmThayDoiMatKhau(false, tenDangNhap);
                    frmThayDoiMatKhau.Owner = this;
                    this.Hide();
                    frmThayDoiMatKhau.Show();
                }
                else
                {
                    frmThongBao thongBao = new frmThongBao(false, "Sai mã", "Sai OTP, vui lòng nhập lại !");
                    thongBao.Owner = this;
                    thongBao.ShowDialog();
                    txtOTP.Text = "";
                    txtOTP.Focus();
                }
            }
        }
    }
}