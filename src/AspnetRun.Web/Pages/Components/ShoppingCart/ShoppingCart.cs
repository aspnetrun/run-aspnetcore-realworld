using AspnetRun.Web.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Web.Pages.Components.ShoppingCart
{
    public class ShoppingCart : ViewComponent
    {
        private readonly ICartPageService  _cartPageService;

        public ShoppingCart(ICartPageService cartPageService)
        {
            _cartPageService = cartPageService ?? throw new ArgumentNullException(nameof(cartPageService));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartViewModel = await _cartPageService.GetCart(User.Identity.Name);
            return View(cartViewModel);
        }



        //public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        //public async Task OnGetAsync()
        //{
        //    var userName = this.User.Identity.Name;
        //    WishlistViewModel = await _wishlistPageService.GetWishlist(userName);
        //}

        //public async Task<IActionResult> OnPostAddToCartAsync(string userName, int productId)
        //{
        //    await _wishlistPageService.AddToCart(userName, productId);
        //    return RedirectToPage();
        //}

        //public async Task<IActionResult> OnPostRemoveFromWishlistAsync(int wishlistId, int productId)
        //{
        //    await _wishlistPageService.RemoveItem(wishlistId, productId);
        //    return RedirectToPage();
        //}
    }
}
