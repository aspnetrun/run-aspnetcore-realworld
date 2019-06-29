using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        // TODO : apply validations - i.e. - customer has only 3 order or order item should be low than 5 etc..
        public async Task CheckOut(OrderModel orderModel)
        {
            
            ValidateOrder(orderModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(productModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ProductModel>(newEntity);
            return newMappedEntity;

            throw new NotImplementedException();
        }

        private void ValidateOrder(OrderModel orderModel)
        {
            if (string.IsNullOrWhiteSpace(orderModel.UserName))
            {
                throw new ApplicationException($"Order username must be defined");
            }

            if (orderModel.Items.Count == 0)
            {
                throw new ApplicationException($"Order should have at least one item");
            }
        }
    }
}
