using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IIndexPageService _indexPageService;
        private readonly ICartComponentService _cartComponentService;

        public IndexModel(IIndexPageService indexPageService, ICartComponentService cartComponentService) : this(indexPageService)
        {
            _cartComponentService = cartComponentService ?? throw new ArgumentNullException(nameof(cartComponentService));
        }

        public IEnumerable<ProductViewModel> ProductList { get; set; } = new List<ProductViewModel>();
        public CategoryViewModel CategoryModel { get; set; } = new CategoryViewModel();

        public async Task OnGetAsync()
        {
            ProductList = await _indexPageService.GetProducts();              
        }

        public async Task<IActionResult> OnPostRemoveToCartAsync(int cartId, int cartItemId)
        {
            await _cartComponentService.RemoveItem(cartId, cartItemId);
            return RedirectToPage();
        }
    }
}
