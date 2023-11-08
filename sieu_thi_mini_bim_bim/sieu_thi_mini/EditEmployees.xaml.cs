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
    /// Interaction logic for EditEmployees.xaml
    /// </summary>
    public partial class EditEmployees : Window
    {
        string EmployeesCode;
        public EditEmployees(string EmployeesCode, string TenNhanVien, string GioiTinh, DateTime NgaySinh, string Sdt, string DiaChi, string Email, string TenDangNhap, string MatKhau)
        {
            InitializeComponent();
            txtMaNhanVien.Text = EmployeesCode;
            this.EmployeesCode = EmployeesCode;
            txtTenNhanVien.Text = TenNhanVien;
            txtGioiTinh.Text = GioiTinh;
            txtSoDienThoai.Text = Sdt;
            txtDiaChi.Text = DiaChi;
            txtEmail.Text = Email;
            txtTenDangNhap.Text = TenDangNhap;
           
            txtNgaySinh.Text = NgaySinh.ToString("dd/MM/yyyy");
        }

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

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

        private void btnCancelProduct_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }
        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhanVien.Text) || string.IsNullOrEmpty(txtTenNhanVien.Text) || string.IsNullOrEmpty(txtGioiTinh.Text) || string.IsNullOrEmpty(txtSoDienThoai.Text) || string.IsNullOrEmpty(txtDiaChi.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtTenDangNhap.Text) || string.IsNullOrEmpty(EncodeMD5(txtMatKhau.Text)))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
            {
                try
                {
                    if (txtMaNhanVien.Text != EmployeesCode)
                    {
                        string checkIfExistsQuery = "SELECT COUNT(*) FROM tblNhanVien WHERE MaNhanVien = @EmployeeCode";
                        SqlCommand checkIfExistsCmd = new SqlCommand(checkIfExistsQuery, Conn);
                        checkIfExistsCmd.Parameters.AddWithValue("@EmployeeCode", txtMaNhanVien.Text);
                        int count = Convert.ToInt32(checkIfExistsCmd.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Mã nhân viên đã tồn tại. Vui lòng nhập mã khác.");
                            return;
                        }
                    }

                    string sqlStr =
                                    "UPDATE tblNhanVien SET " +
                                    "HoTen = N'" + txtTenNhanVien.Text + "'," +
                                    "GioiTinh = N'" + txtGioiTinh.Text + "'," +
                                    "NgaySinh = N'" + toDate(txtNgaySinh.Text) + "'," +
                                    "Sdt = N'" + txtSoDienThoai.Text + "'," +
                                    "DiaChi = N'" + txtDiaChi.Text + "'," +
                                    "Email = N'" + txtEmail.Text + "'," +
                                    "TenDangNhap = N'" + txtTenDangNhap.Text + "'";

                    if (!string.IsNullOrEmpty(txtMatKhau.Text))
                    {
                        sqlStr += ", MatKhau = N'" + EncodeMD5(txtMatKhau.Text) + "'";
                    }

                    sqlStr += " WHERE MaNhanVien = N'" + EmployeesCode + "'";

                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.ToString());
                }
            }
        }


    }
}