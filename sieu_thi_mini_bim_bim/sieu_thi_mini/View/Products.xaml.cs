using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
    public class MenuItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public byte[] ImagePath { get; set; }
        public int Quantity { get; set; }
        public float totalPrice { get; set; }
    }

    public class ThongTinMatHang
    {
        public string maSanPham { get; set; }
        public string tenSanPham { get; set; }
        public int soLuong { get; set; }
        public float donGia { get; set; }
        public float thanhTien { get; set; }
    }

    public partial class Products : UserControl
    {
        private ObservableCollection<MenuItem> selectedItems = new ObservableCollection<MenuItem>();
        private Dictionary<string, int> selectedFoodItems = new Dictionary<string, int>();
        ObservableCollection<ThongTinMatHang> listFood = new ObservableCollection<ThongTinMatHang>();
        string manv;

        public Products()
        {
            InitializeComponent();
            manv = App.MaDangNhapService.MaDangNhap;
            foodItemsControl.DataContext = new MenuViewModel(); // Sử dụng ViewModel thực tế của bạn
            selectedItemsDataGrid.ItemsSource = selectedItems;
        }
        private string toDate(string date)
        {
            string[] tokens = date.Split('/');
            Array.Reverse(tokens);
            string outputString = string.Join("-", tokens);
            return outputString;
        }

        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;
        private static int stt = 1;
        public string maHoaDon = "";

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(manv == "admin")
            {
                btSave.Visibility = Visibility.Hidden;
                btCancle.Visibility = Visibility.Hidden;
            }
            
            try
            {
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
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
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        public class MenuViewModel
        {
            public ObservableCollection<MenuItem> FoodItems { get; set; }

            public MenuViewModel()
            {

                FoodItems = new ObservableCollection<MenuItem>();
                LoadDataFromDatabase();
            }

            public void LoadDataFromDatabase()
            {
                try
                {
                    // Kết nối đến cơ sở dữ liệu và truy vấn dữ liệu món ăn
                    //string connectionString = @"Data Source=KhuatPhuKien\SQLEXPRESS; Initial Catalog=QuanLySieuThi; Integrated Security=True;";
                    string connectionString = App.ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT MaSanPham, TenSanPham, GiaBan, Img FROM tblSanPham WHERE DaXoa = 0";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    MenuItem menu = new MenuItem();
                                    menu.ID = reader.GetString(0);
                                    menu.Name = reader.GetString(1);
                                    menu.Price = (float)reader.GetDouble(2);
                                    if (reader.IsDBNull(3))
                                    {
                                        menu.ImagePath = null;
                                    }
                                    else
                                    {
                                        SqlBinary img = reader.GetSqlBinary(3);
                                        menu.ImagePath = img.Value;
                                    }
                                    FoodItems.Add(menu);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu từ cơ sở dữ liệu: " + ex.ToString());
                }
            }
        }

        private void UpdateThongTinMatHang(string tenSanPham, int soLuong)
        {
            // Tìm và cập nhật thông tin món ăn trong danh sách oders
            foreach (ThongTinMatHang matHang in listFood)
            {
                if (matHang.tenSanPham == tenSanPham)
                {
                    matHang.soLuong = soLuong;
                    matHang.thanhTien = matHang.donGia * matHang.soLuong;
                    break; // Tìm thấy và cập nhật, sau đó thoát vòng lặp
                }
            }
        }

        private void FoodItem_Click(object sender, RoutedEventArgs e)
        {
            if(manv != "admin")
            {
                Button button = sender as Button;
                if (button != null)
                {
                    MenuItem selectedFood = button.DataContext as MenuItem;
                    if (selectedFood != null)
                    {
                        if (selectedFoodItems.ContainsKey(selectedFood.Name))
                        {
                            // Món ăn đã tồn tại trong danh sách, tăng số lượng
                            selectedFoodItems[selectedFood.Name]++;
                            UpdateThongTinMatHang(selectedFood.Name, selectedFoodItems[selectedFood.Name]);
                        }
                        else
                        {
                            // Món ăn chưa tồn tại trong danh sách, thêm mới
                            selectedFoodItems[selectedFood.Name] = 1;
                            ThongTinMatHang matHangMoi = new ThongTinMatHang();
                            matHangMoi.maSanPham = selectedFood.ID;
                            matHangMoi.tenSanPham = selectedFood.Name;
                            matHangMoi.soLuong = selectedFoodItems[selectedFood.Name];
                            matHangMoi.donGia = (float)selectedFood.Price;
                            matHangMoi.thanhTien = matHangMoi.donGia * matHangMoi.soLuong;
                            listFood.Add(matHangMoi);
                        }
                        UpdateSelectedItemsDataGrid();
                        CalculateTotalPrice();
                    }
                }
            }
            
        }

        private void UpdateSelectedItemsDataGrid()
        {
            selectedItems.Clear(); // Xóa danh sách hiện tại để cập nhật lại

            foreach (var pair in selectedFoodItems)
            {
                string foodName = pair.Key;
                int quantity = pair.Value;

                // Tạo một bản sao của món ăn từ danh sách món ăn gốc
                MenuItem selectedFood = ((MenuViewModel)foodItemsControl.DataContext).FoodItems
                    .FirstOrDefault(food => food.Name == foodName);

                if (selectedFood != null)
                {
                    // Cập nhật số lượng món ăn trong danh sách đã chọn
                    selectedFood.Quantity = quantity;
                    selectedFood.totalPrice = quantity * selectedFood.Price;

                    // Thêm vào danh sách hiển thị
                    selectedItems.Add(selectedFood);
                }
            }
        }

        double TotalPrice = 0;
        private void CalculateTotalPrice()
        {
            TotalPrice = 0;
            foreach (MenuItem item in selectedItems)
            {
                TotalPrice += item.Price * item.Quantity;
            }

            // Cập nhật danh sách hiển thị
            selectedItemsDataGrid.Items.Refresh();
            // Tính tổng tiền
            totalPriceTextBlock.Text = "Tổng tiền: " + TotalPrice.ToString("N0") + "đ";
        }

        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";
        }

        private ObservableCollection<MenuItem> temporarySelectedItems = new ObservableCollection<MenuItem>();

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text.Trim();
            if (string.IsNullOrWhiteSpace(search))
            {
                // Nếu trường tìm kiếm trống, không làm gì cả
                return;
            }

            try
            {
                // Tạo danh sách món ăn tìm kiếm
                ObservableCollection<MenuItem> searchResults = new ObservableCollection<MenuItem>();

                MenuViewModel viewModel = (MenuViewModel)foodItemsControl.DataContext;

                // Lưu trữ danh sách sản phẩm đã chọn vào danh sách tạm thời
                //temporarySelectedItems.Clear();
                foreach (MenuItem selected in selectedItems)
                {
                    temporarySelectedItems.Add(selected);
                }

                foreach (MenuItem item in viewModel.FoodItems)
                {
                    if (item.Name.Contains(search))
                    {
                        searchResults.Add(item);
                    }
                }

                // Thiết lập danh sách tìm kiếm làm nguồn dữ liệu cho DataGrid
                viewModel.FoodItems.Clear();
                foreach (MenuItem result in searchResults)
                {
                    viewModel.FoodItems.Add(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm sản phẩm: " + ex.ToString());
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            // Xóa tất cả thông tin trên DataGrid
            selectedItems.Clear();
            selectedFoodItems.Clear();

            // Cập nhật DataGrid và tổng tiền
            selectedItemsDataGrid.Items.Refresh();
            CalculateTotalPrice();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            
            string sqlStr = "Insert Into tblHoaDon (MaHoaDon, MaNhanVien, NgayBan, GioBan, TongTien, TrangThai) " +
                            "values (@MaHoaDon, @MaNhanVien, @NgayBan, @GioBan, @TongTien, @TrangThai)";
            SqlCommand cmd = new SqlCommand(sqlStr, Conn);
            cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
            cmd.Parameters.AddWithValue("@MaNhanVien", manv);
            cmd.Parameters.AddWithValue("@NgayBan", toDate(DateTime.Now.ToString("dd/MM/yyyy")));
            cmd.Parameters.AddWithValue("@GioBan", (DateTime.Now.ToString("HH:mm:ss")));
            cmd.Parameters.AddWithValue("@TongTien", TotalPrice);
            cmd.Parameters.AddWithValue("@TrangThai", "Chưa thanh toán");

            //try
            //{
            //    Conn.Open();
            // Kiểm tra số lượng sản phẩm trước khi lưu hóa đơn
            foreach (ThongTinMatHang matHang in listFood)
            {
                string checkSql = "SELECT SoLuong FROM tblSanPham WHERE MaSanPham = @MaSanPham";
                SqlCommand checkCmd = new SqlCommand(checkSql, Conn);
                checkCmd.Parameters.AddWithValue("@MaSanPham", matHang.maSanPham);
                int availableQuantity = (int)checkCmd.ExecuteScalar();

                if (availableQuantity < matHang.soLuong)
                {
                    MessageBox.Show($"Sản phẩm '{matHang.tenSanPham}' đã hết hàng hoặc không đủ số lượng.", "Thông báo");
                    listFood.Clear();
                    return;
                }
            }

            // Thêm hóa đơn và chi tiết hóa đơn
            cmd.ExecuteNonQuery();

            foreach (ThongTinMatHang matHang in listFood)
            {
                string sqlStr1 = "Insert Into tblChiTietHoaDon (MaHoaDon,MaSanPham,TenSanPham,SoLuong,DonGia,ThanhTien) " +
                                "values (@MaHoaDon, @MaSanPham, @TenSanPham, @SoLuong, @DonGia, @ThanhTien)";

                SqlCommand cmd1 = new SqlCommand(sqlStr1, Conn);
                cmd1.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd1.Parameters.AddWithValue("@MaSanPham", matHang.maSanPham);
                cmd1.Parameters.AddWithValue("@TenSanPham", matHang.tenSanPham);
                cmd1.Parameters.AddWithValue("@SoLuong", matHang.soLuong);
                cmd1.Parameters.AddWithValue("@DonGia", matHang.donGia);
                cmd1.Parameters.AddWithValue("@ThanhTien", matHang.thanhTien);
                cmd1.ExecuteNonQuery();

                // Trừ số lượng sản phẩm trong tblSanPham
                string updateSql = "UPDATE tblSanPham SET SoLuong = SoLuong - @SoLuong WHERE MaSanPham = @MaSanPham";
                SqlCommand updateCmd = new SqlCommand(updateSql, Conn);
                updateCmd.Parameters.AddWithValue("@SoLuong", matHang.soLuong);
                updateCmd.Parameters.AddWithValue("@MaSanPham", matHang.maSanPham);
                updateCmd.ExecuteNonQuery();
            }
            listFood.Clear();

            string sql = "SELECT TOP 1 MaHoaDon FROM tblHoaDon ORDER BY MaHoaDon DESC";
            SqlCommand cmd2 = new SqlCommand(sql, Conn);
            string lastMaDonHang = (string)cmd2.ExecuteScalar();
            if (lastMaDonHang != null)
            {
                int lastStt = int.Parse(lastMaDonHang.Substring(2));
                stt = lastStt + 1;
            }
            maHoaDon = "HD" + stt.ToString("D3");

            // Xóa tất cả thông tin trên DataGrid
            selectedItems.Clear();
            selectedFoodItems.Clear();

            // Cập nhật DataGrid và tổng tiền
            selectedItemsDataGrid.Items.Refresh();
            CalculateTotalPrice();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi khi lưu hóa đơn: " + ex.ToString());
            //}
            //finally
            //{
            //    Conn.Close();
            //}
        }


        private void btLoad_Click(object sender, RoutedEventArgs e)
        {
            // Gọi lại phương thức LoadDataFromDatabase để nạp lại danh sách sản phẩm ban đầu
            MenuViewModel viewModel = (MenuViewModel)foodItemsControl.DataContext;
            viewModel.FoodItems.Clear(); // Xóa danh sách tìm kiếm (nếu có)
            viewModel.LoadDataFromDatabase();
            selectedItems.Clear();
            foreach (MenuItem tempItem in temporarySelectedItems)
            {
                selectedItems.Add(tempItem);
            }
            UpdateSelectedItemsDataGrid();
            CalculateTotalPrice();
        }
    }
}