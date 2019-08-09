using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherGrabber.Domain.Models;

namespace WeatherGrabber.Domain.Contracts
{
    public interface IWeatherProviderService
    {
        Task<IEnumerable<City>> GetCitiesAsync();
        Task<IEnumerable<Weather>> GetWeatherAsync(string cityUrl);
    }
}