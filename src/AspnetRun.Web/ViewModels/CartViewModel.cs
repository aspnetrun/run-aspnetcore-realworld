using AspnetRun.Web.ViewModels.Base;
using System.Collections.Generic;

namespace AspnetRun.Web.ViewModels
{
    public class CartViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
    }
}
