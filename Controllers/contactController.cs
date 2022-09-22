using ECommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class contactController : Controller
    {
        myDbContext context = new myDbContext();    
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult contact()
        {
            if (HttpContext.Session.GetInt32("customerId") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "customer"); 
            }
        }
        [HttpPost]
        public IActionResult contact(contact c)
        {
            
            if (c != null && HttpContext.Session.GetInt32("customerId") !=null)
            {
                c.customer_id = (int)HttpContext.Session.GetInt32("customerId");

                context.contacts.Add(c);
                context.SaveChanges();
            }
            return RedirectToAction("show", "product");
        }
        
        public IActionResult about()
        {
            return View();
        }

    }
}
