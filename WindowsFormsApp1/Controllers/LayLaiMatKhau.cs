using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BakeryManagementSystem.Models;
using System.Data;

namespace BakeryManagementSystem.Controllers
{
    public class LayLaiMatKhau
    {
        private static string OTP = null;
        private TaiKhoan taiKhoan = new TaiKhoan();
        private static DateTime? lastSentTime = null;
        private static Random random = new Random();

        public static DateTime? LastSentTime { get => lastSentTime; set => lastSentTime = value; }
        public static string getOTP { get => OTP; set => OTP = value; }

        public async Task<string> TimTaiKhoan(string email)
        {
            DataTable dt = await taiKhoan.TimTaiKhoanAsync(email);
            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["Tài khoản"].ToString();
            }
            else
            {
                return null;
            }
        }

        #region Gửi OTP
        private static void GenerateOTP(int length = 6)
        {
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                otp += random.Next(0, 10).ToString();
            }
            OTP = otp;
        }

        //Gửi OTP
        public static void SendEmail(string recipientEmail)
        {
            GenerateOTP();
            try
            {
                LastSentTime = DateTime.Now;
                // Tạo email và thiết lập thông tin
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("sunnybakery232@gmail.com");
                mail.To.Add(recipientEmail);
                mail.Subject = "Khôi phục mật khẩu.";
                mail.Body = $"Mã OTP của bạn là: {OTP}, vui lòng không cung cấp cho người khác!";

                // Thiết lập cấu hình SMTP
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("sunnybakery232@gmail.com", "mpdv utwh gpgg ulcp"); // Sử dụng mật khẩu ứng dụng
                client.EnableSsl = true;
                client.Timeout = 200000;  

                // Gửi email và cập nhật thời gian gửi
                client.Send(mail);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Không thể gửi Email !", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
