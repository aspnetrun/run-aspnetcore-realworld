using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Category : BaseEntity
    {
        public Category()
        {            
        }

        public string CategoryName { get; set; }
        public string Description { get; set; }        

        public static Category Create(int categoryId, string name, string description = null)
        {
            var category = new Category
            {
                Id = categoryId,
                CategoryName = name,
                Description = description
            };
            return category;
        }        
    }
}
