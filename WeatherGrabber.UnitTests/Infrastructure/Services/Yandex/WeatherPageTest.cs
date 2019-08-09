using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using WeatherGrabber.Infrastructure;
using WeatherGrabber.Infrastructure.Services.Yandex.Pages;
using Xunit;

namespace WeatherGrabber.UnitTests.Infrastructure.Services.Yandex
{
    public class WeatherPageTest
    {
        private readonly string _pageFull;

        public WeatherPageTest()
        {
            _pageFull = File.ReadAllText(@"Assets\YandexWeatherPage.html");
        }

        [Fact]
        public async Task GetCities_FullPage_Success()
        {
            // Arrange
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult(_pageFull));
            var page = new WeatherPage(new Uri("https://yandex.ru/pogoda/saint-petersburg"), requestProviderMock.Object);

            // Act
            await page.LoadPageAsync();
            var weather = page.GetWeather().ToList();

            // Assert
            Assert.NotEmpty(weather);
        }

        [Fact]
        public async Task GetCities_CorruptedPage_Success()
        {
            // Arrange
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult("Corrupted page"));
            var page = new WeatherPage(new Uri("https://yandex.ru/pogoda/saint-petersburg"), requestProviderMock.Object);

            // Act
            await page.LoadPageAsync();
            var weather = page.GetWeather().ToList();

            // Assert
            Assert.Empty(weather);
        }

        [Fact]
        public async Task GetCities_WeatherInfo_Success()
        {
            // Arrange
            var testDayDate = new DateTime(2019, 8, 9, 0, 0, 0);
            var tempDay = 18;
            var tempNight = -20;
            var comment = "Небольшой дождь";

            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult(_pageFull));
            var page = new WeatherPage(new Uri("https://yandex.ru/pogoda/saint-petersburg"), requestProviderMock.Object);

            // Act
            await page.LoadPageAsync();
            var weather = page.GetWeather().ToList();

            // Assert
            var specialDay = weather.First(d => d.Date.Date == testDayDate.Date);
            Assert.Equal(tempDay, specialDay.TempDay);
            Assert.Equal(tempNight, specialDay.TempNight);
            Assert.Equal(comment, specialDay.Comment);
        }
    }
}
