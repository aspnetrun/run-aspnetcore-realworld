using AspnetRun.Web.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Interfaces
{
    public interface IProductPageService
    {
        Task<IEnumerable<ProductViewModel>> GetProducts(string productName);
        Task<ProductViewModel> GetProductById(int productId);
        Task<IEnumerable<ProductViewModel>> GetProductByCategory(int categoryId);
        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task AddToCart(string userName, int productId);
        Task AddToWishlist(string userName, int productId);
        Task AddToCompare(string userName, int productId);
    }
}
