using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly IProductPageService _productPageService;

        public ProductDetailModel(IProductPageService productService)
        {
            _productPageService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        public ProductViewModel Product { get; set; } = new ProductViewModel();        

        public async Task OnGetAsync()
        {
            //Product = await _productPageService.GetProducts(SearchTerm);
        }

        //public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //        return RedirectToPage("./Account/Login", new { area = "Identity" });

        //    await _productPageService.AddToCart(User.Identity.Name, productId);
        //    return RedirectToPage();
        //}

        //public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //        return RedirectToPage("./Account/Login", new { area = "Identity" });

        //    await _productPageService.AddToWishlist(User.Identity.Name, productId);
        //    return RedirectToPage();
        //}

        //public async Task<IActionResult> OnPostAddToCompareAsync(int productId)
        //{
        //    if (!User.Identity.IsAuthenticated)
        //        return RedirectToPage("./Account/Login", new { area = "Identity" });

        //    await _productPageService.AddToCompare(User.Identity.Name, productId);
        //    return RedirectToPage();
        //}


    }
}