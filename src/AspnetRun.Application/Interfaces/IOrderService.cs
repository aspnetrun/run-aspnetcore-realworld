using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderService
    {
        // TODO : implement this
        Task CheckOut(string userName, int productId);
    }
}
