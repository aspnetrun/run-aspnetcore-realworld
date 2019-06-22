using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
            if(!User.Identity.IsAuthenticated)
                return RedirectToPage("/Login", new { area = "Identity" });

            await _productPageService.AddToCart(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        {
            await _productPageService.AddToWishlist(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCompareAsync(int productId)
        {
            await _productPageService.AddToCompare(User.Identity.Name, productId);
            return RedirectToPage();
        }
    }
}