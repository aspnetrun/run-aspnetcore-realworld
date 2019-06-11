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
        private readonly IComparePageService _compareService;

        public CompareModel(IComparePageService CompareService)
        {
            _compareService = CompareService ?? throw new ArgumentNullException(nameof(CompareService));
        }

        public CompareViewModel CompareViewModel { get; set; } = new CompareViewModel();

        public async Task OnGetAsync()
        {
            var userName = this.User.Identity.Name;
            CompareViewModel = await _compareService.GetCompare(userName);
        }

        public async Task<IActionResult> OnPostRemoveFromCompareAsync(int compareId, int productId)
        {
            await _compareService.RemoveItem(compareId, productId);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(string userName, int productId)
        {
            await _compareService.AddToCart(userName, productId);
            return RedirectToPage();
        }
    }
}