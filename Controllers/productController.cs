using ECommerce.Models;
using ECommerce.ModelView;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Controllers
{
    public class productController : Controller
    {

        public productController(IWebHostEnvironment host)
        {
            this.host = host;
        }

        myDbContext context = new myDbContext();

        private readonly IWebHostEnvironment host;

        public IActionResult Index()
        {
            return RedirectToAction("show", "product");
        }
        
        public IActionResult show()
        {
            List<Product> products = context.products.OrderBy(e=>e.Price).ToList();

            bool isAdmin = false;

            if (HttpContext.Session.GetInt32("customerId") == 1) isAdmin = true;

            ViewBag.isAdmin = isAdmin;
            return View(products);
        }

        public IActionResult detail(int id)
        {
            return View(context.products.SingleOrDefault(p => p.Id == id));
        }

        public IActionResult create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult create(Product p , IFormFile photo)
        {
            string fileName = "";
            if (photo != null)
            {
                string attach = Path.Combine(host.WebRootPath, "attaches");
                fileName = photo.FileName;
                string fullPath = Path.Combine(attach, fileName);
                photo.CopyTo(new FileStream(fullPath, FileMode.Create));
            }
            if(photo != null)
                p.Img = photo.FileName;

            context.products.Add(p);
            context.SaveChanges();
            return RedirectToAction("show", "product");
        }

        public IActionResult delete(int? productId)
        {
            if (productId != null)
            {
                var product = context.products.Find(productId);
                if (product != null)
                {
                    context.products.Remove(product);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("show");
        }

    }
}
