using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class productController : Controller
    {
        myDbContext context = new myDbContext();
        public IActionResult Index()
        {
            return RedirectToAction("view", "product");
        }
        
        public IActionResult show()
        {
            List<Product> products = context.products.OrderBy(e=>e.Price).ToList();

            return View(products);
        }

        public IActionResult detail(int id)
        {
            return View(context.products.SingleOrDefault(p => p.Id == id));
        }

    }
}
