using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Tests.Builders
{
    public class ShoppingCartBuilder
    {
        private ShoppingCart _shoppingCart;
        public string TestBuyerId => "12345";
        public int TestUserId => 234;
        public string TestProductName => "Test Product Name";
        public string TestPictureUri => "http://test.com/image.jpg";
        public decimal TestUnitPrice = 1.23m;
        public int TestUnits = 3;

        public ShoppingCartBuilder()
        {
            _shoppingCart = new ShoppingCart
            {
                UserId = TestUserId
            };
        }
    }
}
