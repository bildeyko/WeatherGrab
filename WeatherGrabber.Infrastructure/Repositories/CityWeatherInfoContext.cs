using System.Data.Entity;
using MySql.Data.Entity;
using WeatherGrabber.Infrastructure.Repositories.Models;

namespace WeatherGrabber.Infrastructure.Repositories
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class CityWeatherInfoContext : DbContext
    {
        public CityWeatherInfoContext() : base("sqlConnectionString")
        { }

        public CityWeatherInfoContext(string connectionString) : base(connectionString)
        { }

        public DbSet<CityWeatherInfo> Cities { get; set; }
    }
}