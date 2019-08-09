using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WeatherGrabber.API.DTO
{
    [DataContract]
    public class CitiesResponseDTO
    {
        [DataMember]
        public List<CityWeatherInfoDTO> Cities { get; set; } = new List<CityWeatherInfoDTO>();
    }
}