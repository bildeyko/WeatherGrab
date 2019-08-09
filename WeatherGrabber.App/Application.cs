using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherGrabber.Domain.Contracts;
using WeatherGrabber.Domain.Exceptions;
using WeatherGrabber.Domain.Models;

namespace WeatherGrabber.App
{
    internal class Application : IDisposable
    {
        private readonly IWeatherProviderService _weatherProvider;
        private readonly ICityWeatherInfoRepository _weatherRepository;

        private readonly Task _checkTask;
        private readonly CancellationTokenSource _tokenSource;

        public Application(IWeatherProviderService weatherProvider, ICityWeatherInfoRepository weatherRepository)
        {
            _weatherProvider = weatherProvider;
            _weatherRepository = weatherRepository;

            _tokenSource = new CancellationTokenSource();
            _checkTask = Task.Factory.StartNew(async () => await RunAsync(_tokenSource.Token), _tokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public void Dispose()
        {
            if (_tokenSource == null)
            {
                return;
            }

            _tokenSource.Cancel();
            _checkTask.Wait();
            _tokenSource.Dispose();
        }

        private async Task RunAsync(CancellationToken ct)
        {
            var sleepPeriod = new TimeSpan(0,0,10);

            while (true)
            {
                int addedCities = 0, updatedCities = 0;
                var weatherDate = DateTime.Now.AddDays(1);

                try
                {
                    if (ct.IsCancellationRequested)
                    {
                        ct.ThrowIfCancellationRequested();
                    }

                    var cities = await _weatherProvider.GetCitiesAsync();

                    var localWeatherData = _weatherRepository.GetAll();
                    foreach (var city in cities)
                    {
                        var weatherForCity = localWeatherData.FirstOrDefault(w => w.Name.Equals(city.Name));
                        var weatherOnDate = await GetWeatherOnDate(city, weatherDate);
                        if (weatherForCity == null)
                        {
                            var newCity = new CityWeatherInfo
                            {
                                Name = city.Name,
                                TempDay = weatherOnDate.TempDay,
                                TempNight = weatherOnDate.TempNight,
                                WeatherComment = weatherOnDate.WeatherComment
                            };
                            _weatherRepository.Create(newCity);
                            addedCities++;
                            continue;
                        }

                        weatherForCity.TempDay = weatherOnDate.TempDay;
                        weatherForCity.TempNight = weatherOnDate.TempNight;
                        weatherForCity.WeatherComment = weatherOnDate.WeatherComment;
                        _weatherRepository.Update(weatherForCity);
                        updatedCities++;
                    }

                    Console.WriteLine($"Added: {addedCities}, Updated:{updatedCities}");
                    ct.WaitHandle.WaitOne(sleepPeriod);
                }
                catch (CityWeatherInfoRepositoryException e)
                {
                    Console.WriteLine("Database Error");
                    Console.WriteLine(e.ToString());
                    break;
                }
                catch (WeatherProviderServiceException e)
                {
                    Console.WriteLine("Weather provider Error");
                    Console.WriteLine(e.ToString());
                    break;
                }
                catch (OperationCanceledException)
                {
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    throw;
                }
            }
        }

        private async Task<Weather> GetWeatherOnDate(City city, DateTime date)
        {
            var weatherLiveData = await _weatherProvider.GetWeatherAsync(city.WeatherUrl);
            return weatherLiveData.FirstOrDefault(w => w.Date.Date == date.Date);
        }
    }
}
