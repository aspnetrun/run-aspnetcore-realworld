using AspnetRun.Application.Interfaces;
using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspnetRun.Web.Services
{
    public class ComparePageService : IComparePageService
    {
        private readonly ICompareService _compareAppService;
        private readonly IMapper _mapper;
        private readonly ILogger<ComparePageService> _logger;

        public ComparePageService(ICompareService compareAppService, IMapper mapper, ILogger<ComparePageService> logger)
        {
            _compareAppService = compareAppService ?? throw new ArgumentNullException(nameof(compareAppService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<CompareViewModel> GetCompare(string userName)
        {
            var compare = await _compareAppService.GetCompareByUserName(userName);
            var mapped = _mapper.Map<CompareViewModel>(compare);
            return mapped;
        }

        public async Task RemoveItem(int compareId, int productId)
        {
            await _compareAppService.RemoveItem(compareId, productId);
        }

        public async Task AddToCart(string userName, int productId)
        {
            // TODO : Implement this
            throw new NotImplementedException();
        }
    }
}
