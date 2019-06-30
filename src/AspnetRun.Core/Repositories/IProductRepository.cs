using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetProductListAsync();
        Task<Product> GetProductBySlug(string slug);
        Task<IEnumerable<Product>> GetProductByNameAsync(string productName);
        Task<Product> GetProductByIdWithCategoryAsync(int productId);
        Task<IEnumerable<Product>> GetProductByCategoryAsync(int categoryId);        
    }
}
