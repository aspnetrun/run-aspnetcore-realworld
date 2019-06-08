using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<ProductService> _logger;

        public WishListService(IWishlistRepository wishlistRepository, IProductRepository productRepository, IAppLogger<ProductService> logger)
        {
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<WishlistModel> GetProductByUserName(string userName)
        {
            var wishlist = await _wishlistRepository.GetByUserNameAsync(userName);

            var wishlistModel = new WishlistModel
            {
                UserName = wishlist.UserName,
                WishlistItems = new List<ProductModel>()
            };

            foreach (var item in wishlist.ProductWishlists)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                wishlistModel.WishlistItems.Add(productModel);
            }

            return wishlistModel;
        }
    }
}
