using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using BakeryManagementSystem.Views.Forms;
using DevExpress.XtraEditors;
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
    public partial class frmThayDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        private string tenDangNhap = null;
        private bool loai = true;
        private DoiMatKhau doiMatKhau;
        
        public frmThayDoiMatKhau(bool loai, string tenDangNhap)
        {
            InitializeComponent();
            txtMKCu.Visible = loai;
            lblMKCu.Visible = loai;
            lblLogo.Visible = !loai;
            lblTieuDe.Visible = loai;
            this.loai = loai;
            this.tenDangNhap = tenDangNhap;
            doiMatKhau = new DoiMatKhau(tenDangNhap);
        }

        private bool checkMatKhau()
        {
            if (Equals(txtMatKhau.Text, txtXacNhanMK.Text))
            {
                return true;
            }
            return false;
        }

        private void ckbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMK.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
                txtXacNhanMK.PasswordChar = '\0';
                txtMKCu.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
                txtMKCu.PasswordChar = '*';
            }
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text.Length > 32)
            {
                thongBao(false, "Thông báo", "Mật khẩu không quá 32 kí tự !");
                return;
            }

            if (!loai)
            {
                bool TrangThaiThayDoi = await doiMatKhau.DoiMatKhauAsync(tenDangNhap, txtMatKhau.Text);
                if (TrangThaiThayDoi)
                {
                    thongBao(false, "Thành công", "Cập nhật mật khẩu thành công !");
                }
                else
                {
                    thongBao(false, "Thông báo", "Mật khẩu mới không được trùng với mật khẩu cũ !");
                }
            }
            else
            {
                if (checkMatKhau())
                {
                    try 
                    {
                        bool TrangThaiThayDoi = await doiMatKhau.DoiMatKhauAsync(tenDangNhap, txtMatKhau.Text);
                        if (TrangThaiThayDoi)
                        {
                            thongBao(false, "Thành công", "Cập nhật mật khẩu thành công !");
                        }
                        else
                        {
                            thongBao(false, "Thông báo", "Mật khẩu cũ không khớp !");
                        }
                    }
                    catch (Exception ex)
                    {
                        thongBao(false, "Thông báo", "Mật khẩu mới không được trùng với mật khẩu cũ !");
                    }
                }
            }
        }

        private void thongBao(bool type, string titile, string text)
        {
            frmThongBao thongBao = new frmThongBao(type, titile, text);
            thongBao.Owner = this;
            thongBao.Show();
        }

        private void frmDoiMatKhau_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loai)
            {
                this.Owner.Show();
            }
        }
    }
}
