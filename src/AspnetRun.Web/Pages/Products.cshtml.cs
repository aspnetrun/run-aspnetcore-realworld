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
        private readonly IProductPageService _productPageService;

        public ProductsModel(IProductPageService productService)
        {
            _productPageService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = string.Empty;

        public async Task OnGetAsync()
        {
            ProductList = await _productPageService.GetProducts(SearchTerm);
        }
        
        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            var userName = this.User.Identity.Name;
            //await _productPageService.AddToCart(userName, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        {
            var userName = this.User.Identity.Name;
            //await _productPageService.AddToWishlist(userName, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCompareAsync(int productId)
        {
            var userName = this.User.Identity.Name;
            //await _productPageService.AddToCompare(userName, productId);
            return RedirectToPage();
        }
    }
}