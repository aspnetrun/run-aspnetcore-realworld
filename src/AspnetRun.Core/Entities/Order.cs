using AspnetRun.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        public Address ShippingAddress { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        
        public ICollection<OrderDetail> OrderDetails { get; private set; }

    }
}
