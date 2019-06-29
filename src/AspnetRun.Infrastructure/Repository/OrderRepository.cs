using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public Task<IEnumerable<Order>> GetOrderByUserNameAsync(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
