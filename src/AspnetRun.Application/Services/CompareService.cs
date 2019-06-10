using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Mapper;
using AspnetRun.Application.Models;
using AspnetRun.Core.Interfaces;
using AspnetRun.Core.Repositories;
using AspnetRun.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetRun.Application.Services
{
    public class CompareService : ICompareService
    {
        private readonly ICompareRepository _compareRepository;
        private readonly IProductRepository _productRepository;
        private readonly IAppLogger<CompareService> _logger;

        public CompareService(ICompareRepository compareRepository, IProductRepository productRepository, IAppLogger<CompareService> logger)
        {
            _compareRepository = compareRepository ?? throw new ArgumentNullException(nameof(compareRepository));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CompareModel> GetProductByUserName(string userName)
        {
            var compare = await _compareRepository.GetByUserNameAsync(userName);

            var CompareModel = new CompareModel
            {
                Id = compare.Id,
                UserName = compare.UserName,
                Items = new List<ProductModel>()
            };

            foreach (var item in compare.ProductCompares)
            {
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                var productModel = ObjectMapper.Mapper.Map<ProductModel>(product);
                CompareModel.Items.Add(productModel);
            }

            return CompareModel;
        }

        public async Task RemoveItem(int CompareId, int productId)
        {
            var spec = new CompareWithItemsSpecification(CompareId);
            var compare = (await _compareRepository.GetAsync(spec)).FirstOrDefault();
            compare.RemoveItem(productId);
            await _compareRepository.UpdateAsync(compare);
        }

    }
}
