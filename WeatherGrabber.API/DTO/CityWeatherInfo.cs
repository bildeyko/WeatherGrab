using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.API.DTO
{
    [DataContract]
    public class CityWeatherInfo
    {
        [DataMember]
        public int CityId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int TempNight { get; set; }
        [DataMember]
        public int TempDay { get; set; }
        [DataMember]
        public string WeatherComment { get; set; }
    }
}
