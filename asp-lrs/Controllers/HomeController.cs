using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using asp_lrs.Filters;
namespace asp_lrs.Controllers
{
    public class HomeController : Controller
    {
        // Використання фільтру LogActionFilter
        [LogActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        // Використання обох фільтрів
        [LogActionFilter]
        [ServiceFilter(typeof(UniqueUsersFilter))]
        public ActionResult UniqueUsers()
        {
            return View();
        }
    }
}
