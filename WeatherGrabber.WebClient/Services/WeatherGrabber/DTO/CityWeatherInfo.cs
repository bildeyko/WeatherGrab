using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.WebClient.Services.WeatherGrabber.DTO
{
    public class CityWeatherInfo
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int TempNight { get; set; }
        public int TempDay { get; set; }
        public string WeatherComment { get; set; }
    }
}
