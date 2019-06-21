using AspnetRun.Web.ViewModels;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface ICartPageService
    {
        Task<CartViewModel> GetCart(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int cartId, int productId);
    }
}
