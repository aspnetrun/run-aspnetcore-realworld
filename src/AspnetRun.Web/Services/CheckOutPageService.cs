using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class CheckOutPageService : ICheckOutPageService
    {
        private readonly ICartService _cartAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckOutPageService> _logger;

        public CheckOutPageService(ICartService cartAppService, IMapper mapper, ILogger<CheckOutPageService> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartViewModel> GetCart(string userName)
        {
            var cart = await _cartAppService.GetCartByUserName(userName);
            var mapped = _mapper.Map<CartViewModel>(cart);
            return mapped;
        }

        public Task CheckOut()
        {
            throw new NotImplementedException();
        }
    }
}
