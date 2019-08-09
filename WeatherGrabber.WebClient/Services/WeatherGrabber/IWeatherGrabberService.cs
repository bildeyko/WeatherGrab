using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherGrabber.WebClient.Services.WeatherGrabber.DTO;

namespace WeatherGrabber.WebClient.Services.WeatherGrabber
{
    public interface IWeatherGrabberService
    {
        Task<IList<CityWeatherInfo>> GetCitiesAsync();
    }
}