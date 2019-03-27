using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Brand
    {
        public Brand()
        {
            Products = new HashSet<Product>();
        }

        public string BrandName { get; set; }
        public string Description { get; set; }        
        public ICollection<Product> Products { get; private set; }
    }
}
