using AspnetRun.Application.Dtos;
using AspnetRun.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class ShoppingCartAppService : IShoppingCartAppService
    {
        public Task AddItemToCart(ShoppingCartItemDto entityDto)
        {
            // TODOX : develop
            throw new NotImplementedException();
        }

        public double GetTotalCostOfCart(ShoppingCartDto shoppingCartDto)
        {
            throw new NotImplementedException();
        }
    }
}
