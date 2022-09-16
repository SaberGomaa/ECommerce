using ECommerce.Models;
using ECommerce.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace ECommerce.Controllers
{
    public class customerController : Controller
    {

        public customerController(IWebHostEnvironment host)
        {
            this.host = host;
        }

        myDbContext context = new myDbContext();
        private readonly IWebHostEnvironment host;

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(customer c , IFormFile photo )
        {
            string fileName = "";
            if(photo != null)
            {
                string attach = Path.Combine(host.WebRootPath, "attaches");
                fileName = photo.FileName;
                string fullPath = Path.Combine(attach, fileName);
                photo.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            c.Img = photo.FileName;
            context.customers.Add(c);
            context.SaveChanges();
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            customer c = context.customers.Where(c => c.Email == login.Email && c.Password == login.Password).FirstOrDefault();
            if (c != null)
            {
                return RedirectToAction("Details" ,new {id = c.Id});
            }
            else
            {
                ViewBag.msg = "Incorrect Email or Password";
                return View();
            }
        }
        public IActionResult Details(int id) 
        {
            var c = context.customers.Where(c => c.Id == id).FirstOrDefault();
            return View(c);
        }
    }
}
