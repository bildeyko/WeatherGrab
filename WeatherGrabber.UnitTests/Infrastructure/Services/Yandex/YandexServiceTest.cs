using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using WeatherGrabber.Infrastructure;
using WeatherGrabber.Infrastructure.Services.Yandex;
using Xunit;

namespace WeatherGrabber.UnitTests.Infrastructure.Services.Yandex
{
    public class YandexServiceTest
    {
        private readonly string _pageFull;

        public YandexServiceTest()
        {
            _pageFull = File.ReadAllText(@"Assets\YandexWeatherPage.html");
        }

        [Fact]
        public async Task GetCities_Success()
        {
            // Arrange
            var citiesCount = 14;
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult(_pageFull));
            var service = new YandexService(requestProviderMock.Object);

            // Act
            var cities = await service.GetCitiesAsync();

            // Assert
            var citiesList = cities.ToList();
            Assert.NotEmpty(citiesList);
            Assert.Equal(citiesCount, citiesList.Count);
        }

        [Fact]
        public async Task GetWeatherAsync_Success()
        {
            // Arrange
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(new Uri("https://yandex.ru/pogoda/saint-petersburg")))
                               .Returns(Task.FromResult(_pageFull));
            var service = new YandexService(requestProviderMock.Object);

            // Act
            var weather = await service.GetWeatherAsync("https://yandex.ru/pogoda/saint-petersburg");

            // Assert
            Assert.NotEmpty(weather);
        }
    }
}
