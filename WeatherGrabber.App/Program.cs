using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherGrabber.Domain.Contracts;
using WeatherGrabber.Domain.Models;
using WeatherGrabber.Infrastructure.Repositories;
using WeatherGrabber.Infrastructure.Services.Yandex;

namespace WeatherGrabber.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IWeatherProviderService weatherProvider = new YandexService();
            ICityWeatherInfoRepository infoRepository = new CityWeatherInfoRepository();
            var app = new Application(weatherProvider, infoRepository);

            Console.ReadLine();
            // Нет особого смысла вызывать здесь Dispose
            app.Dispose();
        }
    }
}
