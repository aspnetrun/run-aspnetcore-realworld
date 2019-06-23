using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetRun.Web.Pages
{
    [Authorize]
    public class CartModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}