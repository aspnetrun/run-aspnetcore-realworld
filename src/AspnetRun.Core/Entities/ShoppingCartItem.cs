using AspnetRun.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal? Discount { get; set; }
        public int ProductId { get; set; }

        public void IncrementQuantity(int increment)
        {
            Quantity = Quantity + increment;
        }

        public void DecreaseQuantity(int decrease)
        {
            if (Quantity <= decrease)
                throw new CoreException("Decrease count could not be greater than existing count.");

            Quantity = Quantity - decrease;
        }
    }
}
