using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{

    public class CatalogController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CatalogController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> ShowCategories()
        {
            var response = _categoryService.GetCategories();
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View();
        }
    }
}