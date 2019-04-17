using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Product : BaseEntity
    {
        public Product()
        {
        }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public string PictureUri { get; set; }

        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int? BrandId { get; set; }
        public Brand Brand { get; set; }
        public int? SupplierId { get; set; }
        public Supplier Supplier { get; set; }        
    }
}
