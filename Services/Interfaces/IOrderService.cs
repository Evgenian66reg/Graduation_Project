using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface IOrderService
    {
        Task<IBaseResponse<Order>> Create(OrderViewModel model);

        Task<IBaseResponse<bool>> Delete(int id);
    }
}
