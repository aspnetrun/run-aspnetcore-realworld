using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Infrastructure.Tests.Builders
{
    public class ShoppingCartBuilder
    {
        private ShoppingCart _shoppingCart;        
        public int TestUserId => 234;        

        public ShoppingCartBuilder()
        {
            _shoppingCart = WithDefaultValues();
        }

        public ShoppingCart WithDefaultValues()
        {
            var shoppingCart = new ShoppingCart
            {
                UserId = TestUserId
            };

            return shoppingCart;
        }
    }
}
