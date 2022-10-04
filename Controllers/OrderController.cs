using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
