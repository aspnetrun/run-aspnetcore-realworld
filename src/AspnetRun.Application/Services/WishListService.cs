using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class WishListService : IWishListService
    {
        private readonly IWishlistRepository _wishlistRepository;
        private readonly IAppLogger<ProductService> _logger;

        public WishListService(IWishlistRepository wishlistRepository, IAppLogger<ProductService> logger)
        {
            _wishlistRepository = wishlistRepository ?? throw new ArgumentNullException(nameof(wishlistRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<WishlistModel> GetProductByUserName(string userName)
        {
            var wishlist = await _wishlistRepository.GetByUserNameAsync(userName);
            var mapped = ObjectMapper.Mapper.Map<WishlistModel>(wishlist);
            return mapped;
        }
    }
}
