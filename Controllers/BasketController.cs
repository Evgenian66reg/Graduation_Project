using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Implementations;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        
        public async Task<IActionResult> GetItems()
        {
            var response = await _basketService.GetItems(User.Identity.Name);
            if (response.StatusCode == Models.Enum.StatusCode.Ok)
            {
               return View(response.Data.ToList());
            }
            return View();
        }

    }
}
