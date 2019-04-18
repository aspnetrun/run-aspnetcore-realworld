using System;
using AspnetRun.Core.Configuration;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Exceptions;

namespace AspnetRun.Core.Policy
{
    public class ShoppingCartPolicy : IShoppingCartPolicy
    {
        private readonly IShoppingCartConfiguration _configuration;

        public ShoppingCartPolicy(IShoppingCartConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void CheckAddingItem(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Items.Count >= _configuration.MaxItemCountForAUser)
            {
                throw new CoreException($"Can not add more than {_configuration.MaxItemCountForAUser} item into cart !");
            }
        }
    }
}
