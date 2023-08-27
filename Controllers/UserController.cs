using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Implementations;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AgricultDetailMarket.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> GetUsers()
        {
            var response = await _userService.GetUsers();
            if (response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteUser() => View();

        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = await _userService.DeleteUser(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return RedirectToAction("GetUsers");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateUser(int id)
        {
            if (id == 0)
            {
               return View();
            }
            var response = await _userService.GetUser(id);
            if(response.StatusCode == Models.Enum.StatusCode.Ok)
            {
                return View(response.Data);
            }
            return RedirectToAction("ErrorView");
        }  

        [HttpPost]
        public async Task<IActionResult> UpdateUser(UserViewModel model)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                await _userService.UpdateUser(model.Id, model);
            }
            return RedirectToAction("GetUsers");
        }
    }
}
