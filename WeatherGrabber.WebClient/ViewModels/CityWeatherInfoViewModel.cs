namespace WeatherGrabber.WebClient.ViewModels
{
    public class CityWeatherInfoViewModel
    {
        public int CityId { get; set; }
        public string Name { get; set; }
        public int TempNight { get; set; }
        public int TempDay { get; set; }
        public string WeatherComment { get; set; }

        public string TempNightBeauty => TempNight > 0 ? $"+{TempNight}" : $"{TempNight}";
        public string TempDayBeauty => TempDay > 0 ? $"+{TempDay}" : $"{TempDay}";
    }
}