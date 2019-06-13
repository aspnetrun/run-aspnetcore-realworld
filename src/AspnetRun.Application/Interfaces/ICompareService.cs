using AspnetRun.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface ICompareService
    {
        Task<CompareModel> GetProductByUserName(string userName);
        Task AddItem(string userName, int productId);
        Task RemoveItem(int compareId, int productId);        
    }
}
