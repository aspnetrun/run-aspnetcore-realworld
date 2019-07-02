using System;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    [Authorize]
    public class CompareModel : PageModel
    {
        private readonly IComparePageService _comparePageService;
        private readonly ICartComponentService _cartComponentService;

        public CompareModel(IComparePageService comparePageService, ICartComponentService cartComponentService)
        {
            _comparePageService = comparePageService ?? throw new ArgumentNullException(nameof(comparePageService));
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public CompareViewModel CompareViewModel { get; set; } = new CompareViewModel();

        public async Task OnGetAsync()
        {
            var userName = this.User.Identity.Name;
            CompareViewModel = await _comparePageService.GetCompare(userName);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string userName, int productId)
        {
            await _comparePageService.AddToCart(userName, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveFromCompareAsync(int compareId, int productId)
        {
            await _comparePageService.RemoveItem(compareId, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }
    }
}