using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class ProductPageService : IProductPageService
    {
        private readonly IProductService _productAppService;
        private readonly ICategoryService _categoryAppService;
        private readonly ICartService _cartAppService;
        private readonly IWishlistService _wishlistAppService;
        private readonly ICompareService  _compareAppService;        

        private readonly IMapper _mapper;
        private readonly ILogger<ProductPageService> _logger;

        public ProductPageService(IProductService productAppService, ICategoryService categoryAppService, ICartService cartAppService, IWishlistService wishlistAppService, ICompareService compareAppService, IMapper mapper, ILogger<ProductPageService> logger)
        {
            _productAppService = productAppService ?? throw new ArgumentNullException(nameof(productAppService));
            _categoryAppService = categoryAppService ?? throw new ArgumentNullException(nameof(categoryAppService));
            _cartAppService = cartAppService ?? throw new ArgumentNullException(nameof(cartAppService));
            _wishlistAppService = wishlistAppService ?? throw new ArgumentNullException(nameof(wishlistAppService));
            _compareAppService = compareAppService ?? throw new ArgumentNullException(nameof(compareAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<ProductViewModel>> GetProducts(string productName)
        {
            if (string.IsNullOrWhiteSpace(productName))
            {
                var list = await _productAppService.GetProductList();
                var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
                return mapped;
            }

            var listByName = await _productAppService.GetProductByName(productName);
            var mappedByName = _mapper.Map<IEnumerable<ProductViewModel>>(listByName);
            return mappedByName;
        }

        public async Task<ProductViewModel> GetProductById(int productId)
        {
            var product = await _productAppService.GetProductById(productId);
            var mapped = _mapper.Map<ProductViewModel>(product);
            return mapped;
        }

        public async Task<ProductViewModel> GetProductBySlug(string slug)
        {
            var product = await _productAppService.GetProductBySlug(slug);
            var mapped = _mapper.Map<ProductViewModel>(product);
            return mapped;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductByCategory(int categoryId)
        {
            var list = await _productAppService.GetProductByCategory(categoryId);
            var mapped = _mapper.Map<IEnumerable<ProductViewModel>>(list);
            return mapped;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var list = await _categoryAppService.GetCategoryList();
            var mapped = _mapper.Map<IEnumerable<CategoryViewModel>>(list);
            return mapped;
        }

        public async Task AddToCart(string userName, int productId)
        {
            await _cartAppService.AddItem(userName, productId);            
        }

        public async Task AddToWishlist(string userName, int productId)
        {            
            await _wishlistAppService.AddItem(userName, productId);
        }

        public async Task AddToCompare(string userName, int productId)
        {            
            await _compareAppService.AddItem(userName, productId);            
        }        
    }
}
