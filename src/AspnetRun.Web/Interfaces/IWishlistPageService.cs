using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetRun.Web.ViewModels;

namespace AspnetRun.Web.Interfaces
{
    public interface IWishlistPageService
    {
        Task<WishlistViewModel> GetWishlist(string userName);
        Task RemoveItem(int wishlistId, int productId);
        Task AddToCart(string userName, int productId);
    }
}
