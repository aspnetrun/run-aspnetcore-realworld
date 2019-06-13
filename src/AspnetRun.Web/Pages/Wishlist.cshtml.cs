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

        public WishlistModel(IWishlistPageService wishlistService)
        {
            _wishlistPageService = wishlistService ?? throw new ArgumentNullException(nameof(wishlistService));
        }

        public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        public async Task OnGetAsync()
        {
            var userName = this.User.Identity.Name;
            WishlistViewModel = await _wishlistPageService.GetWishlist(userName);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string userName, int productId)
        {
            await _wishlistPageService.AddToCart(userName, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromWishlistAsync(int wishlistId, int productId)
        {
            await _wishlistPageService.RemoveItem(wishlistId, productId);
            return RedirectToPage();
        }
    }
}