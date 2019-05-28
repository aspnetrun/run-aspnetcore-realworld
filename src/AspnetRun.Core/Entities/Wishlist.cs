using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Wishlist : Entity
    {        
        public string UserName { get; set; }
        public List<ProductWishlist> ProductWishlists { get; set; } = new List<ProductWishlist>();

        //public void AddProduct(Product product)
        //{
        //    if (!Products.Any(p => p.Id == product.Id))
        //    {
        //        Products.Add(product);
        //    }
        //}
    }
}
