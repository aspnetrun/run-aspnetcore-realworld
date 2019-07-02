using System;
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
        private readonly ICartComponentService _cartComponentService;

        public ProductDetailModel(IProductPageService productPageService, ICartComponentService cartComponentService)
        {
            _productPageService = productPageService ?? throw new ArgumentNullException(nameof(productPageService));
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public ProductViewModel Product { get; set; } = new ProductViewModel();
        
        public async Task OnGetAsync(string slug)
        {
            Product = await _productPageService.GetProductBySlug(slug);
            TempData["Slug"] = slug;
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToCart(User.Identity.Name, productId);            
            return RedirectToPage(new { slug = TempData["Slug"].ToString() });            
        }

        public async Task<IActionResult> OnPostAddToWishlistAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToWishlist(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCompareAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToCompare(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }
    }
}