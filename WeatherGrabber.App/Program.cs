using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherGrabber.Domain.Contracts;
using WeatherGrabber.Domain.Models;
using WeatherGrabber.Infrastructure.Services.Yandex;

namespace WeatherGrabber.App
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAsync().GetAwaiter().GetResult();

            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            IWeatherProviderService weatherProvider = new YandexService();

            try
            {
                var cities = await weatherProvider.GetCitiesAsync();
                var weatherData = new List<IEnumerable<Weather>>();
                foreach (var city in cities)
                {
                    var data = await weatherProvider.GetWeatherAsync(city.WeatherUrl);
                    weatherData.Add(data);
                }
                
                var a = 5;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }
    }
}
