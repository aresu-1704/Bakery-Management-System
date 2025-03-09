using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPrinting.Native;
using Word = Microsoft.Office.Interop.Word;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Globalization;
using BakeryManagementSystem.Controllers;

namespace BakeryManagementSystem.Views.Forms
{
    public partial class frmPhieuLuong : DevExpress.XtraEditors.XtraForm
    {
        public event EventHandler changed;
        private QuanLyTienLuong qlTienLuong = new QuanLyTienLuong();
        private double luongCoBan = 0;
        private int maNV = -1;

        public frmPhieuLuong()
        {
            InitializeComponent();
        }

        public void setData(string tenNV, DateEdit tu, DateEdit den, int maNV, double luongCoBan)
        {
            lblNhanVien.Text = tenNV;
            lblNgay.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dptNgayDau.EditValue = tu.EditValue;
            dptNgayCuoi.EditValue = den.EditValue;
            lblTu.Text = dptNgayDau.EditValue.ToString();
            lblDen.Text = dptNgayCuoi.DateTime.ToString("dd/MM/yyyy");
            lblLuongCoBan.Text = luongCoBan.ToString("N0") + " VNĐ";
            this.maNV = maNV;
            lblLuongThucNhan.Text = luongCoBan.ToString("N0") + " VNĐ";
            this.luongCoBan = luongCoBan;
        }

        private async void btnXuat_Click(object sender, EventArgs e)
        {
            // Khởi tạo ứng dụng Word
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Add();

            // Thêm tiêu đề cho tài liệu
            Word.Paragraph para1 = wordDoc.Paragraphs.Add();
            para1.Range.Text = "PHIẾU PHÁT LƯƠNG";
            para1.Range.Font.Size = 20;
            para1.Range.Font.Bold = 1;
            para1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            para1.Range.InsertParagraphAfter();

            // Thêm các thông tin vào tài liệu
            Word.Paragraph para2 = wordDoc.Paragraphs.Add();
            para2.Range.Text = "Tên nhân viên: " + lblNhanVien.Text;
            para2.Range.Font.Size = 14;
            para2.Range.InsertParagraphAfter();

            Word.Paragraph para3 = wordDoc.Paragraphs.Add();
            para3.Range.Text = "Ngày: " + lblNgay.Text;
            para3.Range.Font.Size = 14;
            para3.Range.InsertParagraphAfter();

            Word.Paragraph para4 = wordDoc.Paragraphs.Add();
            para4.Range.Text = "Thời gian tính lương: Từ " + lblTu.Text + " đến " + lblDen.Text;
            para4.Range.Font.Size = 14;
            para4.Range.InsertParagraphAfter();

            Word.Paragraph para5 = wordDoc.Paragraphs.Add();
            para5.Range.Text = "Lương cơ bản: " + lblLuongCoBan.Text + " Đồng";
            para5.Range.Font.Size = 14;
            para5.Range.InsertParagraphAfter();

            Word.Paragraph para6 = wordDoc.Paragraphs.Add();
            para6.Range.Text = "Tiền phạt: " + (txtTienPhat.Text.Length > 0 ? float.Parse(txtTienPhat.Text).ToString("N0") + " VNĐ" : "0 VNĐ");
            para6.Range.Font.Size = 14;
            para6.Range.InsertParagraphAfter();

            Word.Paragraph para7 = wordDoc.Paragraphs.Add();
            para7.Range.Text = "Lý do: " + txtLyDo.Text;
            para7.Range.Font.Size = 14;
            para7.Range.InsertParagraphAfter();

            Word.Paragraph para8 = wordDoc.Paragraphs.Add();
            para8.Range.Text = "Tiền thưởng: " + (txtTienThuong.Text.Length > 0 ? float.Parse(txtTienThuong.Text).ToString("N0") + " VNĐ" : "0 VNĐ");
            para8.Range.Font.Size = 14;
            para8.Range.InsertParagraphAfter();

            Word.Paragraph para9 = wordDoc.Paragraphs.Add();
            para8.Range.Text = "Lương thực nhận: " + lblLuongThucNhan.Text;
            para8.Range.Font.Size = 20;
            para8.Range.InsertParagraphAfter();

            // Tạo SaveFileDialog để người dùng chọn nơi lưu file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Document|*.docx"; // Đặt kiểu file là Word
            saveFileDialog.Title = "Lưu tài liệu";
            saveFileDialog.FileName = lblNhanVien.Text + ".docx"; // Tên file mặc định

            // Hiển thị hộp thoại lưu file
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Nếu người dùng chọn nơi lưu, lấy đường dẫn file
                string filePath = saveFileDialog.FileName;

                // Lưu tài liệu
                wordDoc.SaveAs2(filePath);
            }

            try
            {
                // Đóng tài liệu
                wordDoc.Close();
                wordApp.Quit();
            }
            catch (Exception ex)
            {
            }
            
            MessageBox.Show("Xuất file Word thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Cập nhật lại UclLuong
            changed?.Invoke(this, EventArgs.Empty);
            await qlTienLuong.CapNhatTinhTrangLuongAsync(dptNgayDau.DateTime, dptNgayCuoi.DateTime, maNV);

            this.Close();

        }

        #region Ràng buộc
        private void txtTienPhat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != (char)Keys.Back && e.KeyChar != (char)Keys.Delete)
            {
                e.Handled = true;
            }
        }

        private void txtTienPhat_KeyDown(object sender, KeyEventArgs e)
        {
            // Kiểm tra nếu người dùng nhấn Ctrl + V
            if (e.Control && e.KeyCode == Keys.V)
            {
                // Chặn việc dán
                e.SuppressKeyPress = true;
            }
        }
        #endregion

        private void txtTienThuong_Leave(object sender, EventArgs e)
        {
            if (txtTienPhat.Text.Length != 0 && txtTienThuong.Text.Length != 0)
            {
                lblLuongThucNhan.Text = (luongCoBan - double.Parse(txtTienPhat.Text) + double.Parse(txtTienThuong.Text)).ToString("N0") + " VNĐ";
                return;
            }

            if(txtTienPhat.Text.Length != 0)
            {
                lblLuongThucNhan.Text = (luongCoBan - double.Parse(txtTienPhat.Text)).ToString("N0") + " VNĐ";
                return;
            }

            if(txtTienThuong.Text.Length != 0)
            {
                lblLuongThucNhan.Text = (luongCoBan + double.Parse(txtTienThuong.Text)).ToString("N0") + " VNĐ";
                return;
            }
        }
    }
}
