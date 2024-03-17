using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_lrs.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 10.50m, CreatedDate = DateTime.Now.AddDays(-10) },
            new Product { ID = 2, Name = "Product 2", Price = 20.75m, CreatedDate = DateTime.Now.AddDays(-5) },
            new Product { ID = 3, Name = "Product 3", Price = 15.30m, CreatedDate = DateTime.Now }
        };

            return View(products);
        }
    }

}
