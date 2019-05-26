using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class List : Entity
    {        
        [Required, StringLength(80)]
        public string Name { get; set; }        
        public string Description { get; set; }
        public string ImageFile { get; set; }
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
