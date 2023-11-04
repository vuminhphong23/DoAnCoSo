using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sieu_thi_mini.Model;

namespace sieu_thi_mini.ViewModel
{
    class OrderVM : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        

        public OrderVM()
        {
            _pageModel = new PageModel();
            
        }
    }
}
