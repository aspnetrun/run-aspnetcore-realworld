using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Infrastructure.Tests.Builders;
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
        private readonly ShoppingCartBuilder _builder;

        public ShoppingCartTest(ITestOutputHelper testOutput)
        {
            _testOutput = testOutput ?? throw new ArgumentNullException(nameof(testOutput));

            var options = new DbContextOptionsBuilder<AspnetRunContext>()
                .UseInMemoryDatabase(databaseName: "AspnetRunRealWorld")
                .Options;

            _context = new AspnetRunContext(options);
            _repository = new AspnetRunRepository<ShoppingCart>(_context);
            _builder = new ShoppingCartBuilder();
        }

        [Fact]
        public async Task Get_Existing_Shopping_Cart()
        {
            var existingShoppingCart = _builder.WithDefaultValues();

            _context.ShoppingCarts.Add(existingShoppingCart);
            _context.SaveChanges();

            int shoppingCartId = existingShoppingCart.Id;
            _testOutput.WriteLine($"Shopping Cart Id : {shoppingCartId}");

            var scFromRepo = await _repository.GetByIdAsync(shoppingCartId);
            Assert.Equal(_builder.TestUserId, scFromRepo.UserId);
        }
    }
}
