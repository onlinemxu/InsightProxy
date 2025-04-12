using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace InsightDataQueryAPI.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IActionResult Get()
    {
        var apiVersion = Request.HttpContext.GetRequestedApiVersion();
        return Ok(new string($"Version {apiVersion?.MajorVersion?.ToString()}"));
    }
}

[ApiController]
[ApiVersion("2.0")]
[Route("v{version:apiVersion}/[controller]")]
public class WeatherForecast2Controller : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecast2Controller(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet("GetWeatherForecast")]
    public IActionResult Get()
    {
        var apiVersion = Request.HttpContext.GetRequestedApiVersion();
        return Ok(new string($"Version {apiVersion?.MajorVersion?.ToString()}"));
    }

    [HttpGet("GetVersion")]
    public IActionResult GetId(int id)
    {
        return Ok(new string($"Version 2.0 with id {id}"));
    }
}