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

    }
}
