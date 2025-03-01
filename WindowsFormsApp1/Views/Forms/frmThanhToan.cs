using BakeryManagementSystem.Controllers;
using BakeryManagementSystem.Models;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler choice;

        private QuanLyBanHang qlbanHang = new QuanLyBanHang();
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private int maNV = 0;
        private int loaiHD;
        private int maKH = -1;

        public frmThanhToan()
        {
            InitializeComponent();
        }

        public async System.Threading.Tasks.Task LoadDuLieu(QuanLyBanHang qlBanHang, int maNVThuNgan, int maBan, 
            int loaiHD, string soHD, string tongTien, DataGridViewRowCollection rows, int maKH)
        {
            this.qlbanHang = qlBanHang;

            maNV = maNVThuNgan;
            System.Data.DataTable dt = await System.Threading.Tasks.Task.Run(() =>
            {
                return qlNhanVien.LayNhanVienAsync(maNV.ToString());
            });
            lblNhanVienThuNgan.Text = dt.Rows[0]["Ho"].ToString() + " " + dt.Rows[0]["Ten"].ToString();

            lblBan.Text = maBan.ToString();

            this.loaiHD = loaiHD;
            lblLoai.Text = loaiHD == 0 ? "Mang đi" : "Tại chỗ";
            lblSoHD.Text = soHD;

            lblTongTien.Text = tongTien;

            foreach (DataGridViewRow row in rows)
            {
                int rowIndex = this.dgvHoaDon.Rows.Add();
                for (int i = 0; i < row.Cells.Count; i++)
                {
                    this.dgvHoaDon.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value;
                }
            }
            this.maKH = maKH;
        }

        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void txtKHTT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.V)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void txtKHTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            if (txtTienNhan.Text.Length >= 9)
            {
                e.Handled = true;
            }
        }

        private void txtTienNhan_Leave(object sender, EventArgs e)
        {
            // Lấy giá trị từ lblTongTien
            var lblTongTienValue = lblTongTien.Text.Replace(" VNĐ", "").Replace(",", "").Trim();

            // Kiểm tra xem lblTongTien có hợp lệ không
            if (decimal.TryParse(lblTongTienValue, out decimal tongTien))
            {
                // Lấy giá trị từ txtTienNhan
                var txtTienNhanValue = txtTienNhan.Text.Replace(" VNĐ", "").Replace(",", "").Trim();

                // Kiểm tra xem txtTienNhan có hợp lệ không
                if (decimal.TryParse(txtTienNhanValue, out decimal tienNhan))
                {
                    // So sánh giá trị
                    if (tienNhan < tongTien)
                    {
                        // Hiện thông báo nếu tiền nhận không đủ
                        MessageBox.Show("Tiền nhận không đủ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTienNhan.Focus(); // Đưa con trỏ về txtTienNhan để người dùng nhập lại
                    }
                    else
                    {
                        // Tính tiền thừa
                        decimal tienThua = tienNhan - tongTien;

                        // Hiển thị tiền thừa trên lblTienThua
                        lblTienThua.Text = tienThua.ToString("N0") + " VNĐ"; // Định dạng tiền tệ và thêm "VNĐ"
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số hợp lệ cho Tiền nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTienNhan.Focus();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại giá trị của Tổng tiền!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private async void btnThanhToan_Click(object sender, EventArgs e)
        {
            if(txtTienNhan.Text == "")
            {
                MessageBox.Show("Chưa nhận tiền !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Khởi tạo ứng dụng Word
                Word.Application wordApp = new Word.Application();
                Word.Document doc = wordApp.Documents.Add();

                try
                {
                    // Thêm tiêu đề
                    Word.Paragraph para = doc.Content.Paragraphs.Add();
                    para.Range.Text = "HÓA ĐƠN THANH TOÁN";
                    para.Range.Font.Size = 20;
                    para.Range.Font.Bold = 1;
                    para.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    para.Range.InsertParagraphAfter();

                    // Thêm thông tin cơ bản
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Số hóa đơn: {lblSoHD.Text}";
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Ngày: {DateTime.Now.ToString("dd/MM/yyyy")}";
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Thu ngân: {lblNhanVienThuNgan.Text}";
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Bàn: {lblBan.Text}";
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Loại: {lblLoai.Text}";
                    doc.Content.Paragraphs.Add();

                    // Tạo bảng để hiển thị chi tiết hóa đơn
                    Word.Table table = doc.Tables.Add(doc.Content.Paragraphs.Last.Range, dgvHoaDon.Rows.Count + 1, dgvHoaDon.Columns.Count - 2);
                    table.Borders.Enable = 1;

                    // Thêm tiêu đề cho bảng
                    for (int i = 0; i < dgvHoaDon.Columns.Count - 2; i++)
                    {
                        table.Cell(1, i + 1).Range.Text = dgvHoaDon.Columns[i].HeaderText;
                        table.Cell(1, i + 1).Range.Font.Bold = 1;
                    }

                    // Thêm dữ liệu từ DataGridView vào bảng Word
                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvHoaDon.Columns.Count - 2; j++)
                        {
                            table.Cell(i + 2, j + 1).Range.Text = dgvHoaDon.Rows[i].Cells[j].Value?.ToString();
                        }
                    }

                    // Thêm thông tin tổng tiền
                    doc.Content.Paragraphs.Add();
                    doc.Content.Paragraphs.Last.Range.Text = $"Phải thanh toán: {lblTongTien.Text}";

                    // Mở hộp thoại chọn vị trí lưu file
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Word Document|*.docx";
                        saveFileDialog.Title = "Lưu hóa đơn";
                        saveFileDialog.FileName = lblSoHD.Text; // Đặt tên file mặc định

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Lưu tài liệu Word
                            doc.SaveAs2(saveFileDialog.FileName);
                            MessageBox.Show("Xuất hóa đơn thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Đóng tài liệu Word
                            doc.Close();
                            wordApp.Quit();
                        }
                        else
                        {
                            // Đóng tài liệu và thoát hàm nếu không nhấn OK
                            doc.Close();
                            wordApp.Quit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Không thể in hóa đơn, đã lưu hóa đơn vào cơ sở dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                finally
                {
                    await System.Threading.Tasks.Task.Run(() =>
                    {
                        return qlbanHang.LuuCTHDAsync(maNV, int.Parse(lblBan.Text), loaiHD, maKH);
                    });
                    choice?.Invoke(this, EventArgs.Empty);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
                }
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy hóa đơn này không ?", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                choice?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}