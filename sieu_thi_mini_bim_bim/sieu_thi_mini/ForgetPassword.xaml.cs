using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace sieu_thi_mini
{
    /// <summary>
    /// Interaction logic for ForgetPassword.xaml
    /// </summary>
    public partial class ForgetPassword : Window
    {
        public ForgetPassword()
        {
            InitializeComponent();
        }
        string mkmoi = "1234";
        string ma;
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        public static string EncodeMD5(string InportData)
        {
            MD5 mh = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
            byte[] hash = mh.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2").ToUpper());
            }
            return sb.ToString();
        }
        private void btClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        string ConnectionString = App.ConnectionString;
        private void btSend_Click(object sender, RoutedEventArgs e)
        {
            string enteredEmail = txtEmail.Text; // Lấy địa chỉ email được nhập từ TextBox

            string connectionString = ConnectionString;
            string query = "SELECT MaNhanVien FROM tblNhanVien WHERE Email = @Email";
            string query1 = "UPDATE tblNhanVien SET MatKhau = N'" + EncodeMD5(mkmoi) + "'  WHERE MaNhanVien = @MaNhanVien";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", enteredEmail);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read()) // Nếu email tồn tại trong cơ sở dữ liệu
                    {
                        ma = reader["MaNhanVien"].ToString();
                        reader.Close(); // Đóng reader ở đây

                        using (SqlCommand command1 = new SqlCommand(query1, connection))
                        {
                            command1.Parameters.AddWithValue("@MaNhanVien", ma); // Thêm tham số MaNhanVien
                            int rowsAffected = command1.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                txbPw.Text = mkmoi;
                            }
                            else
                            {
                                txbPw.Text = "Lỗi khi cập nhật mật khẩu.";
                            }
                        }
                    }
                    else
                    {
                        txbPw.Text = "Email không tồn tại";
                    }
                }
            }
        }

    }
}
