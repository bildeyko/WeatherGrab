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
        private readonly IRequestProvider _requestProvider;

        protected HtmlDocument Content;

        public BasePage(Uri pageUrl, IRequestProvider requestProvider)
        {
            _pageUrl = pageUrl;
            _requestProvider = requestProvider;
            Content = new HtmlDocument();
        }

        public async Task LoadPageAsync()
        {
            _contentStr = await _requestProvider.GetAsync(_pageUrl);
            Content.LoadHtml(_contentStr);
        }
    }
}
