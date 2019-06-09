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
        private readonly IWishlistPageService _wishlistService;

        public WishlistModel(IWishlistPageService wishlistService)
        {
            _wishlistService = wishlistService ?? throw new ArgumentNullException(nameof(wishlistService));
        }

        public WishlistViewModel WishlistViewModel { get; set; } = new WishlistViewModel();

        public async Task OnGet()
        {            
            var userName = this.User.Identity.Name;
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