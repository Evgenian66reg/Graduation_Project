using AgricultDetailMarket.Data.Interfaces;
using AgricultDetailMarket.Models.Response;
using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.ViewModels;

namespace AgricultDetailMarket.Services.Interfaces
{
    public interface ICategoryService
    {
        IBaseResponse<List<Category>> GetCategories();

        Task<IBaseResponse<CategoryViewModel>> GetCategory(int id);

        Task<IBaseResponse<CategoryViewModel>> GetCategoryByName(string name);

        Task<IBaseResponse<Category>> CreateCategory(CategoryViewModel model);

        Task<IBaseResponse<bool>> DeleteCategory(int id);

        Task<IBaseResponse<Category>> UpdateCategory(int id, CategoryViewModel model);
    }
}
