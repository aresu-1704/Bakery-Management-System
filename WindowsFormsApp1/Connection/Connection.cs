using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace Connection
{
    public class Connections : DataTable
    {
        SqlConnection conn = null;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;
        SqlCommand cmd = new SqlCommand();
        #region Fields
        private static SqlConnection m_Connection;
        public static String m_ConnectString = "";
        private SqlCommand m_Command;
        private SqlDataAdapter m_DataAdapter;
        #endregion

        public Connections(string connectUsername, string connectPassword)
        {
            m_ConnectString = $"Server=34.80.218.46,1433;Database=QuanLyTiemBanh;User Id=sqlserver;Password=Hello123Oke;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        }

        #region OpenConnection
        public bool Connect()
        {
            try
            {
                if (m_Connection == null)
                    m_Connection = new SqlConnection(m_ConnectString);
                if (m_Connection.State == ConnectionState.Closed)
                    m_Connection.Open();
                return true;
            }
            catch
            {
                m_Connection.Close();
                return false;
            }
        }
        #endregion

        #region CloseConnection
        public static void Disconnect()
        {
            m_Connection.Close();
        }
        #endregion

        //Truy vấn dữ liệu bất đồng bộ
        public async Task<DataTable> GetDataAsync(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();

            try
            {
                Connect(); // Đảm bảo mở kết nối trước khi truy vấn!

                using (SqlCommand m_Command = new SqlCommand(query, m_Connection))
                {
                    // Nếu có tham số, thêm vào SqlCommand
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            m_Command.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    using (SqlDataAdapter m_DataAdapter = new SqlDataAdapter(m_Command))
                    {
                        await Task.Run(() => m_DataAdapter.Fill(dt));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                m_Connection.Close(); // Đóng kết nối
            }

            return dt;
        }

        public async Task ExecuteQueryAsync(string query, Dictionary<string, object> parameters = null)
        {
            try
            {
                Connect();

                using (SqlCommand cmd = new SqlCommand(query, m_Connection))
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

                    await cmd.ExecuteNonQueryAsync(); // Thực thi async
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                Disconnect();
            }
        }


        //Lưu ảnh
        public async void SaveImageAsync(string query, byte[] imageData, Dictionary<string, object> parameters = null)
        {
            try
            {
                Connect(); // Mở kết nối

                using (SqlCommand cmd = new SqlCommand(query, m_Connection))
                {
                    // Thêm tham số ảnh
                    cmd.Parameters.AddWithValue("@ImageData", imageData);

                    // Nếu có tham số khác, thêm vào SqlCommand
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }

                    await cmd.ExecuteNonQueryAsync(); // Thực thi async
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("❌ Lỗi truy vấn: " + ex.Message);
            }
            finally
            {
                Disconnect(); // Đóng kết nối
            }
        }
    }
}
