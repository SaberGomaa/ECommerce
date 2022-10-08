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
            int? id = HttpContext.Session.GetInt32("customerId");

            if (id != null)
            {
                var orders = context.orders.AsSplitQuery().Include(c => c.product).ToList();
                return View(orders);
            }
            else
            {
                return RedirectToAction("login", "customer");
            }
        }

        public IActionResult OrderDetail(int Id)
        {   
            var product = context.products.Where(p=>p.Id==Id ).FirstOrDefault();

            return View(product);
        }

        [HttpPost]
        public IActionResult OrderDetail(Order order)
        {

            int customerId = (int)HttpContext.Session.GetInt32("customerId");
            if (customerId != null)
            {
                order.order_date = DateTime.Now;
                order.order_total = order.subTotal * order.Quantity;
                order.customer_id = customerId;

                var x = order;

                return RedirectToAction("view", "order");
            }
            else
            {
                return RedirectToAction("login", "customer");
            }
        }

    }
}