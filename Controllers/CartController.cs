using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        myDbContext context = new myDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult view()
        {
            int? customerId = HttpContext.Session.GetInt32("customerId");

            var c = context.carts.Where(e=>e.customer_id == customerId)
                .Include(e=>e.customer)
                .Include(e => e.Product).ToList();
                
            return View(c);
        }

        [HttpPost]
        public IActionResult add(int customerId , int productId)
        {
            var p = context.products.Find(productId);

            return RedirectToAction("view" , "Cart" , new {customerId = customerId});
        }

    }
}
