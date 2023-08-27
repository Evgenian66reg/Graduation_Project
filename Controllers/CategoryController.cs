using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var response = _categoryService.GetCategories();
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return View();
        }

        public IActionResult Delete() => View();    

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _categoryService.DeleteCategory(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetCategories");
            }
            return View("Error", $"{response.Description}");
        }

        [HttpGet]
        public async Task<IActionResult> SaveCategory(int id)
        {
            if(id == 0)
            {
                return View();
            }

            var response = await _categoryService.GetCategory(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            ModelState.AddModelError("", response.Description);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SaveCategory(CategoryViewModel model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                if(model.Id == 0)
                {
                    await _categoryService.CreateCategory(model);
                }
                else
                {
                    await _categoryService.UpdateCategory(model.Id, model);
                }
            }

            return RedirectToAction("GetCategories");
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response = await _categoryService.GetCategory(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return PartialView(response.Data);
            }
            return RedirectToAction("GetCategories");
        }

    
        public IActionResult CreateCategory() => View();

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel model)
        {
            await _categoryService.CreateCategory(model);

            return RedirectToAction("GetCategories");     
        }
    }
}