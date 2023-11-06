using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sieu_thi_mini.Model;

namespace sieu_thi_mini.ViewModel
{
    class StatisticalVM:Utilities.ViewModelBase
    {
        public Func<double, string> YFormatter
        {
            get
            {
                return value => value.ToString("N0");
            }
        }
    }
}
