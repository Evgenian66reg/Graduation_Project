using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace AgricultDetailMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder(int id)
        {
           
            var orderModel = new OrderViewModel()
            {
                DetailId = id,
                EmailUser = User.Identity.Name,      
                DateCreated = DateTime.UtcNow,
            };
            return View(orderModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderService.Create(model);
            }
            else
            {
                await _orderService.Create(model);
            }
            return RedirectToAction("GetItems", "Basket");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _orderService.Delete(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetItems", "Basket");
            }
            return View("Error", $"{response.Description}");
        }
    }
}
