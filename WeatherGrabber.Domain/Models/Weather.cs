using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherGrabber.Domain.Models
{
    public class Weather
    {
        public Weather(DateTime date, int tempDay, int tempNight, string weatherComment)
        {
            Date = date;
            TempNight = tempNight;
            TempDay = tempDay;
            WeatherComment = weatherComment;
        }

        public DateTime Date { get; }
        public int TempNight { get; }
        public int TempDay { get; }
        public string WeatherComment { get; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{nameof(Weather)}: ");
            sb.Append($"{nameof(Date)} = {Date}, ");
            sb.Append($"{nameof(TempNight)} = {TempNight}, ");
            sb.Append($"{nameof(TempDay)} = {TempDay}, ");
            sb.Append($"{nameof(WeatherComment)} = {WeatherComment}");
            return sb.ToString();
        }
    }
}
