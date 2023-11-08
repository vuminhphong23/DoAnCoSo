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
    /// Interaction logic for AddEmployees.xaml
    /// </summary>
    public partial class AddEmployees : Window
    {
        public AddEmployees()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
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

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        private void btnCancelProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            string sqlStr = "";
            if (string.IsNullOrEmpty(txtMaNhanVien.Text) || string.IsNullOrEmpty(txtTenNhanVien.Text) || string.IsNullOrEmpty(txtGioiTinh.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(EncodeMD5(txtMatKhau.Text)) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    sqlStr = "Insert Into tblNhanVien (MaNhanVien,HoTen,GioiTinh,NgaySinh,SDT,DiaChi,Email,TenDangNhap,MatKhau) " +
                "values (@ma,@ten,@gioitinh,@ngaysinh,@sđt,@diachi,@email,@tk,@mk)";
                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.Parameters.AddWithValue("@ma", txtMaNhanVien.Text);
                    cmd.Parameters.AddWithValue("@ten", txtTenNhanVien.Text);
                    cmd.Parameters.AddWithValue("@gioitinh", txtGioiTinh.Text);
                    cmd.Parameters.AddWithValue("@ngaysinh", toDate(txtNgaySinh.Text));
                    cmd.Parameters.AddWithValue("@sđt", txtSoDienThoai.Text);
                    cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@tk", txtTenDangNhap.Text);
                    cmd.Parameters.AddWithValue("@mk", EncodeMD5(txtMatKhau.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Đã lưu nhân viên thành công.", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã Nhân Viên đã tồn tại");
                }
            }
        }
        public static int stt = 1;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                string sql = "SELECT TOP 1 MaNhanVien FROM tblNhanVien ORDER BY MaNhanVien DESC";
                SqlCommand cmd2 = new SqlCommand(sql, Conn);
                string lastMaNhanVien = (string)cmd2.ExecuteScalar();
                if (lastMaNhanVien != null)
                {
                    int lastStt = int.Parse(lastMaNhanVien.Substring(2));
                    stt = lastStt + 1;
                }
                txtMaNhanVien.Text = "NV" + stt.ToString("D3");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

    }
}