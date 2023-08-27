using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;
using NuGet.Protocol.Core.Types;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface IDetailService
    {

        IBaseResponse<List<Detail>> GetDetails();

        Task<IBaseResponse<DetailViewModel>> GetDetail(int id);

        Task<IBaseResponse<Detail>> CreateDetail(DetailViewModel model);

        Task<IBaseResponse<bool>> DeleteDetail(int id);

        Task<IBaseResponse<Detail>> UpdateDetail(int id, DetailViewModel model);

    }
}
