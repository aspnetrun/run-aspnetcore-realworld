using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace AspnetRun.Infrastructure.Tests.Repositories
{
    public class ShoppingCartTest
    {
        private readonly AspnetRunContext _context;
        private readonly IAsyncRepository<ShoppingCart> _repository;
        private readonly ITestOutputHelper _testOutput;

        public ShoppingCartTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput ?? throw new ArgumentNullException(nameof(testOutput));

            var options = new DbContextOptionsBuilder<AspnetRunContext>()
                .UseInMemoryDatabase(databaseName: "AspnetRunRealWorld")
                .Options;

            _context = new AspnetRunContext(options);
            _repository = new AspnetRunRepository<ShoppingCart>(_context);
        }

        [Fact]
        public async Task Get_Existing_Shopping_Cart()
        {

        }
    }
}
