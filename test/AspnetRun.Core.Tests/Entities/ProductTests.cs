using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AspnetRun.Core.Tests.Entities
{
    public class ProductTests
    {
        // USE CASE :  Create_Product        

        private int _testProductId = 2;
        private int _testCategoryId = 3;
        private int _testBrandId = 4;
        private int _testSuplierId = 5;
        private string _testProductName = "Reason";
        private decimal _testUnitPrice = 1.23m;
        private short _testQuantity = 2;

        [Fact]
        public void Create_Product()
        {
            var product = Product.Create(_testProductId, _testCategoryId, _testProductName, _testBrandId, _testSuplierId, _testUnitPrice, _testQuantity, null, null, false);

            Assert.Equal(_testProductId, product.Id);
            Assert.Equal(_testCategoryId, product.CategoryId);            
            Assert.Equal(_testProductName, product.ProductName);
            Assert.Equal(_testBrandId, product.BrandId);
            Assert.Equal(_testSuplierId, product.SupplierId);
            Assert.Equal(_testUnitPrice, product.UnitPrice);
            Assert.Equal(_testQuantity, product.UnitsInStock);
        }
    }
}
