using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class ProductsModel : PageModel
    {
        private readonly IProductPageService _productService;

        public ProductsModel(IProductPageService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            ProductList = await _productService.GetProducts(SearchTerm);
        }              
    }
}