using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Data.Repositories;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Enum;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgricultDetailMarket.Services.Implementations
{
    public class OrderService: IOrderService
    {
        private readonly IBaseRepository<Order> _orderRepository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Detail> _detailRepository;

        public OrderService(IBaseRepository<Order> orderRepository, IBaseRepository<User> userRepository, IBaseRepository<Detail> detailRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _detailRepository = detailRepository;
        }

        public async Task<IBaseResponse<Order>> Create(OrderViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll()
                                                .Include(x => x.Basket)
                                                .FirstOrDefaultAsync(x => x.Email == model.EmailUser);
                if (user == null)
                {
                    return new BaseResponse<Order>()
                    {
                        Description = "Пользователь не найден",
                        StatusCode = StatusCode.UserNotFound
                    };
                }
                
                var order = new Order()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    BasketId = user.Basket.Id,
                    DateTime = DateTime.UtcNow,
                    DetailId = model.DetailId,
                    Quantity = model.Quantity,
                };
                await _orderRepository.Create(order);

                return new BaseResponse<Order>()
                {
                    Data = order,
                    StatusCode = StatusCode.Ok
                };

            }
            catch (Exception ex)
            {
                return new BaseResponse<Order>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<bool>> Delete(int id)
        {
            try
            {
                var order = _orderRepository.GetAll()
                                            .Include (x => x.Basket)
                                            .FirstOrDefault(x => x.Id == id);
                if(order == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Заказ не найден",
                        StatusCode = StatusCode.OrdersNotFound,
                        Data = false
                    };
                }

                await _orderRepository.Delete(order);

                return new BaseResponse<bool>()
                {
                    Description = "Заказ удален",
                    StatusCode = StatusCode.Ok,
                    Data = true
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }
    }
}
