using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Models;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class OrderService : IOrderService
    {
        // TODO : apply validations - i.e. - customer has only 3 order or order item should be low than 5 etc..
        public Task CheckOut(OrderModel orderModel)
        {
            

            await ValidateProductIfExist(productModel);

            var mappedEntity = ObjectMapper.Mapper.Map<Product>(productModel);
            if (mappedEntity == null)
                throw new ApplicationException($"Entity could not be mapped.");

            var newEntity = await _productRepository.AddAsync(mappedEntity);
            _logger.LogInformation($"Entity successfully added - AspnetRunAppService");

            var newMappedEntity = ObjectMapper.Mapper.Map<ProductModel>(newEntity);
            return newMappedEntity;

            throw new NotImplementedException();
        }

        private async Task ValidateProductIfExist(ProductModel productModel)
        {
            var existingEntity = await _productRepository.GetByIdAsync(productModel.Id);
            if (existingEntity != null)
                throw new ApplicationException($"{productModel.ToString()} with this id already exists");
        }

    }
}
