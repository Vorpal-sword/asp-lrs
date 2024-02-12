using ConfigurationApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ConfigurationApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
		private readonly ICompanyService _companyService;
		public HomeController(IConfiguration configuration, ICompanyService companyService)
		{
			_configuration = configuration;
			_companyService = companyService;
		}

		public IActionResult Index()
		{
			var myData = _configuration.GetSection("MyData").Get<MyDataModel>();
			var maxCompany = _companyService.GetCompanyWithMaxEmployees();

			ViewBag.MaxCompany = maxCompany;

			return View(myData);
		}
	}

    public class MyDataModel
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Location { get; set; }
    }
}
