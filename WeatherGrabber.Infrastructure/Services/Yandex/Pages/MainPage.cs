using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using WeatherGrabber.Infrastructure.Services.Yandex.Pages.Items;

namespace WeatherGrabber.Infrastructure.Services.Yandex.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(Uri pageUrl) : base(pageUrl)
        { }

        public IEnumerable<City> GetCities()
        { 
            var cities = new List<City>();
            if (Content == null)
            {
                return cities;
            }
            //var namesNodes = Content.DocumentNode.SelectNodes("//div[@class='cities_list']/div[@class='cities_item']//span/text()");
            //var hrefsNodes = Content.DocumentNode.SelectNodes("//div[@class='cities_list']/div[@class='cities_item']//a/@href");
            var namesNodes = Content.DocumentNode.SelectNodes("//div[@class='other-cities__city-title']/text()");
            var hrefsNodes = Content.DocumentNode.SelectNodes("//a[contains(@class, 'other-cities__city')][@href]");
            if (namesNodes == null || hrefsNodes == null)
            {
                return cities;
            }
            foreach (var (name, href) in namesNodes.Zip(hrefsNodes, (n ,h) => (n, h)))
            {
                cities.Add(new City
                {
                    Name = name.InnerText,
                    Href = href.Attributes["href"].Value
                });
            }

            return cities;
        }
    }
}
