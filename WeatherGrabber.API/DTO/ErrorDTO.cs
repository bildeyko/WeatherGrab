using System.Runtime.Serialization;

namespace WeatherGrabber.API.DTO
{
    [DataContract]
    public class ErrorDTO
    {
        public ErrorDTO(string message)
        {
            Message = message;
        }

        [DataMember]
        public string Message { get;}
    }
}