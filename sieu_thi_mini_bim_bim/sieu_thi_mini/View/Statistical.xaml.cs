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
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing.Chart;
using System.IO;
using LicenseContext = OfficeOpenXml.LicenseContext;

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
                return value => value.ToString("N0")+ "đ";
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
                Labels[i] = "Ngày " + (i + 1).ToString() ; // Months are 1-indexed
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
        private void ExportToExcel(string timeframe, string month, string year)
        {
            int maxItems = (timeframe == "Tháng") ? 31 : 12;
            string[] labels = new string[maxItems];
            //ChartValues<double> values = new ChartValues<double>();
            ChartValues<double> revenueData = new ChartValues<double>();
            //Moi them
            ChartValues<double> inputData = new ChartValues<double>();

            string query = "";


            if (timeframe == "Tháng")
            {
                query += "WITH Sales AS (" +
                        "SELECT DAY(HD.NgayBan) AS Ngay, " +
                        "ISNULL(SUM(TongTien), 0) AS TongDoanhThu " +
                        "FROM tblHoaDon AS HD " +
                        "WHERE YEAR(HD.NgayBan) = " + year + " " +
                        "AND MONTH(HD.NgayBan) = " + month + " " +
                        "GROUP BY DAY(HD.NgayBan) " +
                        "), " +
                        "Purchases AS (" +
                        "SELECT DAY(NH.NgayNhap) AS Ngay, " +
                        "ISNULL(SUM(ISNULL(GiaNhap, 0) * ISNULL(SoLuongNhap, 0)), 0) AS TongNhapHang " +
                        "FROM tblNhapHang AS NH " +
                        "WHERE YEAR(NH.NgayNhap) = " + year + " " +
                        "AND MONTH(NH.NgayNhap) = " + month + " " +
                        "GROUP BY DAY(NH.NgayNhap) " +
                        ") " +
                        "SELECT S.Ngay, " +
                        "S.TongDoanhThu, " +
                        "P.TongNhapHang " +
                        "FROM Sales AS S " +
                        "LEFT JOIN Purchases AS P ON S.Ngay = P.Ngay " +
                        "ORDER BY S.Ngay;";

            }
            else if (timeframe == "Năm")
            {
                query += "WITH Sales AS ( " +
               "SELECT YEAR(HD.NgayBan) AS Nam, " +
               "       MONTH(HD.NgayBan) AS Thang, " +
               "       ISNULL(SUM(TongTien), 0) AS TongDoanhThu " +
               "FROM tblHoaDon AS HD " +
               $"WHERE YEAR(HD.NgayBan) = {year} " +
               "GROUP BY YEAR(HD.NgayBan), MONTH(HD.NgayBan) " +
               "), " +
               "Purchases AS ( " +
               "SELECT YEAR(NH.NgayNhap) AS Nam, " +
               "       MONTH(NH.NgayNhap) AS Thang, " +
               "       ISNULL(SUM(ISNULL(GiaNhap, 0) * ISNULL(SoLuongNhap, 0)), 0) AS TongNhapHang " +
               "FROM tblNhapHang AS NH " +
               $"WHERE YEAR(NH.NgayNhap) = {year} " +
               "GROUP BY YEAR(NH.NgayNhap), MONTH(NH.NgayNhap) " +
               ") " +
               "SELECT " +
               "       S.Thang, " +
               "       S.TongDoanhThu, " +
               "       P.TongNhapHang " +
               "FROM Sales AS S " +
               "LEFT JOIN Purchases AS P ON S.Nam = P.Nam AND S.Thang = P.Thang " +
               "ORDER BY S.Nam, S.Thang;";
            }
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (maxItems == 12)
                {
                    while (maxItems > 0)
                    {
                        labels[maxItems - 1] = "Tháng " + (maxItems).ToString();
                        maxItems--;
                    }
                }
                else if (maxItems == 31)
                {
                    while (maxItems > 0)
                    {
                        labels[maxItems - 1] = "Ngày " + (maxItems).ToString();
                        maxItems--;
                    }
                }


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    double[] tempRevenueValues = new double[labels.Length];
                    double[] tempInputValues = new double[labels.Length];
                    for (int i = 0; i < labels.Length; i++)
                    {
                        tempRevenueValues[i] = 0;
                        tempInputValues[i] = 0;
                    }

                    while (reader.Read())
                    {
                        int index = (timeframe == "Tháng") ? Convert.ToInt32(reader["Ngay"]) : Convert.ToInt32(reader["Thang"]);
                        tempRevenueValues[index - 1] = (reader["TongDoanhThu"] is DBNull) ? 0 : Convert.ToDouble(reader["TongDoanhThu"]);
                        tempInputValues[index - 1] = (reader["TongNhapHang"] is DBNull) ? 0 : Convert.ToDouble(reader["TongNhapHang"]);
                    }
                    revenueData.AddRange(tempRevenueValues);
                    inputData.AddRange(tempInputValues);
                }
            }
            //Excel
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("DataSheet");
                worksheet.Cells[1, 1].Value = "Thời gian";
                worksheet.Cells[1, 2].Value = "Doanh thu";
                worksheet.Cells[1, 3].Value = "Tiền nhập hàng";
                worksheet.Column(1).Width = 10;
                worksheet.Column(2).Width = 20;
                worksheet.Column(3).Width = 20;

                // Add your data to the Excel worksheet
                for (int i = 0; i < labels.Length; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = labels[i];
                    worksheet.Cells[i + 2, 2].Style.Numberformat.Format = "#,##0 \"đ\"";
                    worksheet.Cells[i + 2, 2].Value = revenueData[i];
                    worksheet.Cells[i + 2, 3].Style.Numberformat.Format = "#,##0 \"đ\"";
                    worksheet.Cells[i + 2, 3].Value = inputData[i];
                }


                var chart = worksheet.Drawings.AddChart("Chart", eChartType.ColumnClustered);

                chart.SetPosition(2, 0, 4, 0);
                chart.SetSize(1000, 600);
                chart.Title.Text = name_chart.Text.ToString();

                var dataRange = worksheet.Cells[2, 1, labels.Length + 1, 3];
                var xRange = worksheet.Cells[2, 1, labels.Length + 1, 1];
                var revenueRange = worksheet.Cells[2, 2, labels.Length + 1, 2];
                var inputRange = worksheet.Cells[2, 3, labels.Length + 1, 3];

                var revenueSeries = chart.Series.Add(revenueRange, xRange);
                revenueSeries.Header = "Doanh thu";

                var inputSeries = chart.Series.Add(inputRange, xRange);
                inputSeries.Header = "Tiền nhập hàng";


                var excelFileName = @"E:\C#\sieu_thi_mini\sieu_thi_mini\FileExcel\" + name_chart.Text.ToString() + ".xlsx";
                var file = new FileInfo(excelFileName);
                package.SaveAs(file);
            }
            MessageBox.Show("Xuất file thành công!");
        }
        private void CreateBarChart(string timeframe, string month, string year)
        {
            int maxItems = (timeframe == "Tháng") ? 31 : 12;
            string[] labels = new string[maxItems];
            //ChartValues<double> values = new ChartValues<double>();
            ChartValues<double> revenueData = new ChartValues<double>();

            ChartValues<double> inputData = new ChartValues<double>();

            string query = "";


            if (timeframe == "Tháng")
            {
                query += "WITH Sales AS (" +
                        "SELECT DAY(HD.NgayBan) AS Ngay, " +
                        "ISNULL(SUM(TongTien), 0) AS TongDoanhThu " +
                        "FROM tblHoaDon AS HD " +
                        "WHERE YEAR(HD.NgayBan) = " + year + " " +
                        "AND MONTH(HD.NgayBan) = " + month + " " +
                        "GROUP BY DAY(HD.NgayBan) " +
                        "), " +
                        "Purchases AS (" +
                        "SELECT DAY(NH.NgayNhap) AS Ngay, " +
                        "ISNULL(SUM(ISNULL(GiaNhap, 0) * ISNULL(SoLuongNhap, 0)), 0) AS TongNhapHang " +
                        "FROM tblNhapHang AS NH " +
                        "WHERE YEAR(NH.NgayNhap) = " + year + " " +
                        "AND MONTH(NH.NgayNhap) = " + month + " " +
                        "GROUP BY DAY(NH.NgayNhap) " +
                        ") " +
                        "SELECT S.Ngay, " +
                        "S.TongDoanhThu, " +
                        "P.TongNhapHang " +
                        "FROM Sales AS S " +
                        "LEFT JOIN Purchases AS P ON S.Ngay = P.Ngay " +
                        "ORDER BY S.Ngay;";

            }
            else if (timeframe == "Năm")
            {
                query += "WITH Sales AS ( " +
               "SELECT YEAR(HD.NgayBan) AS Nam, " +
               "       MONTH(HD.NgayBan) AS Thang, " +
               "       ISNULL(SUM(TongTien), 0) AS TongDoanhThu " +
               "FROM tblHoaDon AS HD " +
               $"WHERE YEAR(HD.NgayBan) = {year} " +
               "GROUP BY YEAR(HD.NgayBan), MONTH(HD.NgayBan) " +
               "), " +
               "Purchases AS ( " +
               "SELECT YEAR(NH.NgayNhap) AS Nam, " +
               "       MONTH(NH.NgayNhap) AS Thang, " +
               "       ISNULL(SUM(ISNULL(GiaNhap, 0) * ISNULL(SoLuongNhap, 0)), 0) AS TongNhapHang " +
               "FROM tblNhapHang AS NH " +
               $"WHERE YEAR(NH.NgayNhap) = {year} " +
               "GROUP BY YEAR(NH.NgayNhap), MONTH(NH.NgayNhap) " +
               ") " +
               "SELECT " +
               "       S.Thang, " +
               "       S.TongDoanhThu, " +
               "       P.TongNhapHang " +
               "FROM Sales AS S " +
               "LEFT JOIN Purchases AS P ON S.Nam = P.Nam AND S.Thang = P.Thang " +
               "ORDER BY S.Nam, S.Thang;";
            }




            string yAxisTitle = "Doanh thu";
            string xAxisTitle = (timeframe == "Tháng") ? "Ngày" : "Tháng";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                if (maxItems == 12)
                {
                    while (maxItems > 0)
                    {
                        labels[maxItems - 1] = "Tháng " + (maxItems).ToString();
                        maxItems--;
                    }
                }
                else if (maxItems == 31)
                {
                    while (maxItems > 0)
                    {
                        labels[maxItems - 1] = "Ngày " + (maxItems).ToString();
                        maxItems--;
                    }
                }


                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    double[] tempRevenueValues = new double[labels.Length];
                    double[] tempInputValues = new double[labels.Length];
                    for (int i = 0; i < labels.Length; i++)
                    {
                        tempRevenueValues[i] = 0;
                        tempInputValues[i] = 0;
                    }

                    while (reader.Read())
                    {
                        int index = (timeframe == "Tháng") ? Convert.ToInt32(reader["Ngay"]) : Convert.ToInt32(reader["Thang"]);
                        tempRevenueValues[index - 1] = (reader["TongDoanhThu"] is DBNull) ? 0 : Convert.ToDouble(reader["TongDoanhThu"]);
                        tempInputValues[index - 1] = (reader["TongNhapHang"] is DBNull) ? 0 : Convert.ToDouble(reader["TongNhapHang"]);
                    }
                    revenueData.AddRange(tempRevenueValues);
                    inputData.AddRange(tempInputValues);
                }
            }


            var revenueBarSeries = new ColumnSeries
            {
                Title = "Doanh thu",
                Values = revenueData,
            };


            var inputBarSeries = new ColumnSeries
            {
                Title = "Tiền nhập hàng",
                Values = inputData,
                Fill = Brushes.Red,
            };


            var seriesCollection = new SeriesCollection
            {
                revenueBarSeries,
                inputBarSeries
            };


            BarChart.Series = seriesCollection;
            BarChart.AxisX[0].Labels = labels;
            BarChart.AxisX[0].Title = xAxisTitle;
            BarChart.AxisY[0].Title = yAxisTitle;
            DataContext = this;
        }
        public string Year = DateTime.Now.Year.ToString();
        public string Month = DateTime.Now.Month.ToString();

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
            if (selectedTag == "Năm")
            {
                cmbMonth.IsEnabled = false;
                name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " " + Year.ToString();
            }
            if (selectedTag == "Tháng")
            {
                name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " " + Month.ToString() + "-" + Year.ToString();
            }

            if (cmbMonth.SelectedItem != null && cmbYear.SelectedItem != null)
            {
                name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " "+  Month.ToString() +"-"+Year.ToString();

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
            name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " " + Month.ToString() + "-" + Year.ToString();

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
            if (selectedTag == "Tháng")
            {
                name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " " + Month.ToString() + "-" + Year.ToString();

            }
            else
            {
                name_chart.Text = "Biểu đồ thể hiện doanh thu theo " + selectedTag.ToLower() + " " + Year.ToString();

            }
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
            return (month2 - month1).ToString("N0") + "đ";
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
        private void btexcel_Click(object sender, RoutedEventArgs e)
        {
            ExportToExcel(((ComboBoxItem)TimeframeComboBox.SelectedItem).Content.ToString(), Month, Year);
        }
    }
}