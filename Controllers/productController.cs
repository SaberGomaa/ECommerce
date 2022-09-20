using ECommerce.Models;
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
            p.Img = photo.FileName;

            context.products.Add(p);
            context.SaveChanges();
            return RedirectToAction("show", "product");
        }

    }
}
