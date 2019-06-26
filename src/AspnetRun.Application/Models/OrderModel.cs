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

    public class AddressModel
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

    public enum OrderStatusModel
    {
        Progress = 1,
        OnShipping = 2,
        Finished = 3
    }

    public enum PaymentMethodModel
    {
        Check = 1,
        BankTransfer = 2,
        Cash = 3,
        Paypal = 4,
        Payoneer = 5
    }
}
