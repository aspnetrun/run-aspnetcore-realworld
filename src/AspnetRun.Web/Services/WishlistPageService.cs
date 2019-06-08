using System.Threading.Tasks;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Services
{
    public class WishlistPageService : IWishlistPageService
    {

        public Task<WishlistViewModel> GetWishlist(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
