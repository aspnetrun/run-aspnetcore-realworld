using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Tests.Builder
{
    public class ShoppingCartBuilder
    {
        private ShoppingCart _shoppingCart;
        public string ShoppingCartUserId => "testuserId@test.com";
        public int ShoppingCartId => 1;

        public ShoppingCartBuilder()
        {
            _shoppingCart = WithNoItems();
        }

        private ShoppingCart WithNoItems()
        {
            _shoppingCart = new ShoppingCart { Id = ShoppingCartId, UserId = ShoppingCartUserId };
            return _shoppingCart;
        }

        public ShoppingCart WithOneBasketItem()
        {
            _shoppingCart = new ShoppingCart { Id = ShoppingCartId, UserId = ShoppingCartUserId };
            _shoppingCart.AddProductToCart(2, 3.40m, 4);
            return _shoppingCart;
        }

        public ShoppingCart Build()
        {
            return _shoppingCart;
        }
    }
}
