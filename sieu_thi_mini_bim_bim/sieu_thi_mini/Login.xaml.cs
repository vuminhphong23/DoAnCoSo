//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Data;
//using System.Linq;
//using System.Security.Cryptography;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace sieu_thi_mini
//{
//    /// <summary>
//    /// Interaction logic for Login.xaml
//    /// </summary>
//    public partial class Login : Window
//    {
//        public Login()
//        {
//            InitializeComponent();
//            txtUser.Focus();
//        }

//        SqlConnection Conn = new SqlConnection();
//        string ConnectionString = "";

//        public static string EncodeMD5(string InportData)
//        {
//            MD5 mh = MD5.Create();
//            //Chuyển kiểu chuổi thành kiểu byte
//            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
//            //mã hóa chuỗi đã chuyển
//            byte[] hash = mh.ComputeHash(inputBytes);
//            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
//            StringBuilder sb = new StringBuilder();

//            for (int i = 0; i < hash.Length; i++)
//            {
//                sb.Append(hash[i].ToString("X2").ToUpper());
//            }

//            return sb.ToString();
//        }

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {
//            try
//            {
//                ConnectionString = App.ConnectionString;
//                Conn.ConnectionString = ConnectionString;
//                Conn.Open();

//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
//            }
//        }
//        private void btnLogin_Click(object sender, RoutedEventArgs e)
//        {
//            string username = txtUser.Text;
//            string password = EncodeMD5(pwbPassWord.Password);
//            string pw = pwbPassWord.Password.ToString();
//            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
//            {
//                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
//                return;
//            }
//            if (username == "admin" && pwbPassWord.Password == "1234")
//            {
//                MainWindow main = new MainWindow("admin");
//                main.ShowDialog();
//                App.MatKhauService.MatKhau = pw;
//                return;
//            }

//            try
//            {
//                string query = "Select * from tblNhanVien Where (TenDangNhap like '" +
//                username + "')and(MatKhau like '" + password + "')";
//                SqlDataAdapter adapter = new SqlDataAdapter(query, Conn);
//                DataSet dataSet = new DataSet();
//                adapter.Fill(dataSet);

//                if (dataSet.Tables[0].Rows.Count > 0)
//                {
//                    SqlCommand command = new SqlCommand("Select MaNhanVien, HoTen from tblNhanVien Where (TenDangNhap like '" + username + "')and(MatKhau like '" + password + "')", Conn);
//                    SqlDataReader reader = command.ExecuteReader();
//                    string manv = "";
//                    string tennv = "";
//                    while (reader.Read())
//                    {
//                        manv = reader.GetString(0);
//                        tennv = reader.GetString(1);
//                    }
//                    reader.Close();
//                    MainWindowEmployee mainWindowEmployee = new MainWindowEmployee(manv, tennv);
//                    mainWindowEmployee.ShowDialog();
//                    App.MatKhauService.MatKhau = pw;

//                }
//                else
//                {
//                    MessageBox.Show("Thông tin đăng nhập không chính xác.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
//            }
//        }

//        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
//        {
//            if (e.LeftButton == MouseButtonState.Pressed)
//            {
//                DragMove();
//            }
//        }
//        private void Button_Click_Close(object sender, RoutedEventArgs e)
//        {
//            this.Close();
//        }

//    }

//}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = "";

        public static string EncodeMD5(string InportData)
        {
            MD5 mh = MD5.Create();
            //Chuyển kiểu chuổi thành kiểu byte
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(InportData);
            //mã hóa chuỗi đã chuyển
            byte[] hash = mh.ComputeHash(inputBytes);
            //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2").ToUpper());
            }

            return sb.ToString();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            App.MatKhauService.MatKhau = "";
            try
            {
                ConnectionString = App.ConnectionString;
                Conn.ConnectionString = ConnectionString;
                Conn.Open();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUser.Text;
            string password = EncodeMD5(pwbPassWord.Password);
            string pw = pwbPassWord.Password.ToString();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin đăng nhập.");
                return;
            }
            if (username == "admin" && pwbPassWord.Password == "1234")
            {
                MainWindow main = new MainWindow("admin");
                main.ShowDialog();
                //App.MatKhauService.matKhau = pw;
                return;
            }

            try
            {
                string query = "Select * from tblNhanVien Where (TenDangNhap like '" +
                username + "')and(MatKhau like '" + password + "')";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Conn);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    SqlCommand command = new SqlCommand("Select MaNhanVien, HoTen from tblNhanVien Where (TenDangNhap like '" + username + "')and(MatKhau like '" + password + "')", Conn);
                    SqlDataReader reader = command.ExecuteReader();
                    string manv = "";
                    string tennv = "";
                    while (reader.Read())
                    {
                        manv = reader.GetString(0);
                        tennv = reader.GetString(1);
                    }
                    reader.Close();
                    MainWindowEmployee mainWindowEmployee = new MainWindowEmployee(manv, tennv);
                    App.MatKhauService.MatKhau = pw;

                    mainWindowEmployee.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không chính xác.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi truy vấn cơ sở dữ liệu: " + ex.Message);
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void lblForgetPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            ForgetPassword forgetPassword = new ForgetPassword();
            forgetPassword.ShowDialog();
        }

    }

}