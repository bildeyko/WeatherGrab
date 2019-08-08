using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.Domain.Models
{
    public class City
    {
        public City(string name, string weatherUrl)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            WeatherUrl = weatherUrl ?? throw new ArgumentNullException(nameof(weatherUrl));
        }

        public string Name { get; }
        public string WeatherUrl { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{nameof(City)}: ");
            sb.Append($"{nameof(Name)} = {Name}, ");
            sb.Append($"{nameof(WeatherUrl)} = {WeatherUrl}");
            return sb.ToString();
        }
    }
}
