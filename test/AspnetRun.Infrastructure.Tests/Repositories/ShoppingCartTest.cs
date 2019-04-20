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

        private Mock<IAsyncRepository<ShoppingCart>> _mockShoppingCartRepository;
        private Mock<IAsyncRepository<ShoppingCartItem>> _mockShoppingCartItemRepository;

        public ShoppingCartTest()
        {
            _mockShoppingCartRepository = new Mock<IAsyncRepository<ShoppingCart>>();
            _mockShoppingCartItemRepository = new Mock<IAsyncRepository<ShoppingCartItem>>();
        }

        [Fact]
        public async Task Should_Get_Data()
        {
            var shoppingCartList = new List<ShoppingCart>();
            _mockShoppingCartRepository.Setup(x => x.GetAllAsync())
                .ReturnsAsync(shoppingCartList);

            Assert.True(shoppingCartList.Count > 0);
        }

        [Fact]
        public async Task Should_InvokeShoppingCartRepo_Given_TwoItemsInCart()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(1, It.IsAny<decimal>(), It.IsAny<short>());
            shoppingCart.AddItemToCart(2, It.IsAny<decimal>(), It.IsAny<short>());

            _mockShoppingCartRepository.Setup(x => x.GetByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(shoppingCart);


            Assert.NotNull(shoppingCart);

            _mockShoppingCartRepository.Verify(x => x.DeleteAsync(It.IsAny<ShoppingCart>()), Times.Once);
            _mockShoppingCartItemRepository.Verify(x => x.DeleteAsync(It.IsAny<ShoppingCartItem>()), Times.Exactly(2));

            
            //Assert.NotNull(result);
            //Assert.Equal(_testBasketId, result.Id);
            //Assert.False(GetTestBasketCollection().AsQueryable().Any(spec.Criteria));
            //Assert.Equal(expectedCount, result.Count());

            await _mockShoppingCartItemRepository.Object.GetAllAsync();
        }
    }
}
