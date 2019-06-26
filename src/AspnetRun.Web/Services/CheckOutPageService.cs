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
        private readonly IOrderService _orderAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<CheckOutPageService> _logger;

        public CheckOutPageService(ICartService cartAppService, IOrderService orderAppService, IMapper mapper, ILogger<CheckOutPageService> logger)
        {
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _orderAppService = orderAppService ?? throw new ArgumentNullException(nameof(orderAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CartViewModel> GetCart(string userName)
        {
            var cart = await _cartAppService.GetCartByUserName(userName);
            var mapped = _mapper.Map<CartViewModel>(cart);
            return mapped;
        }
        
        public async Task CheckOut(OrderViewModel order, string userName)
        {            
            var cart = await GetCart(userName);
            TransformCartItemToOrderItem(order, cart);
            
            //await _orderAppService.CheckOut()

            throw new NotImplementedException();
        }

        private void TransformCartItemToOrderItem(OrderViewModel order, CartViewModel cart)
        {
            foreach (var cartItem in cart.Items)
            {
                order.Items.Add(
                    new OrderItemView
                    {
                        Color = cartItem.Color,
                        Quantity = cartItem.Quantity,
                        UnitPrice = cartItem.UnitPrice,
                        TotalPrice = cartItem.TotalPrice,
                        ProductId = cartItem.ProductId,
                        Product = cartItem.Product
                    });
            }
        }
    }
}
