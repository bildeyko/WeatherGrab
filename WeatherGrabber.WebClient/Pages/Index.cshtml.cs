using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherGrabber.WebClient.Services.WeatherGrabber;
using WeatherGrabber.WebClient.Services.WeatherGrabber.DTO;

namespace WeatherGrabber.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWeatherGrabberService _weatherService;

        public IndexModel(IWeatherGrabberService weatherService)
        {
            _weatherService = weatherService;
        }

        public IList<CityWeatherInfo> Cities { get; set; }
        public CityWeatherInfo SelectedCity { get; set; }

        public async Task OnGet(int? id)
        {
            Cities = await _weatherService.GetCitiesAsync();
            if (id != null)
            {
                SelectedCity = Cities.FirstOrDefault(c => c.CityId == id.Value);
            }
        }
    }
}
