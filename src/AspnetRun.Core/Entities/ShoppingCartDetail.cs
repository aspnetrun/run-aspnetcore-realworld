using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class ShoppingCartItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal? Discount { get; set; }

        public int ProductId { get; set; }        
    }
}
