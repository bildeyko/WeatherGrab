﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.Domain.Models
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
