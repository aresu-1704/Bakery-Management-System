using BakeryManagementSystem.Controllers;
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        private DangKy dangKy = new DangKy();

        public frmDangKy()
        {
            InitializeComponent();
        }

        private void thoiGian_Tick(object sender, EventArgs e)
        {

            lblThoiGian.Text = "Thời gian: " + DateTime.Now.ToString("hh:mm:ss") + " - " + "Ngày " + DateTime.Now.ToString("dd") + " Tháng "
                + DateTime.Now.ToString("MM") + " Năm " + DateTime.Now.ToString("yyyy");
        }

        private void lklDangNhap_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        private void frmDangKy_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void ckbHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbHienMK.Checked)
            {
                txtMatKhau.PasswordChar = '\0';
                txtXacNhanMK.PasswordChar = '\0';
            }
            else
            {
                txtMatKhau.PasswordChar = '*';
                txtXacNhanMK.PasswordChar = '*';
            }
        }

        private bool checkNull()
        {
            if (string.IsNullOrWhiteSpace(txtMaNhanVien.Text) ||
               string.IsNullOrWhiteSpace(txtTenDangNhap.Text) ||
               string.IsNullOrWhiteSpace(txtMatKhau.Text) ||
               string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                return true;
            }
            return false;
        }

        private bool kiemTraThanhPhan(string matKhau)
        {
            // Biểu thức chính quy để kiểm tra chuỗi
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$";
            bool isValid = Regex.IsMatch(matKhau, pattern);
            if (isValid)
            {
                return true;
            }
            return false;
        }
        private bool checkMatKhau()
        {
            if (Equals(txtMatKhau.Text, txtXacNhanMK.Text))
            {
                return true;
            }
            return false;
        }

        private void thongBao(bool type, string titile, string text)
        {
            frmThongBao thongBao = new frmThongBao(type, titile, text);
            thongBao.Owner = this;
            thongBao.Show();
        }

        private async void btnDangKy_Click(object sender, EventArgs e)
        {
            pgpLoading.Visible = true;
            //Kiểm tra rỗng
            if (checkNull())
            {
                thongBao(false, "Thông báo", "Không bỏ trống thông tin !");
                pgpLoading.Visible = false;
                return;
            }

            try
            {
                //Kiểm tra sự tồn tại của nhân viên
                if (!await dangKy.KiemTraNhanVien(int.Parse(txtMaNhanVien.Text)))
                {
                    thongBao(false, "Thông báo", "Mã nhân viên không tồn tại hoặc nhân viên này đã có 1 tài khoản khác !");
                    pgpLoading.Visible = false;
                    return;
                }
            }
            catch (SqlException ex)
            {
                thongBao(false, "Thông báo", "Mã nhân viên không tồn tại hoặc nhân viên này đã có 1 tài khoản khác !");
                pgpLoading.Visible = false;
                return;
            }

            //Kiểm tra định dạng mật khẩu
            if (!kiemTraThanhPhan(txtMatKhau.Text))
            {
                thongBao(false, "Thông báo", "Mật khẩu phải chứa kí tự hoa, thường, số, tối thiểu 8 kí tự và chứ kí tự đặc biệt !");
                pgpLoading.Visible = false;
                return;
            }

            if (txtTenDangNhap.Text.Length > 25)
            {
                thongBao(false, "Thông báo", "Tên đăng nhập không quá 25 kí tự !");
                pgpLoading.Visible = false;
                return;
            }

            if (txtMatKhau.Text.Length > 32)
            {
                thongBao(false, "Thông báo", "Mật khẩu không quá 32 kí tự !");
                pgpLoading.Visible = false;
                return;
            }

            if(!await dangKy.KiemTraTaiKhoan(txtTenDangNhap.Text))
            {
                thongBao(false, "Thông báo", "Tên tài khoản đã tồn tại !");
                pgpLoading.Visible = false;
            }

            if (checkMatKhau())
            {
                await Task.Run(() =>
                {
                    return dangKy.TaoTaiKhoanAsync(txtTenDangNhap.Text, txtMatKhau.Text, int.Parse(txtMaNhanVien.Text));
                });
                pgpLoading.Visible = false;
                frmThongBao thongBao = new frmThongBao(true, "Thành công", "Đăng ký thành công, quay lại giao diện đăng nhập ?");
                thongBao.choice += layKetQuaTB;
                thongBao.Owner = this;
                thongBao.Show();
            }
            else
            {
                thongBao(false, "Thông báo", "Mật khẩu không trùng khớp !");
                pgpLoading.Visible = false;
            }
        }

        private void layKetQuaTB(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaNhanVien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
                thongBao(false, "Lỗi", "Mã nhân viên chỉ bao gồm chữ số !");
            }
        }
    }
}