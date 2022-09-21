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

            if (customerId == null)
            {
                return RedirectToAction("login", "customer");
            }

            var c = context.carts.Where(e => e.customer_id == customerId)
                .Include(e => e.customer)
                .Include(e => e.Product).ToList();

            return View(c);
        }

        public IActionResult add(int productId)
        {
            
            int? customerId = HttpContext.Session.GetInt32("customerId");
            List<Cart> carts = context.carts.Where(e => e.customer.Id == customerId)
                .Include(p => p.Product).ToList();

            if (customerId == null)
            {
                return RedirectToAction("login", "customer");
            }
            else
            {
                var c = new Cart();
                c.customer_id = (int)customerId;
                c.product_id = productId;
                c.Quantity = 1;

                bool found = false;
                foreach (var cart in carts)
                {
                    if (cart.Product.Id == productId)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    context.carts.Add(c);
                    context.SaveChanges();
                }
                return RedirectToAction("view", "Cart");
            }
        }
        public IActionResult delete(int id)
        {
            if (id != null)
            {
                context.carts.Remove(context.carts.Find(id));
                context.SaveChanges();
            }
                return RedirectToAction("view");
        }
    }
}
