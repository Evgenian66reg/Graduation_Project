using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface IUserService
    {
        Task<IBaseResponse<User>> Create(UserViewModel model);

        BaseResponse<Dictionary<int, string>> GetRoles();

        Task<BaseResponse<IEnumerable<UserViewModel>>> GetUsers();

        Task<BaseResponse<bool>> DeleteUser(int id);

        Task<IBaseResponse<User>> UpdateUser(int id, UserViewModel model);

        Task<IBaseResponse<UserViewModel>> GetUser(int id);
    }
}
