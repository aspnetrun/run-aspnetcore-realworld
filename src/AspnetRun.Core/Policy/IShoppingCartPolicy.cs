using AspnetRun.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Policy
{
    public interface IShoppingCartPolicy
    {
        void CheckAddingItem(ShoppingCart shoppingCart);
    }
}
