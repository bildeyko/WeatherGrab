using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherGrabber.WebClient.Services.WeatherGrabber;
using WeatherGrabber.WebClient.Services.WeatherGrabber.DTO;
using WeatherGrabber.WebClient.ViewModels;

namespace WeatherGrabber.WebClient.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IWeatherGrabberService _weatherService;

        public IndexModel(IWeatherGrabberService weatherService)
        {
            _weatherService = weatherService;
        }

        public IList<CityWeatherInfoViewModel> Cities { get; set; }
        public CityWeatherInfoViewModel SelectedCity { get; set; }

        public async Task OnGet(int? id)
        {
            var cities = await _weatherService.GetCitiesAsync();
            Cities = cities.Select(c => new CityWeatherInfoViewModel
            {
                CityId = c.CityId,
                Name = c.Name,
                TempDay = c.TempDay,
                TempNight = c.TempNight,
                WeatherComment = c.WeatherComment
            }).ToList();
            if (id != null)
            {
                SelectedCity = Cities.FirstOrDefault(c => c.CityId == id.Value);
            }
        }
    }
}
