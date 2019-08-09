namespace WeatherGrabber.WebClient.Services.WeatherGrabber
{
    public class WeatherGrabberUnavailableException : WeatherGrabberException
    {
        public WeatherGrabberUnavailableException() : base("WeatherGrabber is unavailable")
        {}
    }
}