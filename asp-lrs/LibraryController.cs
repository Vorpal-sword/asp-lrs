using asp_lrs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

[Route("Library")]
public class LibraryController : Controller
{
	private readonly IConfiguration _configuration;

	public LibraryController(IConfiguration configuration)
	{
		_configuration = configuration;
	}
	[HttpGet("")]
	public IActionResult Index()
	{
		return Content("Привіт, це сторінка бібліотеки!");
	}

	[HttpGet("Books")]
	public IActionResult GetBooks()
	{
		var books = _configuration.GetSection("Books").Get<List<Book>>();
		return Ok(books);
	}
	[HttpGet("Profile/{id?}")]
	public IActionResult Profile(int? id)
	{
		var userInfo = new UserProfile();
		if (id.HasValue && id >= 0 && id <= 5)
		{
			userInfo = _configuration.GetSection($"Users:{id}").Get<UserProfile>();
			return Ok(userInfo);
		}
		else if (id.HasValue)
		{
			return BadRequest("Неприпустиме значення id. id має бути цілим числом від 0 до 5.");
		}
		else
		{
			return Ok(new UserProfile { UserId = "-1", Name = "Current User", Age = 25 });
		}
	}
}