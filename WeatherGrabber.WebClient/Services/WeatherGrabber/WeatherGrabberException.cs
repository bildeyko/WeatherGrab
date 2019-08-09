using System;

namespace WeatherGrabber.WebClient.Services.WeatherGrabber
{
    public class WeatherGrabberException : Exception
    {
        public WeatherGrabberException() : base()
        { }

        public WeatherGrabberException(string message) : base(message)
        { }

        public WeatherGrabberException(string message, Exception innerException) : base(message, innerException)
        { }
    }
}