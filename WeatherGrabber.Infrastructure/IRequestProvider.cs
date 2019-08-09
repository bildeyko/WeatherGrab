using System;
using System.Threading.Tasks;

namespace WeatherGrabber.Infrastructure
{
    public interface IRequestProvider
    {
        Task<string> GetAsync(Uri uri);
    }
}