using System.Data;
using Microsoft.Data.Sqlite;

namespace DotnetWeather.Dapper;

public class DataContext(IConfiguration configuration)
{
    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(configuration.GetConnectionString("WeatherForecastDb"));
    }
}