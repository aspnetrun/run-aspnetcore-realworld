using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class OrderDetail : BaseEntity
    {        
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
        //public string ProductName { get; set; }
        //public string PictureUri { get; set; }


        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
