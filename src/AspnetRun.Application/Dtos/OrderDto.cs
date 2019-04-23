using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class OrderDto : BaseDto
    {
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public DateTimeOffset? ShippedDate { get; set; }
        public int? ShipVia { get; set; }
        public decimal? Freight { get; set; }
        //public Address ShippingAddress { get; set; }
        public int CustomerId { get; set; }
    }
}
