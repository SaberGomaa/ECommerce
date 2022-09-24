using ECommerce.Models;
using ECommerce.ModelView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

            var f = context.customers.Where(c => c.Img == photo.FileName).FirstOrDefault(); 

            if(photo != null && f == null)
            {
                string attach = Path.Combine(host.WebRootPath, "attaches");
                fileName = photo.FileName;
                string fullPath = Path.Combine(attach, fileName);
                photo.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            if(photo != null) c.Img = photo.FileName;
            
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
            var c = context.customers.Where(c => c.Email == login.Email && c.Password == login.Password).FirstOrDefault();

            int isAdmin = 0;
            if (c.Id == 1) isAdmin = 1;

            if (c != null)
            {
                HttpContext.Session.SetInt32("customerId" , c.Id);
                HttpContext.Session.SetString("customerName" , c.FName);
                HttpContext.Session.SetInt32("isAdmin" , isAdmin);


                return RedirectToAction("show" , "product" );
            }
            else
            {
                ViewBag.msg = "Incorrect Email or Password";
                return View();
            }
        }
        public IActionResult Details()
        {
            int? id = HttpContext.Session.GetInt32("customerId");
            if (id == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                var c = context.customers.Where(c => c.Id == id).FirstOrDefault();
                return View(c);
            }
        }

        public IActionResult Edit()
        {
            int? id = HttpContext.Session.GetInt32("customerId");
            if (id == null)
            {
                return RedirectToAction("login");
            }
            else
            {
                var c = context.customers.Find(id);
                return View(c);
            }
        }

        [HttpPost]
        public IActionResult Edit(customer c)
        {
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Details", "customer");
        }
        public IActionResult logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }

        public IActionResult show_problem()
        {
            if (HttpContext.Session.GetInt32("isAdmin") == 1)
            {
                List<contact> contacts = context.contacts.Include(c => c.customer).ToList();

                return View(contacts);
            }
            else
            {
                return RedirectToAction("login");
            }
        }

    }
}
