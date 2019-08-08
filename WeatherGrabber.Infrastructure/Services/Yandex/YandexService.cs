using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WeatherGrabber.Infrastructure.Services.Yandex.Pages;

namespace WeatherGrabber.Infrastructure.Services.Yandex
{
    public class YandexService : Domain.Contracts.IWeatherProviderService
    {
        private Uri _baseUri = new Uri("https://yandex.ru/");

        public async Task<IEnumerable<Domain.Models.City>> GetCitiesAsync()
        {
            var url = new Uri(_baseUri,"pogoda/");
            var mainPage = new MainPage(url);
            await mainPage.LoadPageAsync();

            var siteCities = mainPage.GetCities();
            var cities = siteCities.Select(c => new Domain.Models.City(c.Name, c.Href)).ToList();
            return cities;
        }

        public async Task<IEnumerable<Domain.Models.Weather>> GetWeatherAsync(string cityUrl)
        {
            var url = new Uri(_baseUri, cityUrl);
            var weatherPage = new WeatherPage(url);
            await weatherPage.LoadPageAsync();

            var weatherData = weatherPage.GetWeather();
            return weatherData.Select(w => new Domain.Models.Weather(w.Date, w.TempDay, w.TempNight, w.Comment));
        }
    }
}
