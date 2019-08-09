using System;

namespace WeatherGrabber.Domain.Exceptions
{
    public class CityWeatherInfoRepositoryException : Exception
    {
        public CityWeatherInfoRepositoryException() : base()
        { }

        public CityWeatherInfoRepositoryException(string message) : base(message)
        { }

        public CityWeatherInfoRepositoryException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}