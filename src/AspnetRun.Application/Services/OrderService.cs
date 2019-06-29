using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Entities;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IAppLogger<OrderService> _logger;

        public OrderService(IOrderRepository orderRepository, IAppLogger<OrderService> logger)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<OrderModel> CheckOut(OrderModel orderModel)
        {            
            ValidateOrder(orderModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Order>(orderModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _orderRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<OrderModel>(newEntity);
            return newMappedEntity;
        }

        private void ValidateOrder(OrderModel orderModel)
        {
            // TODO : apply validations - i.e. - customer has only 3 order or order item should be low than 5 etc..
            if (string.IsNullOrWhiteSpace(orderModel.UserName))
            {
                throw new ApplicationException($"Order username must be defined");
            }

            if (orderModel.Items.Count == 0)
            {
                throw new ApplicationException($"Order should have at least one item");
            }

            if (orderModel.Items.Count > 10)
            {
                throw new ApplicationException($"Order has maximum 10 items");
            }
        }
    }
}
