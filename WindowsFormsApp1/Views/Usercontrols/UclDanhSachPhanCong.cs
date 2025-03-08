using BakeryManagementSystem.Controllers;
using DevExpress.Utils.Svg;
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
    public partial class UclDanhSachPhanCong : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyDiemDanh qlDiemDanh = new QuanLyDiemDanh();
        private int maNV = 0;

        public UclDanhSachPhanCong()
        {
            InitializeComponent();
        }

        private async void LoadLichLam()
        {
            dgvLichPhanCong.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlDiemDanh.LayLichLamHomNay();
            });

            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    // Thêm một hàng mới vào DataGridView
                    dgvLichPhanCong.Rows.Add();

                    // Lấy chỉ số hàng vừa được thêm vào DataGridView
                    int newRowIdx = dgvLichPhanCong.Rows.Count - 1;

                    // Gán các giá trị khác
                    dgvLichPhanCong.Rows[newRowIdx].Cells[0].Value = dt.Rows[i]["HoTen"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["GioVaoCa"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[2].Value = dt.Rows[i]["GioTanCa"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[3].Value = int.Parse(dt.Rows[i]["TrangThai"].ToString()) == 1 
                        ? Properties.Resources.icons8_check_28 : Properties.Resources.icons8_x_28;
                    dgvLichPhanCong.Rows[newRowIdx].Cells[4].Value = string.IsNullOrEmpty(dt.Rows[i]["giovao"].ToString()) 
                        ? null : dt.Rows[i]["giovao"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[6].Value = dt.Rows[i]["MaPC"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[7].Value = dt.Rows[i]["MaNV"].ToString();
                }
            }
            dgvLichPhanCong.ClearSelection();
        }

        public void activited()
        {
            LoadLichLam();
            this.Visible = true;
        }

        private async void dgvLichPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 5)
            {
                try
                {
                    string maNV = dgvLichPhanCong.Rows[e.RowIndex].Cells[7].Value.ToString();
                    string maPC = dgvLichPhanCong.Rows[e.RowIndex].Cells[6].Value.ToString();
                    await qlDiemDanh.DiemDanh(maNV, maPC);
                    LoadLichLam();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Chưa đến giờ vào ca hoặc đã quá thời gian điểm danh quy định !", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvLichPhanCong_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                dgvLichPhanCong.Cursor = Cursors.Hand;
            }
            else
            {
                dgvLichPhanCong.Cursor = Cursors.Default;
            }
        }
    }
}
