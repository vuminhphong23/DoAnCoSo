using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for MainWindowEmployee.xaml
    /// </summary>
    public partial class MainWindowEmployee : Window
    {
        string ConnectionString = App.ConnectionString;
        string tennv = "";
        string manv = "";
        public MainWindowEmployee(string manv, string tennv)
        {
            InitializeComponent();
            App.MaDangNhapService.MaDangNhap = manv;
            this.tennv = tennv;
            this.manv = manv;

        }

        private void btLogOut_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            txtMaNV.Text = this.manv.ToUpper();
            txtTenNV.Text = this.tennv.ToUpper();
        }
    }
}
