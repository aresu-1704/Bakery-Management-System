using BakeryManagementSystem.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BakeryManagementSystem.Controllers
{
    public class BamMatKhau
    {
        public async Task<byte[]> BamMatKhauAsync(byte[] matKhau,byte[] muoi)
        {
            return await Task.Run(() =>
            {
                string pepper = Properties.Settings.Default.pepper;

                byte[] hashPassword;

                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] combinedBytes = matKhau.Concat(muoi).Concat(Encoding.UTF8.GetBytes(pepper)).ToArray();
                    hashPassword = sha256.ComputeHash(combinedBytes);
                }

                return hashPassword;
            });
        }

        // Hàm tạo muối ngẫu nhiên
        public byte[] TaoMuoi(int size)
        {
            byte[] salt = new byte[size];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
    }
}
