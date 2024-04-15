using asp_lrs.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using asp_lrs.Filters;
namespace asp_lrs.Controllers
{
    public class HomeController : Controller
    {
        // ������������ ������� LogActionFilter
        [LogActionFilter]
        public ActionResult Index()
        {
            return View();
        }

        // ������������ ���� �������
        [LogActionFilter]
        [ServiceFilter(typeof(UniqueUsersFilter))]
        public ActionResult UniqueUsers()
        {
            return View();
        }
    }
}
