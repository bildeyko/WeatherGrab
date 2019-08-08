using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherGrabber.Infrastructure.Services.Yandex.Pages
{
    public class BasePage
    {
        private string _contentStr;
        private Uri _pageUrl;

        protected HtmlDocument Content;

        public BasePage(Uri pageUrl)
        {
            _pageUrl = pageUrl;
            Content = new HtmlDocument();
        }

        public async Task LoadPageAsync()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_pageUrl);
            _contentStr = await response.Content.ReadAsStringAsync();
            Content.LoadHtml(_contentStr);
        }
    }
}
