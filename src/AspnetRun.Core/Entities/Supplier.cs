using AspnetRun.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Supplier : BaseEntity
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
        }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }

        public Address Address { get; set; }
        
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string HomePage { get; set; }

        public ICollection<Product> Products { get; private set; }
    }
}
