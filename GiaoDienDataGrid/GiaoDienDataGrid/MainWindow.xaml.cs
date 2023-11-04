using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace GiaoDienDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();

            //Create DataGrid Items Info
            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Phong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Phu", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Kien", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Minh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Duc", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "6", Character = "F", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Cuong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "7", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Cong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "8", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Anh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Ha", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "10", Character = "J", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Linh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            //members.Add(new Member { Number = "", Character = "", BgColor = (Brush)converter.ConvertFromString(""), Name = "", Position = "", Email = "", Phone = "" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Phong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Phu", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Kien", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Minh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Duc", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "6", Character = "F", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Cuong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "7", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Cong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "8", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Anh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Ha", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "10", Character = "J", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Linh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });

            members.Add(new Member { Number = "1", Character = "A", BgColor = (Brush)converter.ConvertFromString("#1098ad"), Name = "Phong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "2", Character = "B", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Phu", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "3", Character = "C", BgColor = (Brush)converter.ConvertFromString("#ff8f00"), Name = "Kien", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "4", Character = "D", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Minh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "5", Character = "E", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Duc", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "6", Character = "F", BgColor = (Brush)converter.ConvertFromString("#6741d9"), Name = "Cuong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "7", Character = "G", BgColor = (Brush)converter.ConvertFromString("#ff6d00"), Name = "Cong", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "8", Character = "H", BgColor = (Brush)converter.ConvertFromString("#ff5252"), Name = "Anh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "9", Character = "K", BgColor = (Brush)converter.ConvertFromString("#1e88e5"), Name = "Ha", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
            members.Add(new Member { Number = "10", Character = "J", BgColor = (Brush)converter.ConvertFromString("#0ca678"), Name = "Linh", Position = "Coach", Email = "abc@gmail.com", Phone = "0123" });
       
            dgMembers.ItemsSource = members;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private bool IsMaximized = false;
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Minimized;
                    IsMaximized = true;
                }
            }
        }
    }

    public class Member
    {
        public string Character { get; set; }
        public string Number { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Brush BgColor{ get; set; }

    }
}
