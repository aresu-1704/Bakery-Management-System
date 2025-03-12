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
    public partial class UclLichLam : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private QuanLyPhanCong qlPhanCong = new QuanLyPhanCong();
        private int maNV = 0;
        public UclLichLam()
        {
            InitializeComponent();
        }

        private async void loadNV()
        {
            DataTable dt = await Task.Run(() =>
            {
                return qlNhanVien.LayNhanVienAsync(maNV.ToString());
            });
            lblTenNhanVien.Text = dt.Rows[0]["Ho"].ToString() + " " + dt.Rows[0]["Ten"].ToString();
            lblTenChucVu.Text = dt.Rows[0]["TenCV"].ToString();
        }

        private async void loadLichLam()
        {
            gctLichLam.DataSource = null;
            DataTable dt = await Task.Run(() =>
            {
                return qlPhanCong.LayDSPhanCongAsync(maNV);
            });

            if (dt.Rows.Count != 0)
            {
                // Chuyển đổi giá trị thời gian sang TimeSpan
                foreach (DataRow row in dt.Rows)
                {
                    if (row["GioVaoCa"] is DateTime gioVao)
                    {
                        row["GioVaoCa"] = gioVao.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                    if (row["GioTanCa"] is DateTime gioTan)
                    {
                        row["GioTanCa"] = gioTan.TimeOfDay; // Chuyển đổi sang TimeSpan
                    }
                }
                gctLichLam.DataSource = dt;
                // Cấu hình tiêu đề cột
                dgvDSPhanCong.Columns["MaPC"].Caption = "Mã phân công";
                dgvDSPhanCong.Columns["HoVaTen"].Caption = "Tên nhân viên";
                dgvDSPhanCong.Columns["Ngay"].Caption = "Thứ";
                dgvDSPhanCong.Columns["GioVaoCa"].Caption = "Giờ vào ca";
                dgvDSPhanCong.Columns["GioTanCa"].Caption = "Giờ tan ca";
                //Cấu hình cột họ và tên
                dgvDSPhanCong.Columns["HoVaTen"].Width = 250;
                // Cấu hình định dạng hiển thị cho cột Giờ
                dgvDSPhanCong.Columns["GioVaoCa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvDSPhanCong.Columns["GioVaoCa"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị

                dgvDSPhanCong.Columns["GioTanCa"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dgvDSPhanCong.Columns["GioTanCa"].DisplayFormat.FormatString = @"hh\:mm\:ss"; // Định dạng hiển thị
            }
            dgvDSPhanCong.ClearSelection();
        }

        private void UclLichLam_Load(object sender, EventArgs e)
        {

        }

        public void activited(int maNV)
        {
            this.maNV = maNV;
            loadNV();
            loadLichLam();
            this.Visible = true;
        }
    }
}
