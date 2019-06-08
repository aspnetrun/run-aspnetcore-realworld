using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;
using System;
using System.Linq.Expressions;

namespace AspnetRun.Core.Specifications
{
    public class WishlistWithItemsSpecification : BaseSpecification<Wishlist>
    {
        public WishlistWithItemsSpecification(Expression<Func<Wishlist, bool>> criteria) : base(criteria)
        {
        }

        public WishlistWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.ProductWishlists);
        }
    }
}
