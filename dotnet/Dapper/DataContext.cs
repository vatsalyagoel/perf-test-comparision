using System.Data;
using Microsoft.Data.Sqlite;

namespace dotnet.Dapper;

public class DataContext
{
    protected readonly IConfiguration Configuration;

    public DataContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(Configuration.GetConnectionString("WeatherForecastDb"));
    }
}