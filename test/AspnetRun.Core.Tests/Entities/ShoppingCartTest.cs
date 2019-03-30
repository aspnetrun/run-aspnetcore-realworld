using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace AspnetRun.Core.Tests.Entities
{
    public class ShoppingCartTest
    {
        // USE CASE :  Add_ShoppingCartItem
        // USE CASE :  Add_ShoppingCartItem_Increment_Quantity
        // USE CASE :  Add_ShoppingCartItem_Increment_UnitPrice
        // USE CASE :  Add_2_ShoppingCartItem
        // USE CASE :  Update_ShoppingCartItem_Quantity
        // USE CASE :  Delete_ShoppingCartItem

        private int _testProductId = 123;
        private decimal _testUnitPrice = 1.23m;
        private short _testQuantity = 2;

        [Fact]
        public void Add_ShoppingCartItem_IfNotPresent()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice, _testQuantity);

            var firstItem = shoppingCart.Items.Single();
            Assert.Equal(_testProductId, firstItem.ProductId);
            Assert.Equal(_testUnitPrice, firstItem.UnitPrice);
            Assert.Equal(_testQuantity, firstItem.Quantity);
        }

        [Fact]
        public void Increment_Quantity_Item_IfPresent()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice, _testQuantity);
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice, _testQuantity);

            var firstItem = shoppingCart.Items.Single();
            Assert.Equal(_testQuantity * 2, firstItem.Quantity);
        }

        [Fact]
        public void Keeps_OriginalUnitPrice_IfMoreItemsAdded()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice, _testQuantity);
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice * 2, _testQuantity);

            var firstItem = shoppingCart.Items.Single();
            Assert.Equal(_testUnitPrice, firstItem.UnitPrice);
        }

        [Fact]
        public void DefaultsTo_Quantity_OfOne()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice);

            var firstItem = shoppingCart.Items.Single();
            Assert.Equal(1, firstItem.Quantity);
        }

        [Fact]
        public void Adds_TwoItems()
        {
            var shoppingCart = new ShoppingCart();
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice, _testQuantity);
            shoppingCart.AddItemToCart(_testProductId, _testUnitPrice * 2, _testQuantity);

            var itemCount = shoppingCart.Items.Count();
            Assert.Equal(2, itemCount);
        }


    }
}
