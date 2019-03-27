using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class ShoppingCartDetail : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
