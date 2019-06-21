using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
    }
}
