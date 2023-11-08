using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using static sieu_thi_mini.View.Employees;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Security.Cryptography;

namespace sieu_thi_mini.View
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        SqlConnection connection;
        SqlCommand command;


        string ConnectionString = App.ConnectionString;
        string manv = App.MaDangNhapService.MaDangNhap;
        public Setting()
        {
            InitializeComponent();
            Conn.ConnectionString = ConnectionString;
            Conn.Open();
            HienThi();
        }

        SqlConnection Conn = new SqlConnection();
        private void HienThi()
        {
            txtMatKhau.Text = App.MatKhauService.MatKhau;
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand command = new SqlCommand("SELECT * FROM tblNhanVien WHERE MaNhanVien = @manv", Conn);
            command.Parameters.AddWithValue("@manv", manv);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtHoTen.Text = reader.GetString(1);
                txtGioiTinh.Text = reader.GetString(2);
                txtNgaySinh.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy");
                txtSoDienThoai.Text = reader.GetString(4);
                txtDiaChi.Text = reader.GetString(5);
                txtEmail.Text = reader.GetString(6);
                txtTenDangNhap.Text = reader.GetString(7);
                
            }
            reader.Close();
            //txtMatKhau.Text = App.MatKhauService.matKhau;
        }

        private void btn_save_info(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string hoTen = txtHoTen.Text;
            string gioiTinh = txtGioiTinh.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string diaChi = txtDiaChi.Text;
            string email = txtEmail.Text;
            DateTime ngaySinh = txtNgaySinh.SelectedDate ?? DateTime.Now; // Giả sử ngày sinh được nhập đúng định dạng

            // Kết nối tới cơ sở dữ liệu và cập nhật thông tin vào bảng tblNhanVien


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE tblNhanVien SET HoTen = @HoTen, GioiTinh = @GioiTinh, SDT = @SoDienThoai, DiaChi = @DiaChi, Email = @Email, NgaySinh = @NgaySinh WHERE MaNhanVien = @manv", Conn);
                command.Parameters.AddWithValue("@manv", manv);


                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@GioiTinh", gioiTinh);
                command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                command.Parameters.AddWithValue("@DiaChi", diaChi);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@NgaySinh", ngaySinh);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Thông tin đã được cập nhật thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
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

        private void btn_changePw(object sender, RoutedEventArgs e)
        {
            // Lấy dữ liệu từ các TextBox
            string tenDangNhap = txtTenDangNhap.Text;
            string matKhau = txtMatKhau.Text;

            // Kết nối tới cơ sở dữ liệu và cập nhật thông tin vào bảng tblNhanVien
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("UPDATE tblNhanVien SET TenDangNhap = @TenDangNhap, MatKhau = @MatKhau WHERE MaNhanVien = @manv", Conn);
                command.Parameters.AddWithValue("@manv", manv);


                command.Parameters.AddWithValue("@TenDangnhap", tenDangNhap);
                command.Parameters.AddWithValue("@MatKhau", EncodeMD5(matKhau));
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    App.MatKhauService.MatKhau = txtMatKhau.Text.ToString();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Đổi mật khẩu thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }
    }
}