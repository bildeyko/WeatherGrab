using System.ServiceModel;
using System.ServiceModel.Web;
using WeatherGrabber.API.DTO;

namespace WeatherGrabber.API
{
    [ServiceContract]
    public interface IWeatherService
    {
        [WebGet(UriTemplate = "Cities", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        CitiesResponse GetCities();
    }
}
