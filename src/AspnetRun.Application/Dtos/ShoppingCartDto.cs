using System;
using System.Collections.Generic;
using System.Text;

namespace AspnetRun.Application.Dtos
{
    public class ShoppingCartDto : BaseDto
    {
        public int UserId { get; set; }
        public List<ShoppingCartItemDto> Items { get; set; }
    }
}
