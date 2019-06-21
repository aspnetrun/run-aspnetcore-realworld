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
    }
}
