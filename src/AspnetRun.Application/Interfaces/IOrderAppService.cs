using AspnetRun.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderAppService
    {
        Task<IEnumerable<OrderDto>> GetOrderList();
        Task<OrderDto> GetOrderDetail(int orderId);
        Task CheckOut(OrderDto orderDto);
        Task SpecifyDeliveryAddress(AddressDto addressDto);
        Task SpecifyDeliveryNote(OrderDto orderDto);
        Task SpecifyCreditCart(OrderDto orderDto);
        Task PayOrder(OrderDto orderDto);
        Task SendOrderConfirmationEmail(OrderDto orderDto);
    }
}
