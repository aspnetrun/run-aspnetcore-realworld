using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class CheckOutModel : PageModel
    {
        private readonly ICheckOutPageService _checkOutPageService;

        public CheckOutModel(ICheckOutPageService checkOutPageService)
        {
            _checkOutPageService = checkOutPageService ?? throw new ArgumentNullException(nameof(checkOutPageService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();

        public async Task OnGetAsync()
        {
            ProductList = await _productPageService.GetProducts(SearchTerm);
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int productId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToPage("./Account/Login", new { area = "Identity" });

            await _productPageService.AddToCart(User.Identity.Name, productId);
            return RedirectToPage();
        }
    }
}