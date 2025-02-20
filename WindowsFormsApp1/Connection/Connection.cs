using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Connection
{
    public class Connections
    {
        private readonly string _connectionString;

        public Connections(string connectUsername, string connectPassword)
        {
            _connectionString = "Server=34.80.218.46,1433;Database=QuanLyTiemBanh;User Id=" + connectUsername + ";Password=" + connectPassword +
                ";Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        }

        // Truy vấn dữ liệu bất đồng bộ
        public async Task<DataTable> GetDataAsync(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
            return dt;
        }

        // Thực thi lệnh không trả về dữ liệu
        public async Task ExecuteQueryAsync(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                if (param.Value is byte[])
                                {
                                    cmd.Parameters.Add(param.Key, SqlDbType.VarBinary).Value = param.Value;
                                }
                                else
                                {
                                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                                }
                            }
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
        }

        // Lưu ảnh vào cơ sở dữ liệu
        public async Task SaveImageAsync(string query, byte[] imageData, Dictionary<string, object> parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ImageData", imageData);

                        if (parameters != null)
                        {
                            foreach (var param in parameters)
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
        }
    }
}
