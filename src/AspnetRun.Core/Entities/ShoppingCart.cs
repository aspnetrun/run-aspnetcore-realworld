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
            ShoppingCartDetails = new HashSet<ShoppingCartDetail>();
        }

        public string UserId { get; set; }
        public ICollection<ShoppingCartDetail> ShoppingCartDetails { get; private set; }

        public void AddProductToCart(int productId, decimal unitPrice, short quantity = 1, decimal? discount = 0)
        {
            if (!ShoppingCartDetails.Any(i => i.ProductId == productId))
            {
                ShoppingCartDetails.Add(new ShoppingCartDetail()
                {
                    ProductId = productId,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    Discount = discount
                });
                return;
            }
            var existingItem = ShoppingCartDetails.FirstOrDefault(i => i.ProductId == productId);
            existingItem.Quantity += quantity;
        }
    }
}
