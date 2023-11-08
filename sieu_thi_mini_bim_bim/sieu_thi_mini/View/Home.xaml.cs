using System;
using System.Collections.Generic;
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
using LiveCharts;
using LiveCharts.Wpf;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace sieu_thi_mini.View
{
    public partial class Home : UserControl
    {
        public Home()
        {
            InitializeComponent();

        }

        SqlConnection Conn = new SqlConnection();
        public Func<double, string> YFormatter
        {
            get
            {
                return value => value.ToString("N0") + " đ";
            }
        }
        public class Invoice
        {
            public string InvoiceNumber { get; set; }
            public string employeeNumber { get; set; }

            public DateTime Date { get; set; }
            public float Amount { get; set; }
            // Các thuộc tính khác của hóa đơn (nếu có)
        }
        List<Invoice> recentInvoices = new List<Invoice>();

        public SeriesCollection LineChartSeriesCollection { get; set; }
        public SeriesCollection ColumnChartSeriesCollection { get; set; }
        public SeriesCollection PieChartSeriesCollection { get; set; }
        public string[] Labels { get; set; }

        private void piechart()
        {
            string sqlstr = "SELECT TOP 5 " +
    "    CTHD.MaSanPham, " +
    "    SP.TenSanPham, " +
    "    SUM(CTHD.SoLuong) AS SoLuongBan " +
    "FROM tblChiTietHoaDon AS CTHD " +
    "JOIN tblSanPham AS SP ON CTHD.MaSanPham = SP.MaSanPham " +
    "JOIN tblHoaDon AS HD ON CTHD.MaHoaDon = HD.MaHoaDon " +
    "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
    "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
    "  AND DAY(HD.NgayBan) = DAY(GETDATE()) " +
    "GROUP BY CTHD.MaSanPham, SP.TenSanPham " +
    "ORDER BY SoLuongBan DESC;";

            if (Conn.State != ConnectionState.Open) return;

            ChartValues<int> quantities = new ChartValues<int>();
            List<string> productNames = new List<string>();
            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                productNames.Add(reader["TenSanPham"].ToString());
                quantities.Add(Convert.ToInt32(reader["SoLuongBan"]));
            }
            reader.Close();

            PieChart myPieChart = this.PieChart;
            SeriesCollection PieSeriesCollection = new SeriesCollection();

            for (int i = 0; i < productNames.Count; i++)
            {
                PieSeriesCollection.Add(new PieSeries
                {
                    Title = productNames[i],
                    Values = new ChartValues<int> { quantities[i] },
                    DataLabels = true,
                });
            }
            myPieChart.LegendLocation = LegendLocation.Right;
            myPieChart.Series = PieSeriesCollection;
        }

        private void linechart()
        {
            

            SeriesCollection LineSeriesCollection = new SeriesCollection();
            Labels = new string[24];

            if (Conn.State != ConnectionState.Open) return;

            // Khởi tạo mảng hoaDonData chứa số hóa đơn của mỗi giờ và điền vào mảng Labels
            ChartValues<int> hoaDonData = new ChartValues<int>();
            for (int i = 1; i <= 24; i++)
            {
                Labels[i-1] = i.ToString() +"h";
                hoaDonData.Add(0); // Ban đầu, số hóa đơn của mỗi giờ là 0
            }

            string sqlstr = "SELECT DATEPART(HOUR, [GioBan]) AS [GioBan], COUNT(*) AS [SoLuongHoaDon] " +
                  "FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
                  "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
                  "  AND DAY(HD.NgayBan) = DAY(GETDATE()) " +
                  "GROUP BY DATEPART(HOUR, [GioBan]) " +
                  "ORDER BY [GioBan];";

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng hoaDonData
            while (reader.Read())
            {
                int gioBan = reader.GetInt32(0);
                int soLuongHoaDon = reader.GetInt32(1);

                hoaDonData[gioBan - 1] = soLuongHoaDon;
            }

            reader.Close();

            // Tạo LineSeries và thêm nó vào SeriesCollection
            LineSeriesCollection.Add(new LineSeries
            {
                Title = "Số Hóa Đơn Bán",
                Values = hoaDonData,
                PointGeometry = DefaultGeometries.Circle, // Loại điểm nhấn (có thể sử dụng DefaultGeometries.Cross, DefaultGeometries.Square, v.v.)
                PointGeometrySize = 5, // Kích thước của điểm nhấn
                StrokeThickness = 2
            });

            // Đặt dữ liệu và labels cho biểu đồ
            lineChart.Series = LineSeriesCollection;
            DataContext = this;

        }
        private void columnchart()
        {
            // Khai báo SeriesCollection và Labels
            SeriesCollection columnSeriesCollection = new SeriesCollection();
            Labels = new string[24];

            if (Conn.State != ConnectionState.Open) return;

            // Khởi tạo mảng doanhThuData chứa doanh thu của mỗi giờ và điền vào mảng Labels
            ChartValues<double> doanhThuData = new ChartValues<double>();
            for (int i = 1; i <= 24; i++)
            {
                Labels[i-1] = i.ToString() +"h";
                doanhThuData.Add(0); // Ban đầu, doanh thu của mỗi giờ là 0
            }

            // Tạo câu lệnh SQL để lấy doanh thu mỗi giờ
            string sqlstr = "SELECT DATEPART(HOUR, [GioBan]) AS [GioBan], SUM([TongTien]) AS [DoanhThu] " +
                  "FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
                  "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
                  "  AND DAY(HD.NgayBan) = DAY(GETDATE()) " +
                  "GROUP BY DATEPART(HOUR, [GioBan]) " +
                  "ORDER BY [GioBan];";

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            while (reader.Read())
            {
                int gioBan = reader.GetInt32(0);
                double doanhThu = reader.GetDouble(1);

                doanhThuData[gioBan - 1] = doanhThu;
            }

            reader.Close();

            // Tạo ColumnSeries và thêm nó vào SeriesCollection
            columnSeriesCollection.Add(new ColumnSeries
            {
                Title = "Doanh Thu",
                Values = doanhThuData,
                MaxColumnWidth = 20, // Điều chỉnh kích thước của cột
            });

            // Đặt dữ liệu và labels cho biểu đồ
            columnChart.Series = columnSeriesCollection;
            DataContext = this;
        }

        private int getProductCount()
        {
            int count = 0;
            string sqlstr = "SELECT SUM(SoLuong) AS SoLuongSanPhamBanRa FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
               "INNER JOIN [QuanLySieuThi].[dbo].[tblChiTietHoaDon] AS CTHD " +
               "ON HD.MaHoaDon = CTHD.MaHoaDon " +
               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
                  "  AND DAY(HD.NgayBan) = DAY(GETDATE()) ";

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader.HasRows)
            {
                reader.Read(); // Đọc hàng đầu tiên
                if (!reader.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    count = reader.GetInt32(0);
                }
            }

            reader.Close();
            return count;
        }
        private int getOrderCount()
        {
            int count = 0;
            string sqlstr = "SELECT COUNT(*) AS SoLuongHoaDon FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
                  "  AND DAY(HD.NgayBan) = DAY(GETDATE()) ";

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader.HasRows)
            {
                reader.Read(); // Đọc hàng đầu tiên
                if (!reader.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    count = reader.GetInt32(0);
                }
            }

            reader.Close();
            return count;
        }
        private string getMoneyDay()
        {
            string money = null;
            string sqlstr = "SELECT SUM(TongTien) AS TongDoanhThu FROM tblHoaDon AS HD " +
               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) " +
                  "  AND DAY(HD.NgayBan) = DAY(GETDATE()) ";

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader.HasRows)
            {
                reader.Read(); // Đọc hàng đầu tiên
                if (!reader.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    double a = reader.GetDouble(0);
                    money = a.ToString("N0");
                }
            }
            

            reader.Close();
            return money;
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                Conn.ConnectionString = App.ConnectionString;
                Conn.Open();
                piechart();
                linechart();
                columnchart();
                countProduct.Content = getProductCount();
                countOrder.Content = getOrderCount();
                moneyDay.Content = getMoneyDay() + "đ";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }
        private void ListBox_Loaded(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(App.ConnectionString))
            {
                connection.Open();

                string query = "SELECT TOP 10 MaHoaDon,MaNhanVien,NgayBan,TongTien FROM tblHoaDon WHERE DAY(NgayBan) = DAY(GETDATE()) AND MONTH(NgayBan) = MONTH(GETDATE()) AND YEAR(NgayBan) = YEAR(GETDATE()) ORDER BY MaHoaDon DESC";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Invoice invoice = new Invoice();
                    invoice.InvoiceNumber = reader.GetString(0);
                    invoice.employeeNumber = "Nhân viên: " + reader.GetString(1);
                    invoice.Date = reader.GetDateTime(2);
                    invoice.Amount = (float)reader.GetDouble(3);

                    recentInvoices.Add(invoice);
                }
                lbHoaDon.ItemsSource = recentInvoices;
                reader.Close();
            }

        }
    }
}
