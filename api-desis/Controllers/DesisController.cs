using Microsoft.AspNetCore.Mvc;

namespace api_desis.Controllers;

[ApiController]
[Route("[controller]")]
public class DesisController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<DesisApiController> _logger;

    public DesisController(ILogger<DesisApiController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetDesisApi")]
    public IEnumerable<DesisApi> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new DesisApi
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

