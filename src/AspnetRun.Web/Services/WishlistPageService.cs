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
        private readonly IWishlistService _wishListAppService;
        private readonly ICartService _cartAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<WishlistPageService> _logger;

        public WishlistPageService(IWishlistService wishListAppService, ICartService cartAppService, IMapper mapper, ILogger<WishlistPageService> logger)
        {
            _wishListAppService = wishListAppService ?? throw new ArgumentNullException(nameof(wishListAppService));
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<WishlistViewModel> GetWishlist(string userName)
        {
            var wishlist = await _wishListAppService.GetWishlistByUserName(userName);
            var mapped = _mapper.Map<WishlistViewModel>(wishlist);
            return mapped;
        }

        public async Task RemoveItem(int wishlistId, int productId)
        {
            await _wishListAppService.RemoveItem(wishlistId, productId);
        }

        public async Task AddToCart(string userName, int productId)
        {
            await _cartAppService.AddItem(userName, productId);
        }
    }
}
