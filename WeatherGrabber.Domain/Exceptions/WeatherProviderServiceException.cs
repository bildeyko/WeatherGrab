using System;

namespace WeatherGrabber.Domain.Exceptions
{
    public class WeatherProviderServiceException : Exception
    {
        public WeatherProviderServiceException() : base()
        { }

        public WeatherProviderServiceException(string message) : base(message)
        { }

        public WeatherProviderServiceException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}