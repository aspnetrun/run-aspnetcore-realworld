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
            ShoppingCartItems = new HashSet<ShoppingCartItem>();
        }

        public string UserId { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; private set; }

        public void AddProductToCart(int productId, decimal unitPrice, short quantity = 1, decimal? discount = 0)
        {
            var existingItem = ShoppingCartItems.FirstOrDefault(i => i.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                return;
            }

            ShoppingCartItems.Add(new ShoppingCartItem()
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity,
                Discount = discount
            });            
        }
    }
}
