using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherGrabber.WebClient.Services.WeatherGrabber.DTO;

namespace WeatherGrabber.WebClient.Services.WeatherGrabber
{
    public class WeatherGrabberService : IWeatherGrabberService
    {
        private readonly string _host;

        public WeatherGrabberService(string hostUrl)
        {
            _host = hostUrl;
        }

        public async Task<IList<CityWeatherInfo>> GetCitiesAsync()
        {
            var route = $"/Cities";

            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(_host + route);
                    var response = await client.GetAsync(uri);
                    response.EnsureSuccessStatusCode();
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<CitiesResponse>(jsonResponse);
                    return result.Cities;
                }
            }
            catch (HttpRequestException)
            {
                // в реальности еще логгировать
                throw new WeatherGrabberUnavailableException();
            }
            catch (Exception e)
            {
                // в реальности еще логгировать
                throw new WeatherGrabberException(e.Message, e);
            }
        }
    }
}