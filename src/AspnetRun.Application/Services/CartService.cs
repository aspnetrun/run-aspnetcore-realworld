using System;
using System.Threading.Tasks;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;

namespace AspnetRun.Application.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CartService> _logger;

        public CartService(ICartRepository cartRepository, IProductRepository productRepository, IAppLogger<CartService> logger)
        {
            _cartRepository = cartRepository ?? throw new ArgumentNullException(nameof(cartRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Task AddItem(string userName, int productId)
        {
            throw new System.NotImplementedException();
        }

        public Task<CartModel> GetProductByUserName(string userName)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveItem(int compareId, int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}
