using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace sieu_thi_mini
{
    public partial class ImportMore : Window
    {
        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        string MaNhapHang = "";
        private static int snh = 1;
        string ProductCode;
        string ProductName;
        string ProductImportPrice;
        string ProductPrice;

        public ImportMore(string ProductCode, string ProductName, float ProductPrice)
        {
            InitializeComponent();
            this.ProductCode = txtMaSanPham.Text = ProductCode;
            this.ProductName = txtTenSanPham.Text = ProductName;
            this.ProductPrice = txtGiaBan.Text = ProductPrice.ToString();
            dpNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }

        private void defaulApp()
        {
            txtMaSanPham.Text = ProductCode;
            txtTenSanPham.Text = ProductName;
            txtSoLuong.Text = "";
            txtGiaNhap.Text = ProductImportPrice;
            txtGiaBan.Text = ProductPrice;
            dpNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dpHSD.Text = "";
        }

        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                string sql = "SELECT TOP 1 MaNhapHang FROM tblNhapHang ORDER BY MaNhapHang DESC";
                SqlCommand cmd = new SqlCommand(sql, Conn);
                string lastMaNhapHang = (string)cmd.ExecuteScalar();
                if (lastMaNhapHang != null)
                {
                    int lastSnh = int.Parse(lastMaNhapHang.Substring(2));
                    snh = lastSnh + 1;
                }
                MaNhapHang = "NH" + snh.ToString("D3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            defaulApp();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text) || string.IsNullOrEmpty(txtGiaNhap.Text) || string.IsNullOrEmpty(dpHSD.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
            }
            else
                try
                {
                    string sqlStr = "Insert Into tblNhapHang values(" +
                        "N'" + MaNhapHang + "'," +
                        "N'" + txtMaSanPham.Text + "'," +
                        "N'" + txtTenSanPham.Text + "'," +
                        "N'" + txtSoLuong.Text + "'," +
                        "N'" + txtGiaNhap.Text + "'," +
                        "N'" + toDate(dpNgayNhap.Text) + "'," +
                        "N'" + toDate(dpHSD.Text) + "')";
                    SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();

                    sqlStr = "UPDATE tblSanPham SET " +
             "SoLuong = SoLuong + N'" + txtSoLuong.Text + "'," +
             "HSD = N'" + toDate(dpHSD.Text) + "' FROM tblSanPham WHERE MaSanPham = N'" + txtMaSanPham.Text + "'";
                    cmd = new SqlCommand(sqlStr, Conn);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString()/*"Nhập sai! Vui lòng nhập lại"*/);
                }
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}