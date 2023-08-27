using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using NpgsqlTypes;

namespace AgricultDetailMarket.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepository;

        public CategoryService(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IBaseResponse<Category>> CreateCategory(CategoryViewModel model)
        {
            try
            {
                var category = new Category()
                { 
                    Id = model.Id,
                    Name = model.Name,
                };
                await _categoryRepository.Create(category);

                return new BaseResponse<Category>()
                {
                    Data = category,
                    StatusCode = Models.Enum.StatusCode.Ok
                };

            }catch (Exception ex)
            {
                return new BaseResponse<Category>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                 };
            }
        }

        public async Task<IBaseResponse<bool>> DeleteCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(category == null)
                {
                    return new BaseResponse<bool>()
                    {
                        Description = "Категория не найдена",
                        StatusCode = Models.Enum.StatusCode.CategoryNotFound,
                        Data = false
                    };
                }

                await _categoryRepository.Delete(category);
                return new BaseResponse<bool>()
                {
                    Data = true,
                    StatusCode = Models.Enum.StatusCode.Ok
                };
            }catch (Exception ex)
            {
                return new BaseResponse<bool>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        }

        public IBaseResponse<List<Category>> GetCategories()
        {
            try
            {
                var categories = _categoryRepository.GetAll().ToList();
                if (!categories.Any())
                {
                    return new BaseResponse<List<Category>>()
                    {
                        Description = "Найдено 0 элементов",
                        StatusCode = Models.Enum.StatusCode.CategoryNotFound
                    };
                }

                return new BaseResponse<List<Category>>()
                {
                    Data = categories,
                    StatusCode = Models.Enum.StatusCode.Ok
                };
            }catch (Exception ex)
            {
                return new BaseResponse<List<Category>>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<CategoryViewModel>> GetCategory(int id)
        {
            try
            {
                var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if (category == null)
                {
                    return new BaseResponse<CategoryViewModel>()
                    {
                        Description = "Категория не найдена",
                        StatusCode = Models.Enum.StatusCode.CategoryNotFound
                    };
                }

                var data = new CategoryViewModel()
                {
                    Name = category.Name,
                };

                return new BaseResponse<CategoryViewModel>()
                {
                    Data = data,
                    StatusCode = Models.Enum.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CategoryViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<CategoryViewModel>> GetCategoryByName(string name)
        {
            try
            {
                var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Name == name);
                if (category == null)
                {
                    return new BaseResponse<CategoryViewModel>()
                    {
                        Description = "Категория не найдена",
                        StatusCode = Models.Enum.StatusCode.CategoryNotFound
                    };
                }

                var data = new CategoryViewModel()
                {
                    Name = category.Name,
                };

                return new BaseResponse<CategoryViewModel>()
                {
                    Data = data,
                    StatusCode = Models.Enum.StatusCode.Ok
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse<CategoryViewModel>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        }

        public async Task<IBaseResponse<Category>> UpdateCategory(int id, CategoryViewModel model)
        {
            try
            {
                var category = await _categoryRepository.GetAll().FirstOrDefaultAsync(x => x.Id == id);
                if(category == null)
                {
                    return new BaseResponse<Category>()
                    {
                        Description = "Категория не найдена",
                        StatusCode = Models.Enum.StatusCode.CategoryNotFound
                    };
                }

                category.Name = model.Name;
                await _categoryRepository.Update(category);

                return new BaseResponse<Category>()
                {
                    Data = category,
                    StatusCode = Models.Enum.StatusCode.Ok
                };

            }catch (Exception ex)
            {
                return new BaseResponse<Category>()
                {
                    Description = ex.Message,
                    StatusCode = Models.Enum.StatusCode.InnerErrorService
                };
            }
        }
    }
}
