using System.Threading.Tasks;

namespace AspnetRun.Application.Interfaces
{
    public interface IOrderService
    {        
        Task CheckOut(string userName, int orderId);
    }
}
