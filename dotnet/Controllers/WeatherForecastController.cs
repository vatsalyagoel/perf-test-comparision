using Dapper;
using dotnet.Dapper;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly DataContext _context;

    public WeatherForecastController(DataContext context, ILogger<WeatherForecastController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpGet("{city}", Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(string city = "london")
    {
        _logger.LogInformation("GetWeatherForecast called");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            City = city
        })
        .ToArray();
    }

    [HttpGet("db/{city}", Name = "GetWeatherForecastFromDb")]
    public async Task<IEnumerable<WeatherForecast>> GetFromDB(string city = "London")
    {
        using var connection = _context.CreateConnection();
        var sql = """
                      SELECT * FROM WeatherForecast
                      WHERE city = @city
                  """;
        return await connection.QueryAsync<WeatherForecast>(sql, new { city } );
    }
}
