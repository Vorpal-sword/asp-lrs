using asp_lrs.Filters;
using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_lrs.Controllers
{
    public class ProductsController : Controller
    {
        [LogActionFilter]
        public IActionResult Index()
        {
            var products = new List<Product>
        {
            new Product { ID = 1, Name = "Product 1", Price = 10.50m},
            new Product { ID = 2, Name = "Product 2", Price = 20.75m},
            new Product { ID = 3, Name = "Product 3", Price = 15.30m}
        };

            return View(products);
        }
    }

}
