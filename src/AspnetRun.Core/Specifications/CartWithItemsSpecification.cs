using AspnetRun.Core.Entities;
using AspnetRun.Core.Specifications.Base;

namespace AspnetRun.Core.Specifications
{
    public class CartWithItemsSpecification : BaseSpecification<Cart>
    {
        public CartWithItemsSpecification(string userName)
            : base(p => p.UserName.ToLower().Contains(userName.ToLower()))
        {
            AddInclude(p => p.Items);
        }

        public CartWithItemsSpecification(int cartId)
            : base(p => p.Id == cartId)
        {
            AddInclude(p => p.Items);
        }
    }   
}
