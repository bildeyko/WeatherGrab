using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WeatherGrabber.API.DTO
{
    [DataContract]
    public class CitiesResponse
    {
        [DataMember]
        public List<CityWeatherInfo> Cities { get; set; } = new List<CityWeatherInfo>();
    }
}