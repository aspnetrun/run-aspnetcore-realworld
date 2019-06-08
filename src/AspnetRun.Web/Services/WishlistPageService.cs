using System;
using System.Threading.Tasks;
using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AspnetRun.Web.Services
{
    public class WishlistPageService : IWishlistPageService
    {
        private readonly IWishListService _wishListAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<WishlistPageService> _logger;

        public WishlistPageService(IWishListService wishListAppService, IMapper mapper, ILogger<WishlistPageService> logger)
        {
            _wishListAppService = wishListAppService ?? throw new ArgumentNullException(nameof(wishListAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }       

        public async Task<WishlistViewModel> GetWishlist(string userName)
        {
            var wishlist = await _wishListAppService.GetProductByUserName(userName);
            var mapped = _mapper.Map<WishlistViewModel>(wishlist);
            return mapped;
        }

        public async Task RemoveItem(int wishlistId, int productId)
        {
            await _wishListAppService.RemoveItem(wishlistId, productId);            
        }

        public Task AddToCart(string userName, int productId)
        {
            // TODO : Implement this
            throw new NotImplementedException();
        }
    }
}
