using AspnetRun.Web.ViewModels;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IComparePageService
    {
        Task<CompareViewModel> GetCompare(string userName);
        Task RemoveItem(int compareId, int productId);
        Task AddToCart(string userName, int productId);
    }
}
