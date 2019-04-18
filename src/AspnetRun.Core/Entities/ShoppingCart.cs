using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public ShoppingCart()
        {
            Items = new HashSet<ShoppingCartItem>();
        }

        public int UserId { get; set; }
        public ICollection<ShoppingCartItem> Items { get; private set; }

        public void AddItemToCart(int productId, decimal unitPrice, short quantity = 1, decimal? discount = 0)
        {
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return;
            }

            var item = new ShoppingCartItem
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity,
                Discount = discount
            };

            Items.Add(item);
        }

        public ShoppingCartItem GetItem(int productId)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);
            return item;
        }

        public void RemoveItem(int productId)
        {
            var item = Items.FirstOrDefault(x => x.ProductId == productId);
            Items.Remove(item);
        }
    }
}
