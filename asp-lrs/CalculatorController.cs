using asp_lrs;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CalculatorController : ControllerBase
{
	private readonly CalcService _calcService;
	private readonly TimeOfDayService _timeOfDayService;
	public CalculatorController(CalcService calcService, TimeOfDayService timeOfDayService)
	{
		_calcService = calcService;
		_timeOfDayService = timeOfDayService;
	}

	[HttpGet("add")]
	public IActionResult Add(int a, int b)
	{
		int result = _calcService.Add(a, b);
		return Ok(result);
	}

	[HttpGet("subtract")]
	public IActionResult Subtract(int a, int b)
	{
		int result = _calcService.Subtract(a, b);
		return Ok(result);
	}

	[HttpGet("multiply")]
	public IActionResult Multiply(int a, int b)
	{
		int result = _calcService.Multiply(a, b);
		return Ok(result);
	}

	[HttpGet("divide")]
	public IActionResult Divide(int a, int b)
	{
		try
		{
			int result = _calcService.Divide(a, b);
			return Ok(result);
		}
		catch (ArgumentException ex)
		{
			return BadRequest(ex.Message);
		}
	}
	[HttpGet("timeOfDay")]
	public IActionResult GetTimeOfDay()
	{
		DateTime currentTime = DateTime.Now;
		string timeOfDay = _timeOfDayService.GetTimeOfDay();
		return Ok(timeOfDay);
	}

}

