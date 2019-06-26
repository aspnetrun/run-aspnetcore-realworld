using AspnetRun.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        public Task CheckOut(string userName, int orderId)
        {
            throw new NotImplementedException();
        }
    }
}
