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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmThanhToanPhieuNhap : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler choice;
        private QuanLyNguyenLieu qlNguyenLieu = new QuanLyNguyenLieu();
        private QuanLyNhanVien qlNhanVien = new QuanLyNhanVien();
        private QuanLyPhieuNhapHang qlPhieuNhapHang = new QuanLyPhieuNhapHang();
        private int maNV = 0;

        public frmThanhToanPhieuNhap()
        {
            InitializeComponent();           
        }

        public async System.Threading.Tasks.Task LoadDuLieu(int maNVThuNgan, string soHD, string tongTien, DataGridViewRowCollection rows)
        {
            // Thu ngân
            maNV = maNVThuNgan;
            System.Data.DataTable dt = await System.Threading.Tasks.Task.Run(() =>
            {
                return qlNhanVien.LayNhanVienAsync(maNV.ToString());
            });
            lblNhanVienThuNgan.Text = dt.Rows[0]["Ho"].ToString() + " " + dt.Rows[0]["Ten"].ToString();

            // Số hóa đơn
            lblSoPhieu.Text = soHD;

            // Tổng tiền
            lblTongTien.Text = tongTien;

            // Chi tiết hóa đơn - sao chép từng dòng từ form nguồn
            foreach (DataGridViewRow row in rows)
            {
                int rowIndex = this.dgvPhieuNhap.Rows.Add(); // Thêm một dòng mới vào dgvHoaDon
                for (int i = 0; i < row.Cells.Count - 1; i++)
                {
                    this.dgvPhieuNhap.Rows[rowIndex].Cells[i].Value = row.Cells[i].Value; // Sao chép dữ liệu từ từng ô
                }
            }
        }


        private void frmThanhToan_Load(object sender, EventArgs e)
        {
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // Khởi tạo ứng dụng Word
            Word.Application wordApp = new Word.Application();
            Word.Document doc = wordApp.Documents.Add();

            try
            {
                // Thêm tiêu đề
                Word.Paragraph para = doc.Content.Paragraphs.Add();
                para.Range.Text = "PHIÊU NHẬP HÀNG";
                para.Range.Font.Size = 20;
                para.Range.Font.Bold = 1;
                para.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                para.Range.InsertParagraphAfter();

                // Thêm thông tin cơ bản
                doc.Content.Paragraphs.Add();
                doc.Content.Paragraphs.Last.Range.Text = $"Số phiếu: {lblSoPhieu.Text}";
                doc.Content.Paragraphs.Add();
                doc.Content.Paragraphs.Last.Range.Text = $"Ngày: {DateTime.Now.ToString("dd/MM/yyyy")}";
                doc.Content.Paragraphs.Add();
                doc.Content.Paragraphs.Last.Range.Text = $"Thu ngân: {lblNhanVienThuNgan.Text}";
                doc.Content.Paragraphs.Add();

                // Tạo bảng để hiển thị chi tiết hóa đơn
                Word.Table table = doc.Tables.Add(doc.Content.Paragraphs.Last.Range, dgvPhieuNhap.Rows.Count + 1, dgvPhieuNhap.Columns.Count);
                table.Borders.Enable = 1;

                // Thêm tiêu đề cho bảng
                for (int i = 0; i < dgvPhieuNhap.Columns.Count; i++)
                {
                    table.Cell(1, i + 1).Range.Text = dgvPhieuNhap.Columns[i].HeaderText;
                    table.Cell(1, i + 1).Range.Font.Bold = 1;
                }

                // Thêm dữ liệu từ DataGridView vào bảng Word
                for (int i = 0; i < dgvPhieuNhap.Rows.Count; i++)
                {
                    for (int j = 0; j < dgvPhieuNhap.Columns.Count; j++)
                    {
                        table.Cell(i + 2, j + 1).Range.Text = dgvPhieuNhap.Rows[i].Cells[j].Value?.ToString();
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
                    saveFileDialog.FileName = lblSoPhieu.Text; // Đặt tên file mặc định

                    // Kiểm tra xem người dùng có nhấn nút "OK" không
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Lưu tài liệu Word
                        doc.SaveAs2(saveFileDialog.FileName);
                        MessageBox.Show("Xuất phiếu nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Đóng tài liệu Word
                        doc.Close();
                        wordApp.Quit();
                    }
                    else
                    {
                        // Nếu người dùng không nhấn OK, đóng tài liệu và thoát hàm
                        doc.Close();
                        wordApp.Quit();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể in phiếu nhập, dữ liệu đã lưu vào cơ dở dữ liệu !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {

                //Lưu
                qlPhieuNhapHang.LuuPhieuNhapHangAsync(lblSoPhieu.Text, maNV, dgvPhieuNhap);
                choice?.Invoke(this, EventArgs.Empty);
                // Giải phóng bộ nhớ
                System.Runtime.InteropServices.Marshal.ReleaseComObject(doc);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(wordApp);
            }
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn hủy phiếu nhập hàng này không ?", "Hủy", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                choice?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }
    }
}