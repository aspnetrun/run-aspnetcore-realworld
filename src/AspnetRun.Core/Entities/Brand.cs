using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Brand : BaseEntity
    {
        public Brand()
        {            
        }

        public string BrandName { get; set; }
        public string Description { get; set; }

        public static Brand Create(int brandId, string name, string description = null)
        {
            var brand = new Brand
            {
                Id = brandId,
                BrandName = name,
                Description = description
            };
            return brand;
        }
    }
}
