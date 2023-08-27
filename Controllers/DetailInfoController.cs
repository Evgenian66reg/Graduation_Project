using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{
    public class DetailInfoController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IDetailService _detailService;
        public DetailInfoController(IDetailService detailService, ICategoryService categoryService)
        {
            _detailService = detailService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> InfoDetail(int id)
        {
            var categoryResponse = await _categoryService.GetCategory(id);
            var response = await _detailService.GetDetail(id);
            if (response != null)
            {
                return View(response.Data);
            }
            if (categoryResponse != null)
            {
                return View(categoryResponse.Data);
            }
            return RedirectToAction("ErrorView");
        }
    }
}
