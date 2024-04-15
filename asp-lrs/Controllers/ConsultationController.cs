using asp_lrs.Filters;
using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace asp_lrs.Controllers
{
    public class ConsultationController : Controller
    {
        [LogActionFilter]
        public IActionResult RegisterConsultation()
        {
            return View();
        }

        [HttpPost]
        [LogActionFilter]
        public IActionResult RegisterConsultation(ConsultationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("RegistrationSuccess");
        }
        [LogActionFilter]
        public IActionResult RegistrationSuccess()
        {
            return View();
        }
    }
}