using AspnetRun.Application.Models;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderService
    {        
        Task<OrderModel> CheckOut(OrderModel orderModel);
    }
}
