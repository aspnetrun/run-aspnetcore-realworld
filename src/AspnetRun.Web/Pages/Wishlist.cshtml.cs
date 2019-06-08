using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
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


        public async Task OnGet()
        {
            var wishlistId = GetWishlistId(slug);
            WishlistViewModel = await _wishlistService.GetWishlist(wishlistId);
        }
    }
}