using AspnetRun.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Cart : Entity
    {
        public Cart()
        {
            Products = new HashSet<Product>();
        }

        [Required, StringLength(80)]
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public ICollection<Product> Products { get; private set; }

        public void AddProduct(Product product)
        {
            if (!Products.Any(p => p.Id == product.Id))
            {
                Products.Add(product);
            }
        }
    }
}
