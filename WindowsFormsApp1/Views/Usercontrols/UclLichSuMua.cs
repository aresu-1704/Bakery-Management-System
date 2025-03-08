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
    public partial class UclLichSuMua : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyKhachHang qlKhachHang = new QuanLyKhachHang();
        private HoaDon hoaDon = new HoaDon();
        private ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
        private int maNV = 0;
        public UclLichSuMua()
        {
            InitializeComponent();
        }

        #region DS Khách hàng
        private async void loadDSKhachHang()
        {
            dgvDanhSachKH.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlKhachHang.LayDSKhachHangAsync();
            });
            if (dt.Rows.Count == 0)
            {
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dgvDanhSachKH.Rows.Add();
                int newRowIdx = dgvDanhSachKH.Rows.Count - 1;
                dgvDanhSachKH.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaKH"].ToString();
                dgvDanhSachKH.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["HoVaTen"].ToString();
                dgvDanhSachKH.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["SoDienTHoai"].ToString();
                dgvDanhSachKH.Rows[newRowIdx].Cells[3].Value = dt.Rows[i]["SoLanMua"].ToString();
            }
        }
        #endregion

        private void UclLichSuMua_Load(object sender, EventArgs e)
        {
            loadDSKhachHang();
        }

        private async void loadHoaDonDaMua(int maKH)
        {
            dgvDSHoaDon.Rows.Clear();
            DataTable dt = await Task.Run(() =>
            {
                return hoaDon.LayThongTinHoaDonCuaKHAsync(maKH);
            });

            if(dt.Rows.Count > 0)
            {
                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvDSHoaDon.Rows.Add();
                    int newRowIdx = dgvDSHoaDon.Rows.Count - 1;
                    dgvDSHoaDon.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["MaHoaDon"].ToString();
                    dgvDSHoaDon.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["ThoiGian"].ToString();
                    dgvDSHoaDon.Rows[newRowIdx].Cells[2].Value = (bool)dt.Rows[i]["LoaiHoaDon"] == true ? "Tại chỗ" : "Mang đi";
                    dgvDSHoaDon.Rows[newRowIdx].Cells[3].Value = double.Parse(dt.Rows[i]["TongTien"].ToString()).ToString("N0") + " VNĐ";
                }
            }
        }

        private void dgvDanhSachNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDSHoaDon.Enabled = true;
            int maKH = int.Parse(dgvDanhSachKH.Rows[e.RowIndex].Cells[0].Value?.ToString());
            loadHoaDonDaMua(maKH);
        }

        public void activited(int maNV)
        {
            this.maNV = maNV;
            loadDSKhachHang();
            dgvCTHoaDon.Rows.Clear();
            lblTenNhanVien.Text = null;
            dgvDSHoaDon.Rows.Clear();
            dgvDSHoaDon.Enabled = false;
            gbxCTHoaDOn.Enabled = false;
            dgvDanhSachKH.ClearSelection();
            this.Visible = true;
        }

        private async void dgvDSHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnQuayLai.Enabled = true;
            dgvCTHoaDon.Rows.Clear();
            gbxCTHoaDOn.Enabled = true;
            int maHD = int.Parse(dgvDSHoaDon.Rows[e.RowIndex].Cells[0].Value?.ToString());
            DataTable dt = await Task.Run(() =>
            {
                return chiTietHoaDon.LayChiTietHoaDonAsync(maHD);
            });
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dgvCTHoaDon.Rows.Add();
                    int newRowIdx = dgvCTHoaDon.Rows.Count - 1;
                    dgvCTHoaDon.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["TenHH"].ToString();
                    dgvCTHoaDon.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["SoLuong"].ToString();
                    dgvCTHoaDon.Rows[newRowIdx].Cells[2].Value = double.Parse(dt.Rows[i]["GiaTien"].ToString()).ToString("N0") + " VNĐ";
                }
            }
            lblTenNhanVien.Text = dt.Rows[0]["TenNV"].ToString();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            gbxCTHoaDOn.Enabled = false;
            dgvCTHoaDon.Rows.Clear();
            btnQuayLai.Enabled = false;
            dgvDSHoaDon.ClearSelection();
        }
    }
}
