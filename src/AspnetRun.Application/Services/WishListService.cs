using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<WishListService> _logger;

        public WishListService(IWishlistRepository wishlistRepository, IProductRepository productRepository, IAppLogger<WishListService> logger)
        {
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<WishlistModel> GetProductByUserName(string userName)
        {
            var wishlist = await _wishlistRepository.GetByUserNameAsync(userName);

            if (wishlist == null) // if it is first attempt create new
            {
                var newWishlist = new Wishlist
                {
                    UserName = userName
                };

                await _wishlistRepository.AddAsync(newWishlist);
                var mapped = ObjectMapper.Mapper.Map<WishlistModel>(newWishlist);
                return mapped;
            }

            var wishlistModel = ObjectMapper.Mapper.Map<WishlistModel>(wishlist);

            foreach (var item in wishlist.ProductWishlists)
            {
                var product = await _productRepository.GetProductByIdWithCategoryAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                wishlistModel.Items.Add(productModel);
            }

            return wishlistModel;
        }

        public async Task RemoveItem(int wishlistId, int productId)
        {
            var spec = new WishlistWithItemsSpecification(wishlistId);
            var wishlist = (await _wishlistRepository.GetAsync(spec)).FirstOrDefault();
            wishlist.RemoveItem(productId);
            await _wishlistRepository.UpdateAsync(wishlist);
        }
    }
}
