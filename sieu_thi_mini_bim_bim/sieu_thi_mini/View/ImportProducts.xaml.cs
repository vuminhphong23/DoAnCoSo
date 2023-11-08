using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sieu_thi_mini.View
{

    public class ProductImport
    {
        public String ProductCode { get; set; }
        public String ProductName { get; set; }
        public int ImportValue { get; set; }
        public float ProductImportPrice { get; set; }
        public DateTime DayImport { get; set; }
        public DateTime Expiry { get; set; }
    }
    public class ProductItem
    {
        public String ProductCode { get; set; }
        public String ProductName { get; set; }
        public int ProductValue { get; set; }
        public string Classify { get; set; }

        public float ProductPrice { get; set; }
    }

    public partial class ImportProducts : UserControl
    {
        ObservableCollection<ProductItem> products = new ObservableCollection<ProductItem>();
        ObservableCollection<ProductImport> imports = new ObservableCollection<ProductImport>();
        public ImportProducts()
        {
            InitializeComponent();
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        private static int stt = 1;
        public string maHoaDon = "";

        //private void NapDuLieuHoaDon()
        //{
        //    dgProduct.ItemsSource = null;
        //    products.Clear();
        //    if (Conn.State != ConnectionState.Open) return;
        //    SqlCommand cmd = new SqlCommand("SELECT MaSanPham,TenSanPham,PhanLoai,SoLuong,GiaBan FROM tblSanPham", Conn);
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        ProductItem product = new ProductItem();
        //        product.ProductCode = reader.GetString(0);
        //        product.ProductName = reader.GetString(1);
        //        product.Classify = reader.GetString(2);
        //        product.ProductValue = reader.GetInt32(3);
        //        product.ProductPrice = (float)reader.GetDouble(4);
        //        if (product.ProductCode != "")
        //        {
        //            products.Add(product);
        //        }
        //    }
        //    reader.Close();
        //    //Thiết lập cho hiển thị trên DataGrid
        //    dgProduct.ItemsSource = products;

        //    dgproduct.ItemsSource = null;
        //    imports.Clear();
        //    if (Conn.State != ConnectionState.Open) return;
        //    SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhapHang", Conn);
        //    SqlDataReader reader1 = cmd1.ExecuteReader();
        //    while (reader1.Read())
        //    {
        //        ProductImport import = new ProductImport();
        //        import.ProductCode = reader1.GetString(0);
        //        import.ProductName = reader1.GetString(1);
        //        import.ImportValue = reader1.GetInt32(2);
        //        import.ProductImportPrice = (float)reader1.GetDouble(3);
        //        import.DayImport = reader1.GetDateTime(4);
        //        import.Expiry = reader1.GetDateTime(5);
        //        if (import.ProductCode != "")
        //        {
        //            imports.Add(import);
        //        }
        //    }
        //    reader1.Close();
        //    //Thiết lập cho hiển thị trên DataGrid
        //    dgproduct.ItemsSource = imports;
        //}

        private void NapDuLieu()
        {
            products.Clear();
            imports.Clear();

            if (Conn.State != ConnectionState.Open)
            {
                MessageBox.Show("Kết nối chưa được mở.");
                return;
            }

            using (SqlCommand cmd = new SqlCommand("SELECT MaSanPham, TenSanPham, PhanLoai, SoLuong, GiaBan FROM tblSanPham WHERE DaXoa = 0", Conn))
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    ProductItem product = new ProductItem();
                    product.ProductCode = reader.GetString(0);
                    product.ProductName = reader.GetString(1);
                    product.Classify = reader.GetString(2);
                    product.ProductValue = reader.GetInt32(3);
                    product.ProductPrice = (float)reader.GetDouble(4);

                    if (!string.IsNullOrEmpty(product.ProductCode))
                    {
                        products.Add(product);
                    }
                }
            }

            //Thiết lập cho hiển thị trên DataGrid
            dgProduct.ItemsSource = products;

            using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhapHang", Conn))
            using (SqlDataReader reader1 = cmd1.ExecuteReader())
            {
                while (reader1.Read())
                {
                    ProductImport import = new ProductImport();
                    import.ProductCode = reader1.GetString(1);
                    import.ProductName = reader1.GetString(2);
                    import.ImportValue = reader1.GetInt32(3);
                    import.ProductImportPrice = (float)reader1.GetDouble(4);
                    import.DayImport = reader1.GetDateTime(5);
                    import.Expiry = reader1.GetDateTime(6);

                    if (!string.IsNullOrEmpty(import.ProductCode))
                    {
                        imports.Add(import);
                    }
                }
            }
            //Thiết lập cho hiển thị trên DataGrid
            dgproduct.ItemsSource = imports;
        }


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieu();
                string sql = "SELECT TOP 1 MaHoaDon FROM tblHoaDon ORDER BY MaHoaDon DESC";
                SqlCommand cmd2 = new SqlCommand(sql, Conn);
                string lastMaDonHang = (string)cmd2.ExecuteScalar();
                if (lastMaDonHang != null)
                {
                    int lastStt = int.Parse(lastMaDonHang.Substring(2));
                    stt = lastStt + 1;
                }
                maHoaDon = "HD" + stt.ToString("D3");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            AddProduct product = new AddProduct();
            product.Closed += AddProduct_Closed;
            product.Show();
        }

        private void AddProduct_Closed(object sender, EventArgs e)
        {
            NapDuLieu();
        }

        private void btPlus_Click(object sender, RoutedEventArgs e)
        {
            ProductItem dataRowView = (ProductItem)((Button)e.Source).DataContext;
            ImportMore importMore = new ImportMore(dataRowView.ProductCode, dataRowView.ProductName, dataRowView.ProductPrice);
            importMore.ShowDialog();
            NapDuLieu();
        }

        private void btDelete_Click(object sender, RoutedEventArgs e)
        {
            ProductItem dataRowView = (ProductItem)((Button)e.Source).DataContext;
            string sqlStr = "UPDATE tblSanPham SET DaXoa = 1 WHERE MaSanPham =  N'" + dataRowView.ProductCode + "'";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            cmd.ExecuteNonQuery();
            NapDuLieu();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (txtSearch.Text == "")
            {
                // Nếu trường tìm kiếm trống, hiển thị lại toàn bộ dữ liệu
                return;
            }
            else
            {
                dgProduct.ItemsSource = null;
                products.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand cmd = new SqlCommand("SELECT MaSanPham,TenSanPham,PhanLoai,SoLuong,GiaBan FROM tblSanPham WHERE (MaSanPham LIKE '%" + search + "%' OR TenSanPham LIKE '%" + search + "%') AND DaXoa = 0", Conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductItem product = new ProductItem();
                    product.ProductCode = reader.GetString(0);
                    product.ProductName = reader.GetString(1);
                    product.Classify = reader.GetString(2);
                    product.ProductValue = reader.GetInt32(3);
                    product.ProductPrice = (float)reader.GetDouble(4);
                    if (product.ProductCode != "")
                    {
                        products.Add(product);
                    }
                }
                reader.Close();
                //Thiết lập cho hiển thị trên DataGrid
                dgProduct.ItemsSource = products;


                dgproduct.ItemsSource = null;
                imports.Clear();
                using (SqlCommand cmd1 = new SqlCommand("SELECT * FROM tblNhapHang WHERE MaSanPham LIKE '%" + search + "%' OR TenSanPham LIKE '%" + search + "%'", Conn))
                using (SqlDataReader reader1 = cmd1.ExecuteReader())
                {
                    while (reader1.Read())
                    {
                        ProductImport import = new ProductImport();
                        import.ProductCode = reader1.GetString(1);
                        import.ProductName = reader1.GetString(2);
                        import.ImportValue = reader1.GetInt32(3);
                        import.ProductImportPrice = (float)reader1.GetDouble(4);
                        import.DayImport = reader1.GetDateTime(5);
                        import.Expiry = reader1.GetDateTime(6);

                        if (!string.IsNullOrEmpty(import.ProductCode))
                        {
                            imports.Add(import);
                        }
                    }
                }

                //Thiết lập cho hiển thị trên DataGrid
                dgproduct.ItemsSource = imports;
            }
        }

        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieu();
            txtSearch.Text = "";
        }
    }
}