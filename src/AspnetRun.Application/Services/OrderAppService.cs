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
    }
}
