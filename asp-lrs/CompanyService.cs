using Microsoft.Extensions.Configuration;
using System;

namespace ConfigurationApp.Services
{
    public interface ICompanyService
    {
        string GetCompanyWithMaxEmployees();
    }

    public class CompanyService : ICompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		public string GetCompanyWithMaxEmployees()
		{
			int maxEmployees = 0;
			string companyWithMaxEmployees = "";

			string[] companies = [ "Microsoft", "Apple", "Google" ];

			foreach (var company in _configuration.GetSection("Companies").GetChildren())
			{
				int employees = company.GetValue<int>("Employees");
				if (employees > maxEmployees)
				{
					maxEmployees = employees;
					companyWithMaxEmployees = company.Key;
				}
			}

			return companies[Int32.Parse(companyWithMaxEmployees)];
		}
	}
}
