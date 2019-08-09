using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherGrabber.Infrastructure.Services.Yandex.Pages.Items;

namespace WeatherGrabber.Infrastructure.Services.Yandex.Pages
{
    public class WeatherPage : BasePage
    {
        public WeatherPage(Uri pageUrl) : base(pageUrl)
        {
        }

        public IEnumerable<Weather> GetWeather()
        {
            var weather = new List<Weather>();
            if (Content == null)
            {
                return weather;
            }

            var datesNodes = Content.DocumentNode.SelectNodes("//div[@class='swiper-wrapper']//time/@datetime");
            var dayTempNodes = Content.DocumentNode.SelectNodes("//div[@class='swiper-wrapper']//div[contains(@class, 'temp_day')]//span[contains(@class, 'temp__value')]/text()");
            var nightTempNodes = Content.DocumentNode.SelectNodes("//div[@class='swiper-wrapper']//div[contains(@class, 'temp_night')]//span[contains(@class, 'temp__value')]/text()");
            var commentTempNodes = Content.DocumentNode.SelectNodes("//div[@class='swiper-wrapper']//div[@class='forecast-briefly__condition']/text()");

            if (datesNodes == null || dayTempNodes == null
                || nightTempNodes == null || commentTempNodes == null)
            {
                return weather;
            }
            for (int i = 0; i < datesNodes.Count; i++)
            {
                var tempDayStr = dayTempNodes[i].InnerText;
                if (tempDayStr.StartsWith("+"))
                {
                    tempDayStr = tempDayStr.TrimStart('+');
                }
                int.TryParse(tempDayStr, out var tempDay);

                var tempNightStr = nightTempNodes[i].InnerText;
                if (tempNightStr.StartsWith("+"))
                {
                    tempNightStr = tempNightStr.TrimStart('+');
                }
                int.TryParse(tempNightStr, out var tempNight);

                weather.Add(new Weather
                {
                    Date = DateTime.Parse(datesNodes[i].Attributes["datetime"].Value),
                    TempDay = tempDay,
                    TempNight = tempNight,
                    Comment = commentTempNodes[i].InnerText
                });
            }

            return weather;
        }
    }
}
