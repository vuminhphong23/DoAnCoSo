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
using LiveCharts;
using LiveCharts.Wpf;
using System.Collections.ObjectModel;
using LiveCharts.Defaults;
using System.ComponentModel;
using LiveCharts.Configurations;
using System.Globalization;
using System.Runtime.InteropServices.WindowsRuntime;

namespace sieu_thi_mini.View
{
    /// <summary>
    /// Interaction logic for Statistical.xaml
    /// </summary>
    public partial class Statistical : UserControl
    {

        public Statistical()
        {
            InitializeComponent();
            
        }

        public SeriesCollection SeriesCollection { get; set; }

        public string[] Labels { get; set; }

        public Func<double, string> YFormatter
        {
            get
            {
                return value => value.ToString("N0");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        SqlConnection Conn = new SqlConnection();
        string ConnectionString = App.ConnectionString;



        private void CreateStackedAreaChart()
        {
            SeriesCollection = new SeriesCollection();
            Labels = new string[12];

            // Initialize the Labels array with month names
            for (int i = 0; i < 12; i++)
            {
                Labels[i] = (i + 1).ToString(); // Months are 1-indexed
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT DATEPART(MONTH, HD.NgayBan) AS Thang, SP.PhanLoai, SUM(CTHD.SoLuong) AS SoLuongBan " +
                               "FROM tblHoaDon AS HD " +
                               "JOIN tblChiTietHoaDon AS CTHD ON HD.MaHoaDon = CTHD.MaHoaDon " +
                               "JOIN tblSanPham AS SP ON CTHD.MaSanPham = SP.MaSanPham " +
                               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                               "GROUP BY DATEPART(MONTH, HD.NgayBan), SP.PhanLoai " +
                               "ORDER BY Thang, SP.PhanLoai";

                SqlCommand cmd = new SqlCommand(query, connection);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    var seriesData = new Dictionary<string, ChartValues<double>>();

                    while (reader.Read())
                    {
                        int month = Convert.ToInt32(reader["Thang"]);
                        string category = reader["PhanLoai"].ToString();
                        double quantity = Convert.ToDouble(reader["SoLuongBan"]);

                        if (!seriesData.ContainsKey(category))
                        {
                            seriesData[category] = new ChartValues<double>(new double[12]);
                        }

                        // Update the value for the current month in the corresponding category
                        seriesData[category][month - 1] = quantity;
                    }

                    // Create StackedAreaSeries for each category
                    foreach (var kvp in seriesData)
                    {
                        var series = new StackedAreaSeries
                        {
                            Title = kvp.Key,
                            Values = kvp.Value,
                            LineSmoothness = 0
                        };

                        SeriesCollection.Add(series);
                    }
                }
            }

            DataContext = this;
        }




        private void piechart2()
        {
            string sqlstr = "SELECT TOP 5 [MaSanPham], [TenSanPham], SUM([SoLuong]) AS [TongSoLuong] " +
                 "FROM [tblChiTietHoaDon] " +
                 "GROUP BY [MaSanPham], [TenSanPham] " +
                 "ORDER BY [TongSoLuong] DESC;";

            if (Conn.State != ConnectionState.Open) return;

            ChartValues<int> quantities = new ChartValues<int>();
            List<string> productNames = new List<string>();
            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                productNames.Add(reader["TenSanPham"].ToString());
                quantities.Add(Convert.ToInt32(reader["TongSoLuong"]));
            }
            reader.Close();

            PieChart myPieChart = this.PieChart2;
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                
                Conn.ConnectionString = ConnectionString;
                Conn.Open();
                CreateStackedAreaChart();
                piechart2();
                defaultcmb();
                doanhthu.Content = GetSale();
                GetEmployeeStar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi mở kết nối" + ex.ToString());
            }
        }

