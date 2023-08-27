using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Data.Repositories;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Enum;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;
using System.Web.Helpers;
using StatusCode = AgricultDetailMarket.Models.Enum.StatusCode;

namespace AgricultDetailMarket.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _userRepository;

        public UserService(IBaseRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        
        public async Task<IBaseResponse<User>> Create(UserViewModel model)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Email == model.Email);
                if (user != null)
                {
                    return new BaseResponse<User>()
                    {
                        Description = "Пользователь с таким именем уже есть",
                        StatusCode = StatusCode.UserAlreadyExists
                    };
                }

                user = new User()
                {
                    Email = model.Email,
                    Password = Crypto.HashPassword(model.Password),
                    Role = model.Role,
                };
                await _userRepository.Create(user);

                return new BaseResponse<User>()
                {
                    Data = user,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<BaseResponse<bool>> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    return new BaseResponse<bool>
                    {
                        Data  = false,
                        StatusCode = StatusCode.UserNotFound,
                        Description = "Пользователь не найден"
                    };
                }

                await _userRepository.Delete(user);

                return new BaseResponse<bool>
                {
                    Data = true,
                    StatusCode = StatusCode.Ok
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

        public BaseResponse<Dictionary<int, string>> GetRoles()
        {
            try
            {
                var roles = ((Role[])Enum.GetValues(typeof(Role)))
                    .ToDictionary(k => (int)k, t => t.GetDisplayName());

                return new BaseResponse<Dictionary<int, string>>()
                {
                    Data = roles,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Dictionary<int,string>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetAll()
                    .Select(x => new UserViewModel()
                    {
                        Id = x.Id,
                        Email = x.Email,
                        Role = Enum.Parse<Role>(x.Role.GetDisplayName()),
                    }).ToListAsync();

                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Data = users,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<IEnumerable<UserViewModel>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<User>> UpdateUser(int id, UserViewModel model)
        {
            var baseResponse = new BaseResponse<User>();
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    baseResponse.StatusCode = StatusCode.UserNotFound;
                    baseResponse.Description = "User not found";
                    return baseResponse;
                }

                user.Email = model.Email;
                user.Password = Crypto.HashPassword(model.Password);
                user.Role = model.Role;
                await _userRepository.Update(user);

                return baseResponse;

            }
            catch (Exception ex)
            {
                return new BaseResponse<User>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<UserViewModel>> GetUser(int id)
        {
            try
            {
                var user = await _userRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (user == null)
                {
                    return new BaseResponse<UserViewModel>()
                    {
                        StatusCode = StatusCode.UserNotFound,
                        Description = "User not found",
                    };
                }

                var data = new UserViewModel()
                {
                    Email = user.Email,
                    Password = Crypto.HashPassword(user.Password),
                    Role = user.Role,
                };

                return new BaseResponse<UserViewModel>()
                {
                    StatusCode = StatusCode.Ok,
                    Data = data,
                };
            }catch(Exception ex)
            {
                return new BaseResponse<UserViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }
    }
}
