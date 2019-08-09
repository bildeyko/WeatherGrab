using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.Infrastructure
{
    public class RequestProvider : IRequestProvider
    {
        public async Task<string> GetAsync(Uri uri)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(uri);
            var contentStr = await response.Content.ReadAsStringAsync();
            return contentStr;
        }
    }
}
