using System.ComponentModel.DataAnnotations;

namespace WeatherGrabber.Infrastructure.Repositories.Models
{
    public class CityWeatherInfo
    {
        [Key]
        public int CityId { get; set; }
        public string Name { get; set; }
        public int TempNight { get; set; }
        public int TempDay { get; set; }
        public string WeatherComment { get; set; }
    }
}
