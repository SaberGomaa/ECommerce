using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class OrderController : Controller
    {
        public myDbContext context = new myDbContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult viewOrder()
        {
            var orders = context.orders.AsSplitQuery().Include(c=>c.product).ToList();

            return View(orders);
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
