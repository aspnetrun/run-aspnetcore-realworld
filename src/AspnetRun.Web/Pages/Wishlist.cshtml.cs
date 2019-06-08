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

        public void OnGet()
        {
        }
    }
}