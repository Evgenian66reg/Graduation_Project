using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface IBasketService
    {
        Task<IBaseResponse<IEnumerable<BasketOrderViewModel>>> GetItems(string userEmail);
    }
}
