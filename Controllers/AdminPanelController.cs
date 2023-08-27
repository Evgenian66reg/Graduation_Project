using AgricultDetailMarket.Models;
using AgricultDetailMarket.Models.ViewModels;
using AgricultDetailMarket.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace AgricultDetailMarket.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IDetailService _detailService;

        public AdminPanelController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        public IActionResult AdminPanel()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(int id)
        {
            if (id == 0)
            {
                return View();
            }
            var response = await _detailService.GetDetail(id);
            if (response != null)
            {
                return View(response.Data);
            }
            return RedirectToAction("ErrorView");
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Save(DetailViewModel detail)
        {
            if (ModelState.IsValid)
            {
                if (detail.Id == 0)
                {
                    await _detailService.CreateDetail(detail);
                }
                else
                {
                    await _detailService.UpdateDetail(detail.Id, detail);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
