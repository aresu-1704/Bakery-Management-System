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
    public partial class UclBan : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyBanAn quanLyBan = new QuanLyBanAn();
        public UclBan()
        {
            InitializeComponent();
        }

        private async void loadDSBan()
        {
            flpDanhSachBan.Controls.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return quanLyBan.LayDSToanBoBanAsync();
            });

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                UclNutChonBan nutMoi = new UclNutChonBan(int.Parse(dt.Rows[i]["MaBan"].ToString()), (bool)dt.Rows[i]["TrangThai"]);
                nutMoi.click += XemHoaDon;
                flpDanhSachBan.Controls.Add(nutMoi);
            }
        }
        private void UclBan_Load(object sender, EventArgs e)
        {
            loadDSBan();
        }

        public void activited()
        {
            loadDSBan();
            this.Visible = true;
        }

        private async void XemHoaDon(int maBan)
        {
            DataTable dt = await Task.Run(() =>
            {
                return quanLyBan.LayTTHoaDonBanAsync(maBan);
            });

            dgvHoaDon.Rows.Clear();
            if(dt.Rows.Count > 0)
            {
                lblSoHD.Text = dt.Rows[0]["MaHoaDon"].ToString();
                lblLoai.Text = (bool)dt.Rows[0]["LoaiHoaDon"] == true ? "Tại chỗ" : "Mang đi";
                lblBan.Text = maBan.ToString();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvHoaDon.Rows.Add();
                    int newRowIndex = dgvHoaDon.Rows.Count - 1;
                    dgvHoaDon.Rows[newRowIndex].Cells[0].Value = dt.Rows[i]["TenHH"].ToString();
                    dgvHoaDon.Rows[newRowIndex].Cells[1].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvHoaDon.Rows[newRowIndex].Cells[2].Value = double.Parse(dt.Rows[i]["GiaTien"].ToString()).ToString("N0") + " VNĐ";
                }
                btnDonBan.Enabled = true;
            }
            else
            {
                lblSoHD.Text = "Đang trống";
                lblLoai.Text = "Đang trống";
                lblBan.Text = maBan.ToString();
                btnDonBan.Enabled = false;
            }
        }

        private async void btnDonBan_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dọn dẹp bàn này chứ ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                loadDSBan();

                await Task.Run(() =>
                {
                    return quanLyBan.DonBanAsync(int.Parse(lblBan.Text));
                });

                MessageBox.Show("Đã dọn !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                XemHoaDon(int.Parse(lblBan.Text));
            }
        }
    }
}
