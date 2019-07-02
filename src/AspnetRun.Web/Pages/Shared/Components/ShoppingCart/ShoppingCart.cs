using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Web.Pages.Components.ShoppingCart
{
    public class ShoppingCart : ViewComponent
    {
        private readonly ICartComponentService _cartComponentService;

        public ShoppingCart(ICartComponentService cartComponentService)
        {
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cartViewModel = new CartViewModel();
            if (!User.Identity.IsAuthenticated)
            {
                return View(cartViewModel);
            }

            cartViewModel = await _cartComponentService.GetCart(User.Identity.Name);
            return View(cartViewModel);
        }
    }
}
