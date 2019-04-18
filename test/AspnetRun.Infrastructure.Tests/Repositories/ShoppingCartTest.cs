using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Tests.Repositories
{
    public class ShoppingCartTest
    {
        private Mock<IAsyncRepository<ShoppingCart>> _mockShoppingCartRepository;
        private Mock<IAsyncRepository<ShoppingCartItem>> _mockShoppingCartItemRepository;

        public ShoppingCartTest()
        {
            _mockShoppingCartRepository = new Mock<IAsyncRepository<ShoppingCart>>();
            _mockShoppingCartItemRepository = new Mock<IAsyncRepository<ShoppingCartItem>>();
        }

        
    }
}
