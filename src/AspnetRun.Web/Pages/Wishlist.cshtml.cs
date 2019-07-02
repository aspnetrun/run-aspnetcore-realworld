using System;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace AspnetRun.Web.Pages
{
    [Authorize]
    public class WishlistModel : PageModel
    {
        private readonly IWishlistPageService _wishlistPageService;
        private readonly ICartComponentService _cartComponentService;

        public WishlistModel(IWishlistPageService wishlistPageService, ICartComponentService cartComponentService)
        {
            _wishlistPageService = wishlistPageService ?? throw new ArgumentNullException(nameof(wishlistPageService));
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        public async Task OnGetAsync()
        {
            var userName = this.User.Identity.Name;
            WishlistViewModel = await _wishlistPageService.GetWishlist(userName);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            await _wishlistPageService.AddToCart(User.Identity.Name, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromWishlistAsync(int wishlistId, int productId)
        {
            await _wishlistPageService.RemoveItem(wishlistId, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }
    }
}