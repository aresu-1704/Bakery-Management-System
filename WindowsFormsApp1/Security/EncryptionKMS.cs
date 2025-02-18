using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Kms.V1;
using Google.Protobuf;
using Google.Apis.Auth.OAuth2;
using Grpc.Auth;
using Grpc.Core;
using System.IO;
using Google.Protobuf.WellKnownTypes;
using System.Windows;
using System.Windows.Forms;

namespace BakeryManagementSystem.Security
{
    public class KmsEncryptionService
    {
        private readonly KeyManagementServiceClient _kmsClient;
        private readonly string _projectId = "quanlytiembanh";
        private readonly string _locationId = "global";
        private readonly string _keyRingId = "Bakery-Keys-Ring";
        private readonly string _keyId = "Bakery-Key";

        public KmsEncryptionService()
        {
            string jsonPath = Environment.GetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS");

            GoogleCredential credential = GoogleCredential.FromFile(jsonPath)
                .CreateScoped(KeyManagementServiceClient.DefaultScopes);

            ChannelCredentials channelCredentials = credential.ToChannelCredentials();
            _kmsClient = new KeyManagementServiceClientBuilder
            {
                ChannelCredentials = channelCredentials
            }.Build();
        }

        public string Encrypt(string plaintext)
        {
            try
            {
                var keyName = new CryptoKeyName(_projectId, _locationId, _keyRingId, _keyId);
                var encryptRequest = new EncryptRequest
                {
                    Name = keyName.ToString(),
                    Plaintext = ByteString.CopyFromUtf8(plaintext)
                };

                var response = _kmsClient.Encrypt(encryptRequest);

                return Convert.ToBase64String(response.Ciphertext.ToByteArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình mã hóa :" + ex.Message, "Thất bại");
            }
            return null;
        }

        public string Decrypt(string ciphertext)
        {
            try
            {
                byte[] ciphertextBytes = Convert.FromBase64String(ciphertext);

                var keyName = new CryptoKeyName(_projectId, _locationId, _keyRingId, _keyId);
                var decryptRequest = new DecryptRequest
                {
                    Name = keyName.ToString(),
                    Ciphertext = ByteString.CopyFrom(ciphertextBytes)
                };

                var response = _kmsClient.Decrypt(decryptRequest);

                return response.Plaintext.ToStringUtf8();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi trong quá trình giải mã :" + ex.Message, "Thất bại");
            }
            return null;
        }
    }
}
