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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sieu_thi_mini.View
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : UserControl
    {
        string ConnectionString = App.ConnectionString;
        string manv = App.MaDangNhapService.MaDangNhap;
        public Setting()
        {
            InitializeComponent();
        }
        private void HienThi()
        {
            //if(manv == "admin")
            //{
            //    //select all database  
            //}
            //else
            //{
            //    //select * from tblNhanVien where MaNhanVien = mavv;
                
            //}
        }
    }
}
