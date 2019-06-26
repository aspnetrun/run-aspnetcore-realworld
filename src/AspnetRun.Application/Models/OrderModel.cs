using System.Collections.Generic;

namespace AspnetRun.Application.Models
{
    public class OrderModel
    {
        public string UserName { get; set; }
        public AddressModel BillingAddress { get; set; }
        public AddressModel ShippingAddress { get; set; }
        public PaymentMethodModel PaymentMethod { get; set; }
        public OrderStatusModel Status { get; set; }
        public decimal GrandTotal { get; set; }

        public List<OrderItemModel> Items { get; set; } = new List<OrderItemModel>();
    }
}
