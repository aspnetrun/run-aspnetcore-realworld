using AspnetRun.Core.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AspnetRun.Core.Entities
{
    public class Cart : Entity
    {        
        public string UserName { get; set; }
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(int productId, int quantity, string color)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                Items.Add(
                    new CartItem()
                    {
                        ProductId = productId,
                        Quantity = quantity,
                        Color = color
                    });
            }
        }
        public void RemoveItem(int productId)
        {
            var removedItem = Items.FirstOrDefault(x => x.ProductId == productId);
            if (removedItem != null)
            {
                Items.Remove(removedItem);
            }
        }
    }
}
