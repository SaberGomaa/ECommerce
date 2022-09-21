using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CartController : Controller
    {
        myDbContext context = new myDbContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult view(int customerId)
        {
            return View(context.carts.Where(e=>e.customer_id == customerId).ToList());
        }

        [HttpPost]
        public IActionResult add(int customerId , int productId)
        {
            var p = context.products.Find(productId);

            return RedirectToAction("view" , "Cart" , new {customerId = customerId});
        }

    }
}
