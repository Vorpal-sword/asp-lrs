using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace asp_lrs.Controllers
{
    public class ConsultationController : Controller
    {
        public IActionResult RegisterConsultation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterConsultation(ConsultationRequest model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("RegistrationSuccess");
        }

        public IActionResult RegistrationSuccess()
        {
            return View();
        }
    }
}