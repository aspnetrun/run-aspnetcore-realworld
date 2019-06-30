using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class ProductSlugSpecification : BaseSpecification<Product>
    {
        public ProductSlugSpecification(string slug)
            : base(p => p.Slug.ToLower().Contains(slug.ToLower()))
        {
            AddInclude(p => p.Category);
            AddInclude(p => p.Specifications);
            AddInclude(p => p.Reviews);
            AddInclude(p => p.Tags);
        }
    }
}
