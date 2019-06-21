using AspnetRun.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface ICartService
    {
        Task<CartModel> GetCartByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int productId);
    }
}
