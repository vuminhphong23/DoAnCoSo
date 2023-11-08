using Org.BouncyCastle.Asn1.X509;
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
    /// <summary>
    /// Interaction logic for Order.xaml
    /// </summary>

    public class OrderItem
    {
        public bool IsSelected { get; set; }
        public string OrderCode { get; set; }
        public string EmployeeCode { get; set; }
        public TimeSpan OrderTime { get; set; }
        public DateTime OrderDate { get; set; }
        public float TotalMoney { get; set; }
        
        public string OrderStatus { get; set; }
    }
    public partial class Order : UserControl
    {
        ObservableCollection<OrderItem> orders = new ObservableCollection<OrderItem>();
        string ConnectionString = App.ConnectionString;
        SqlConnection Conn = new SqlConnection();

        public Order()
        {
            InitializeComponent();
        }
        private void NapDuLieuHoaDon()
        {
            dgOrder.ItemsSource = null;
            orders.Clear();
            if (Conn.State != ConnectionState.Open) return;
            SqlCommand cmd = new SqlCommand("SELECT * FROM tblHoaDon order by TrangThai", Conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                OrderItem order = new OrderItem();
                order.IsSelected = false;
                order.OrderCode = reader.GetString(0);
                if (reader.IsDBNull(1))
                {
                    order.EmployeeCode = null;
                }
                else
                {
                    order.EmployeeCode = reader.GetString(1);
                }
                
                order.OrderDate = reader.GetDateTime(2);
                order.TotalMoney = (float)reader.GetDouble(4);
                order.OrderTime = reader.GetTimeSpan(3);
                order.OrderStatus = reader.GetString(5);
                if (order.OrderCode != "")
                {
                    orders.Add(order);
                }
            }
            reader.Close();
            //Thiết lập cho hiển thị trên DataGrid
            dgOrder.ItemsSource = orders;
        }



        private void txtSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            txtSearch.Text = "";

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                NapDuLieuHoaDon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kết nối dữ liệu " + ex.ToString());
            }
        }

        public bool IsAllSelected { get; set; }

        private void chkSelectAll_Checked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = true;
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].IsSelected = true;
            }
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = orders;
        }

        private void chkSelectAll_Unchecked(object sender, RoutedEventArgs e)
        {
            IsAllSelected = false;
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].IsSelected = false;
            }
            dgOrder.ItemsSource = null;
            dgOrder.ItemsSource = orders;

            for (int i = 0; i < orders.Count; i++)
            {
                if (!orders[i].IsSelected)
                {
                    string valueToRemove = orders[i].OrderCode;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[i] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
            if (listCode.Count == 0)
            {
                btnPay.Visibility = Visibility.Hidden;
            }
        }

        private void btAddProduct_Click(object sender, RoutedEventArgs e)
        {
            //AddOder order = new AddOder("Admin");
            //order.Closed += AddOder_Closed;
            //order.Show();
        }

        //private void AddOder_Closed(object sender, EventArgs e)
        //{
        //    NapDuLieuHoaDon();
        //}

        private void Window_Closed(object sender, EventArgs e)
        {
            NapDuLieuHoaDon();
        }
        List<string> listCode = new List<string>();

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            btnPay.Visibility = Visibility.Visible;
            for (int i = 0; i < orders.Count; i++)
            {
                if (orders[i].IsSelected)
                {
                    listCode.Add(orders[i].OrderCode);
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < orders.Count; i++)
            {
                if (!orders[i].IsSelected)
                {
                    string valueToRemove = orders[i].OrderCode;
                    for (int j = listCode.Count - 1; j >= 0; j--)
                    {
                        if (listCode[j] == valueToRemove)
                        {
                            listCode.RemoveAt(j);
                        }
                    }
                }
            }
            if (listCode.Count == 0)
            {
                btnPay.Visibility = Visibility.Hidden;
            }
        }

        private void btPay_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < listCode.Count; i++)
            {
                string sqlStr =  "UPDATE tblHoaDon SET TrangThai = @TrangThaiHoaDonMoi WHERE MaHoaDon = N'" + listCode[i] + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                
                cmd.Parameters.AddWithValue("@TrangThaiHoaDonMoi", "Đã thanh toán");
                cmd.ExecuteNonQuery();

            }
            NapDuLieuHoaDon();
            btnPay.Visibility = Visibility.Hidden;
        }

        private void btSearch_Click(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text == "")
            {
                NapDuLieuHoaDon();
            }
            else
            {
                dgOrder.ItemsSource = null;
                orders.Clear();
                if (Conn.State != ConnectionState.Open) return;
                SqlCommand command = new SqlCommand("SELECT * FROM tblHoaDon WHERE MaHoaDon like '%" + txtSearch.Text.Trim() + "%'", Conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    OrderItem order = new OrderItem();
                    order.IsSelected = false;
                    order.OrderCode = reader.GetString(0);
                    if (reader.IsDBNull(1))
                    {
                        order.EmployeeCode = null;
                    }
                    else
                    {
                        order.EmployeeCode = reader.GetString(1);
                    }
                    
                    order.OrderDate = reader.GetDateTime(2);
                    order.TotalMoney = (float)reader.GetDouble(4);
                    order.OrderTime = reader.GetTimeSpan(3);
                    order.OrderStatus = reader.GetString(5);
                    if (order.OrderCode != "")
                    {
                        orders.Add(order);
                    }
                }
                reader.Close();
                dgOrder.ItemsSource = orders;
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            OrderItem dataRowView = (OrderItem)((Button)e.Source).DataContext;
            OrderDetail orderDetail = new OrderDetail(dataRowView.OrderCode, dataRowView.EmployeeCode, dataRowView.OrderDate, dataRowView.OrderTime, dataRowView.TotalMoney, dataRowView.OrderStatus);
            orderDetail.Show();
        }

        private void ButtonXoa_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Bạn có chắc muốn xóa đơn hàng này này?", "Xác nhận xóa", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                OrderItem dataRowView = (OrderItem)((Button)e.Source).DataContext;

                string sqlStr = "DELETE FROM tblChiTietHoaDon WHERE MaHoaDon =  N'" + dataRowView.OrderCode + "'" +
                    "DELETE FROM tblHoaDon WHERE MaHoaDon = N'" + dataRowView.OrderCode + "'";
                SqlCommand cmd = new SqlCommand(sqlStr, Conn);
                cmd.ExecuteNonQuery();
                NapDuLieuHoaDon();

            }
            else
            {
                return;
            }
            
            
        }

        private void btload_Click(object sender, RoutedEventArgs e)
        {
            NapDuLieuHoaDon();
            txtSearch.Text = string.Empty;
        }

        
    }
}
