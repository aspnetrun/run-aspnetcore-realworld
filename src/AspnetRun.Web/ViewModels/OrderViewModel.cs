using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Web.ViewModels
{
    public class OrderViewModel
    {
        public string UserName { get; set; }
        public AddressView BillingAddress { get; set; }
        public AddressView ShippingAddress { get; set; }
        public PaymentMethodView PaymentMethod { get; set; }
        public OrderStatusView Status { get; set; }
        public decimal GrandTotal { get; set; }

        public List<OrderItemView> Items { get; set; } = new List<OrderItemView>();
    }

    public class AddressView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNo { get; set; }
        public string CompanyName { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public enum OrderStatusView
    {
        Progress = 1,
        OnShipping = 2,
        Finished = 3
    }

    public enum PaymentMethodView
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }

}
