using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Wishlist
    {        
        public string UserName { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

        public void AddProduct(Product product)
        {
            if (!Products.Any(p => p.Id == product.Id))
            {
                Products.Add(product);
            }
        }
    }
}
