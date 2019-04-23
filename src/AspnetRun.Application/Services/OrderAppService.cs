using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        public Task CheckOut(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task<OrderDto> GetOrderDetail(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderDto>> GetOrderList()
        {
            throw new NotImplementedException();
        }

        public Task PayOrder(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task SendOrderConfirmationEmail(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task SpecifyCreditCart(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

        public Task SpecifyDeliveryAddress(AddressDto addressDto)
        {
            throw new NotImplementedException();
        }

        public Task SpecifyDeliveryNote(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
