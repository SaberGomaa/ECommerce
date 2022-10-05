using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult view()
        {
            return View();
        }

        public IActionResult OrderDetail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OrderDetail(Order order)
        {
            return RedirectToAction("view", "order");
        }

    }
}
