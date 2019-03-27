using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Core.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public ShoppingCart()
        {
            ShoppingCartDetails = new HashSet<ShoppingCartDetail>();
        }

        public string UserId { get; set; }
        public ICollection<ShoppingCartDetail> ShoppingCartDetails { get; private set; }


    }
}
