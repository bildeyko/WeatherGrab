using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WeatherGrabber.API.DTO;
using WeatherGrabber.Domain.Contracts;
using WeatherGrabber.Domain.Exceptions;
using WeatherGrabber.Infrastructure.Repositories;

namespace WeatherGrabber.API
{
    public class WeatherService : IWeatherService
    {
        public CitiesResponseDTO GetCities()
        {
            ICityWeatherInfoRepository weatherRepository = new CityWeatherInfoRepository();
            IEnumerable<Domain.Models.CityWeatherInfo> weatherData;

            try
            {
                weatherData = weatherRepository.GetAll();
            }
            catch (CityWeatherInfoRepositoryException e)
            {
                throw new WebFaultException<ErrorDTO>(new ErrorDTO(e.ToString()), HttpStatusCode.InternalServerError);
            }

            var response = new CitiesResponseDTO();
            foreach (var wi in weatherData)
            {
                response.Cities.Add(new CityWeatherInfoDTO
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
