using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Data.Repositories;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgricultDetailMarket.Services.Implementations
{
    public class BasketService : IBasketService
    {
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Detail> _detailRepository;

        public BasketService(IBaseRepository<User> userRepository, IBaseRepository<Detail> detailRepository)
        {
            _userRepository = userRepository;
            _detailRepository = detailRepository;
        }   

        public async Task<IBaseResponse<IEnumerable<BasketOrderViewModel>>> GetItems(string userEmail)
        {
            try
            {
                var user = await _userRepository.GetAll()
                    .Include(x => x.Basket)
                    .ThenInclude(x => x.Orders)
                    .FirstOrDefaultAsync(x => x.Email == userEmail);

                if(user == null)
                {
                    return new BaseResponse<IEnumerable<BasketOrderViewModel>>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = Models.Enum.StatusCode.UserNotFound
                    };
                }

                var orders = user.Basket?.Orders;
                var response = from o in orders
                               join d in _detailRepository.GetAll() on o.DetailId equals d.Id
                               select new BasketOrderViewModel()
                               {
                                   Id = o.Id,
                                   DetailName = d.Name,
                                   DetailPrice = d.Price,
                                   DetailCode = d.CodeDetail,
                                   FirstName = o.FirstName,
                                   LastName = o.LastName,
                                   DateCreate = DateTime.UtcNow.ToString(),
                                   Quantity = o.Quantity,
                               };

                return new BaseResponse<IEnumerable<BasketOrderViewModel>>()
                {
                    Data = response,
                    StatusCode = Models.Enum.StatusCode.Ok
                };
            }catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<BasketOrderViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        } 
        
    }
}
