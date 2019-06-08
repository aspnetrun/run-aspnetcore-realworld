using AspnetRun.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IWishListService
    {
        Task<WishlistModel> GetProductByUserName(string userName);
    }
}
