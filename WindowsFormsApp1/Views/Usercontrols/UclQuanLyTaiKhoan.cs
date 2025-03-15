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
    public partial class UclQuanLyTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        private QuanLyTaiKhoan qlTaiKhoan = new QuanLyTaiKhoan();
        private int maNV = 0;

        public UclQuanLyTaiKhoan()
        {
            InitializeComponent();
        }

        private async void LoadDSTaiKhoan()
        {
            dgvLichPhanCong.Rows.Clear();

            DataTable dt = await Task.Run(() =>
            {
                return qlTaiKhoan.LayDSTaiKhoanAsync();
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
                    dgvLichPhanCong.Rows[newRowIdx].Cells[1].Value = dt.Rows[i]["TenDangNhap"].ToString();
                    dgvLichPhanCong.Rows[newRowIdx].Cells[2].Value = (bool)dt.Rows[i]["TrangThai"]
                        ? Properties.Resources.icons8_unlock_32 : Properties.Resources.icons8_lock_32;
                }
            }
            dgvLichPhanCong.ClearSelection();
        }

        public void activited()
        {
            LoadDSTaiKhoan();
            this.Visible = true;
        }

        private async void dgvLichPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Kiểm tra nếu click vào tiêu đề hoặc ngoài phạm vi hàng hợp lệ
                if (e.RowIndex < 0 || e.ColumnIndex != 3)
                    return;

                // Kiểm tra giá trị của ô có bị null không
                var cellValue = dgvLichPhanCong.Rows[e.RowIndex].Cells[1].Value;
                if (cellValue == null)
                    return;

                string tenDangNhap = cellValue.ToString();

                // Kiểm tra trạng thái khóa/mở của tài khoản
                var iconCell = dgvLichPhanCong.Rows[e.RowIndex].Cells[2].Value;
                bool isLocked = iconCell != null && iconCell.Equals(Properties.Resources.icons8_unlock_32);

                // Gọi API cập nhật tài khoản
                await qlTaiKhoan.CapNhatKhoiPhucTKAsync(tenDangNhap);
                LoadDSTaiKhoan();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvLichPhanCong_CellMouseMove(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 3)
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
