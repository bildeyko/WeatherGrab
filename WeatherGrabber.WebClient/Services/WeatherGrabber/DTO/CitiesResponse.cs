using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WeatherGrabber.WebClient.Services.WeatherGrabber.DTO
{
    public class CitiesResponse
    {
        public List<CityWeatherInfo> Cities { get; set; } = new List<CityWeatherInfo>();
    }
}