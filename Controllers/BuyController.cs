using Microsoft.AspNetCore.Mvc;

namespace AgricultDetailMarket.Controllers
{
    public class BuyController : Controller
    {
        public IActionResult BuyOrder()
        {
            return View();
        }
    }
}
