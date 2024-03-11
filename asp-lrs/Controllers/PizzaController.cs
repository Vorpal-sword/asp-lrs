using System.Collections.Generic;
using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;

namespace asp_lrs.Controllers
{
    public class PizzaController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user.Age > 16)
            {
                ViewBag.ShowOrderForm = true;
                return View("Order", user);
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public IActionResult OrderConfirmation(Product[] products)
        {
            return View(products);
        }

    }
}
