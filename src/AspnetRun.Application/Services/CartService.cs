using System.Threading.Tasks;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;

namespace AspnetRun.Application.Services
{
    public class CartService : ICartService
    {
        public Task AddItem(string userName, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CartModel> GetProductByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveItem(int compareId, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