        private void defaultcmb()
        {
            cmbMonth.IsEnabled = false;
            cmbYear.IsEnabled = false;
            cmbYear.SelectedItem = null;
            cmbMonth.SelectedItem = null;
        }
        private void CreateBarChart(string timeframe, string month, string year)
        {
            int maxItems = (timeframe == "Tháng") ? 31 : 12;
            string[] labels = new string[maxItems];
            ChartValues<double> values = new ChartValues<double>();
            string yAxisTitle = "Doanh thu";
            string xAxisTitle = (timeframe == "Tháng") ? "Ngày" : "Tháng";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT SUM(TongTien) AS Revenue, ";

                if (timeframe == "Tháng")
                {
                    query += "DAY(NgayBan) AS Day ";
                }
                else if (timeframe == "Năm")
                {
                    query += "MONTH(NgayBan) AS Month ";
                }

                query += "FROM tblHoaDon " +
                         "WHERE YEAR(NgayBan) = N'" + year +"' AND MONTH(NgayBan) = N'"+ month+
                         "' GROUP BY ";

                if (timeframe == "Tháng")
                {
                    query += "DAY(NgayBan) ";
                }
                else if (timeframe == "Năm")
                {
                    query += "MONTH(NgayBan) ";
                }

                query += "ORDER BY ";

                if (timeframe == "Tháng")
                {
                    query += "DAY(NgayBan) ";
                }
                else if (timeframe == "Năm")
                {
                    query += "MONTH(NgayBan) ";
                }

                SqlCommand cmd = new SqlCommand(query, connection);

                while (maxItems > 0)
                {
                    labels[maxItems - 1] = (maxItems).ToString();
                    maxItems--;
                }

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    double[] tempValues = new double[labels.Length];
                    for (int i = 0; i < labels.Length; i++)
                    {
                        tempValues[i] = 0;
                    }

                    while (reader.Read())
                    {
                        int index = (timeframe == "Tháng") ? Convert.ToInt32(reader["Day"]) : Convert.ToInt32(reader["Month"]);
                        tempValues[index - 1] = Convert.ToDouble(reader["Revenue"]);
                    }
                    values.AddRange(tempValues);
                }
            }

            // Create a new bar series and add it to the bar chart
            var barSeries = new ColumnSeries
            {
                Title = yAxisTitle,
                Values = values,
            };

            // Create a SeriesCollection and add the bar series
            var seriesCollection = new SeriesCollection
    {
        barSeries
    };

            // Set the SeriesCollection and labels to your bar chart
            BarChart.Series = seriesCollection;
            BarChart.AxisX[0].Labels = labels;
            BarChart.AxisX[0].Title = xAxisTitle; // Thay đổi tiêu đề trục X
            BarChart.AxisY[0].Title = yAxisTitle; // Thay đổi tiêu đề trục Y
            DataContext = this;
        }
        public string Year = DateTime.Now.Year.ToString();
        public string Month= DateTime.Now.Month.ToString();

        private void TimeframeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            defaultcmb();
            cmbMonth.IsEnabled = true;
            cmbYear.IsEnabled = true;
            Year = DateTime.Now.Year.ToString();
            Month = DateTime.Now.Month.ToString();
            if (TimeframeComboBox.SelectedItem == null)
                return;

            ComboBoxItem selectedTimeframe = (ComboBoxItem)TimeframeComboBox.SelectedItem;
            string selectedTag = selectedTimeframe.Content.ToString();
            if(selectedTag == "Năm"){
                cmbMonth.IsEnabled = false;
            }    
            
            if (cmbMonth.SelectedItem != null && cmbYear.SelectedItem!= null)
            {
                ComboBoxItem selectedMonth = (ComboBoxItem)cmbMonth.SelectedItem;
                string selectedTag2 = selectedMonth.Content.ToString();

                ComboBoxItem selectedYear = (ComboBoxItem)cmbYear.SelectedItem;
                string selectedTag3 = selectedYear.Content.ToString();
                Month = selectedTag2;
                Year = selectedTag3;
            }
            CreateBarChart(selectedTag, Month, Year);
        }
        private void cmbMonth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMonth.SelectedItem == null)
            {
                
                return;
            }

            ComboBoxItem selectedTimeframe = (ComboBoxItem)TimeframeComboBox.SelectedItem;
            string selectedTag = selectedTimeframe.Content.ToString();

            ComboBoxItem selectedMonth = (ComboBoxItem)cmbMonth.SelectedItem;
            string selectedTag2 = selectedMonth.Content.ToString();
            if (cmbYear.SelectedItem != null)
            {
                ComboBoxItem selectedYear = (ComboBoxItem)cmbYear.SelectedItem;
                string selectedTag3 = selectedYear.Content.ToString();
                Year = selectedTag3;

            }

            Month = selectedTag2;
            CreateBarChart(selectedTag, Month, Year);


        }

        private void cmbYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbYear.SelectedItem == null)
            {

                return;
            }

            ComboBoxItem selectedTimeframe = (ComboBoxItem)TimeframeComboBox.SelectedItem;
            string selectedTag = selectedTimeframe.Content.ToString();

            if (cmbMonth.SelectedItem != null)
            {
                ComboBoxItem selectedMonth = (ComboBoxItem)cmbMonth.SelectedItem;
                string selectedTag2 = selectedMonth.Content.ToString();
                Month = selectedTag2;

            }
            

            ComboBoxItem selectedYear = (ComboBoxItem)cmbYear.SelectedItem;
            string selectedTag3 = selectedYear.Content.ToString();
            
            Year = selectedTag3;

            CreateBarChart(selectedTag, Month, Year);

        }
        private string GetSale()
        {
            double month1 = 0;
            double month2 = 0;
            string sqlstr = "SELECT SUM(TongTien) AS TongDoanhThu FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(DATEADD(MONTH,-1,GETDATE())) ";
                  

            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader.HasRows)
            {
                reader.Read(); // Đọc hàng đầu tiên
                if (!reader.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    month1 = reader.GetDouble(0);
                }
            }
            reader.Close();

            string sqlstr2 = "SELECT SUM(TongTien) AS TongDoanhThu FROM [QuanLySieuThi].[dbo].[tblHoaDon] AS HD " +
               "WHERE YEAR(HD.NgayBan) = YEAR(GETDATE()) " +
                  "  AND MONTH(HD.NgayBan) = MONTH(GETDATE()) ";


            SqlCommand command2 = new SqlCommand(sqlstr2, Conn);
            SqlDataReader reader2 = command2.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader2.HasRows)
            {
                reader2.Read(); // Đọc hàng đầu tiên
                if (!reader2.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    month2 = reader2.GetDouble(0);
                }
            }

            reader2.Close();
            return (month2 - month1).ToString("N0") +"đ";
        }

        private void GetEmployeeStar()
        {
            string manv = null;
            string tennv = null;

            string sqlstr = "SELECT TOP 1 NV.MaNhanVien, NV.HoTen, COUNT(HD.MaHoaDon) AS SoLuongDonHang " +
                  "FROM [QuanLySieuThi].[dbo].[tblNhanVien] AS NV " +
                  "JOIN [QuanLySieuThi].[dbo].[tblHoaDon] AS HD ON NV.MaNhanVien = HD.MaNhanVien " +
                  "GROUP BY NV.MaNhanVien, NV.HoTen " +
                  "ORDER BY SoLuongDonHang DESC ";


            SqlCommand command = new SqlCommand(sqlstr, Conn);
            SqlDataReader reader = command.ExecuteReader();

            // Điền dữ liệu từ cơ sở dữ liệu vào mảng doanhThuData
            if (reader.HasRows)
            {
                reader.Read(); // Đọc hàng đầu tiên
                if (!reader.IsDBNull(0)) // Kiểm tra giá trị trong cột có là null hay không
                {
                    manv = reader.GetString(0);
                    tennv = reader.GetString(1);
                }
            }
            reader.Close();

            idEmployee.Content = manv;
            nameEmployee.Content = tennv;
        }
    }
}
