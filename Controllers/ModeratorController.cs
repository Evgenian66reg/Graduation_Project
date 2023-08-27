using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{
    public class ModeratorController : Controller
    {
        public IActionResult ContactAdmin()
        {
            return View();
        }
    }
}
