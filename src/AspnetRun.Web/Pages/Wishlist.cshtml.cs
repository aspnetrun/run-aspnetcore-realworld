using System;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class WishlistModel : PageModel
    {
        private readonly IWishlistPageService _wishlistService;

        public WishlistModel(IWishlistPageService wishlistService)
        {
            _wishlistService = wishlistService ?? throw new ArgumentNullException(nameof(wishlistService));
        }

        public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        public async Task OnGet(string userName)
        {
            // TODO : remove this
            userName = "mehmetozkaya";
            WishlistViewModel = await _wishlistService.GetWishlist(userName);
        }

        public async Task<IActionResult> OnPostRemoveFromWishlist(int wishlistId, int productId)
        {
            await _wishlistService.RemoveItem(wishlistId, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCart(string userName, int productId)
        {
            await _wishlistService.AddToCart(userName, productId);
            return RedirectToPage();
        }
    }
}