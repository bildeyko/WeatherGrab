using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.Infrastructure.Services.Yandex.Pages.Items
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public int TempNight { get; set; }
        public int TempDay { get; set; }
        public string Comment { get; set; }
    }
}
