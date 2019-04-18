using System;
using System.Collections.Generic;
using System.Text;
using AspnetRun.Core.Entities;

namespace AspnetRun.Core.Policy
{
    public class ShoppingCartPolicy : IShoppingCartPolicy
    {


        public void CheckAddingItem(ShoppingCart shoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
