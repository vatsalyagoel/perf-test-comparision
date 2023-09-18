using Dapper;
using DotnetWeather.Dapper;
using DotnetWeather.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotnetWeather.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(DataContext context, ILogger<WeatherForecastController> logger)
    : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet("{city}", Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(string city = "london")
    {
        logger.LogInformation("GetWeatherForecast called");
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
        using var connection = context.CreateConnection();
        var sql = """
                      SELECT * FROM WeatherForecast
                      WHERE city = @city
                  """;
        return await connection.QueryAsync<WeatherForecast>(sql, new { city } );
    }
}
