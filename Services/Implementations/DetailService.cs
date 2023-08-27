using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Enum;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Services.Interfaces;
using AgricultDetailMarket.Services;
using Microsoft.AspNetCore.Mvc;
using AgricultDetailMarket.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AgricultDetailMarket.Services.Implementations
{
    public class DetailService : IDetailService
    {
        private readonly IBaseRepository<Detail> _detailRepository;

        public DetailService(IBaseRepository<Detail> detailRepository)
        {
            _detailRepository = detailRepository;
        }

        public async Task<IBaseResponse<Detail>> CreateDetail(DetailViewModel model)
        {
            try
            {
                var detail = new Detail()
                {
                    Id = model.Id,
                    Name = model.Name,
                    Discription = model.Discription,
                    CodeDetail = model.CodeDetail,
                    Price = model.Price,
                    CategoryId = model.CategoryId
                };
                await _detailRepository.Create(detail);

                return new BaseResponse<Detail>()
                {
                    Data = detail,
                    StatusCode = StatusCode.Ok
                };

            }catch (Exception ex)
            {
                return new BaseResponse<Detail>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteDetail(int id)
        {
            try
            {
                var detail = await _detailRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(detail == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Деталь не найдена",
                        StatusCode = StatusCode.DetailNotFound,
                        Data = false
                    };
                }

                await _detailRepository.Delete(detail);

                return new BaseResponse<bool>()
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

        public async Task<IBaseResponse<DetailViewModel>> GetDetail(int id)
        {
            try
            {
                var detail = await _detailRepository.GetAll().FirstOrDefaultAsync(x => x.Id==id);
                if(detail == null)
                {
                    return new BaseResponse<DetailViewModel>()
                    {
                        Description = "Деталь не найдена",
                        StatusCode = StatusCode.DetailNotFound
                    };
                }

                var data = new DetailViewModel()
                {
                    Name = detail.Name,
                    Discription = detail.Discription,
                    CodeDetail = detail.CodeDetail,
                    Price = detail.Price,
                    CategoryId = detail.CategoryId,
                };

                return new BaseResponse<DetailViewModel>()
                {
                    Data = data,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<DetailViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public IBaseResponse<List<Detail>> GetDetails()
        {
            try
            {
                var details = _detailRepository.GetAll().ToList();
                if (!details.Any())
                {
                    return new BaseResponse<List<Detail>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = StatusCode.DetailNotFound
                    };
                }

                return new BaseResponse<List<Detail>>()
                {
                    Data = details,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<List<Detail>>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<Detail>> UpdateDetail(int id, DetailViewModel model)
        {
            try
            {
                var detail = await _detailRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (detail == null)
                {
                    return new BaseResponse<Detail>()
                    {
                        Description = "Деталь не найдена",
                        StatusCode = StatusCode.DetailNotFound
                    };
                }

                detail.Name = model.Name;
                detail.Discription = model.Discription;
                detail.CodeDetail = model.CodeDetail;
                detail.Price = model.Price;
                detail.CategoryId = model.CategoryId;

                await _detailRepository.Update(detail);

                return new BaseResponse<Detail>()
                {
                    Data = detail,
                    StatusCode = StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<Detail>()
                {
                    Description = ex.Message,
                    StatusCode = StatusCode.InnerErrorService
                };
            }
        }
    }
}
