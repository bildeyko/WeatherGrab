using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherGrabber.API.DTO;
using WeatherGrabber.Domain.Contracts;
using WeatherGrabber.Infrastructure.Repositories;

namespace WeatherGrabber.API
{
    public class WeatherService : IWeatherService
    {
        public CitiesResponse GetCities()
        {
            ICityWeatherInfoRepository weatherRepository = new CityWeatherInfoRepository();
            var weatherData = weatherRepository.GetAll();

            var response = new CitiesResponse();
            foreach (var wi in weatherData)
            {
                response.Cities.Add(new CityWeatherInfo
                {
                    CityId = wi.CityId,
                    Name = wi.Name,
                    TempDay = wi.TempDay,
                    TempNight = wi.TempNight,
                    WeatherComment = wi.WeatherComment
                });
            }

            return response;
        }
    }
}
