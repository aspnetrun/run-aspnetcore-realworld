using AspnetRun.Web.Interfaces;
using AspnetRun.Web.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Task<CompareViewModel> GetCompare(string userName)
        {
            throw new NotImplementedException();
        }

        public Task RemoveItem(int compareId, int productId)
        {
            throw new NotImplementedException();
        }

        public Task AddToCart(string userName, int productId)
        {
            throw new NotImplementedException();
        }
    }
}
