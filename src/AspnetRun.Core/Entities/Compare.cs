using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Compare : Entity
    {        
        public string UserName { get; set; }
        public List<ProductCompare> ProductCompares { get; set; } = new List<ProductCompare>();

        public void RemoveItem(int productId)
        {
            var removedItem = ProductCompares.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                ProductCompares.Remove(removedItem);
            }
        }
    }
}
