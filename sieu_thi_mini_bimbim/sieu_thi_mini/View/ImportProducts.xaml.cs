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
    /// Interaction logic for ImportProducts.xaml
    /// </summary>
    public partial class ImportProducts : UserControl
    {
        string ConnectionString = App.ConnectionString;
        public ImportProducts()
        {
            InitializeComponent();
        }
    }
}
