using AspnetRun.Application.Interfaces;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        public Task CheckOut(string userName, int orderId)
        {
            // TODO : apply validations - i.e. - customer has only 3 order or order item should be low than 5 etc..
            throw new NotImplementedException();
        }
    }
}
