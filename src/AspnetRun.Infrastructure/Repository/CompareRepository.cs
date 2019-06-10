using AspnetRun.Core.Entities;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Infrastructure.Repository
{
    public class CompareRepository : Repository<Compare>, ICompareRepository
    {
        public CompareRepository(AspnetRunContext dbContext) : base(dbContext)
        {
        }

        public async Task<Compare> GetByUserNameAsync(string userName)
        {
            var spec = new CompareWithItemsSpecification(userName);
            return (await GetAsync(spec)).FirstOrDefault();
        }
    }
}
