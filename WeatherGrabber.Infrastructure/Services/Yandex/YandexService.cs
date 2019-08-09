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
        private readonly Uri _baseUri = new Uri("https://yandex.ru/");
        private readonly IRequestProvider _requestProvider;

        public YandexService(IRequestProvider requestProvider)
        {
            _requestProvider = requestProvider;
        }

        public async Task<IEnumerable<Domain.Models.City>> GetCitiesAsync()
        {
            try
            {
                var url = new Uri(_baseUri,"pogoda/");
                var mainPage = new MainPage(url, _requestProvider);
                await mainPage.LoadPageAsync();

                var siteCities = mainPage.GetCities();
                var cities = siteCities.Select(c => new Domain.Models.City(c.Name, new Uri(_baseUri, c.Href).ToString())).ToList();
                return cities;
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.WeatherProviderServiceException(e.Message, e);
            }
        }

        public async Task<IEnumerable<Domain.Models.Weather>> GetWeatherAsync(string cityUrl)
        {
            if (cityUrl == null)
            {
                throw new ArgumentNullException(nameof(cityUrl));
            }

            try
            {
                var weatherPage = new WeatherPage(new Uri(cityUrl), _requestProvider);
                await weatherPage.LoadPageAsync();

                var weatherData = weatherPage.GetWeather();
                return weatherData.Select(w => new Domain.Models.Weather(w.Date, w.TempDay, w.TempNight, w.Comment));
            }
            catch (Exception e)
            {
                throw new Domain.Exceptions.WeatherProviderServiceException(e.Message, e);
            }
        }
    }
}
