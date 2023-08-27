using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models;
using System.Security.Claims;
using AgricultDetailMarket.Models.ViewModels;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface IAccountService
    {
        Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
        Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    }
}
