using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sieu_thi_mini.Utilities;
using System.Windows.Input;
using sieu_thi_mini.Properties;

namespace sieu_thi_mini.ViewModel
{
    class NavigationVM:ViewModelBase
    {
        private object _currentView;
        private string _caption;
        private string _icon;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public string Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }
        

        public ICommand HomeCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand EmployeeCommand { get; set; }
        public ICommand StatisticalCommand { get; set; }
        public ICommand SettingCommand { get; set; }
        public ICommand ImportProductCommand { get; set; }


        private void Home(object obj) 
        { 
            CurrentView = new HomeVM();
            Caption = "Trang chủ";
            Icon = "HomeVariant";
        }
        private void Product(object obj)
        {
            CurrentView = new ProductVM();
            Caption = "Sản phẩm";
            Icon = "Sack";
        }
        private void Order(object obj)
        {
            CurrentView = new OrderVM();
            Caption = "Đơn hàng";
            Icon = "OrderBoolAscendingVariant";
        }
        private void Employee(object obj)
        {
            CurrentView = new EmployeeVM();
            Caption = "Nhân viên";
            Icon = "AccountMultipleOutline";
        }
        private void Statistical(object obj)
        {
            CurrentView = new StatisticalVM();
            Caption = "Thống kê";
            Icon = "Finance";
        }
        private void ImportProduct(object obj) 
        {
            CurrentView = new ImportProductVM();
            Caption = "Nhập hàng";
            Icon = "FileImport";
        }
        private void Setting(object obj)
        {
            CurrentView = new SettingVM();
            Caption = "Cài đặt";
            Icon = "CogOutline";
        }


        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ProductsCommand = new RelayCommand(Product);
            OrdersCommand = new RelayCommand(Order);
            EmployeeCommand = new RelayCommand(Employee);
            StatisticalCommand = new RelayCommand(Statistical);
            ImportProductCommand = new RelayCommand(ImportProduct);
            SettingCommand = new RelayCommand(Setting);


            // Startup Page
            CurrentView = new HomeVM();
            Caption = "Trang chủ";
            Icon = "HomeVariant";
        }
        
    }
}
