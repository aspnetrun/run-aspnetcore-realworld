using AspnetRun.Web.ViewModels.Base;
using System.Collections.Generic;

namespace AspnetRun.Web.ViewModels
{
    public class CompareViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public List<ProductViewModel> Items { get; set; } = new List<ProductViewModel>();
    }
}
