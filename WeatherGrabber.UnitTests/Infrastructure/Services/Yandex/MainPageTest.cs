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
    public class MainPageTest
    {
        private string _pageFull;

        public MainPageTest()
        {
            _pageFull = File.ReadAllText(@"Assets\YandexWeatherPage.html");
        }

        [Fact]
        public async Task GetCities_FullPage_Success()
        {
            // Arrange
            var citiesCount = 14;
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult(_pageFull));
            var page = new MainPage(new Uri("https://yandex.ru/pogoda"), requestProviderMock.Object);

            // Act
            await page.LoadPageAsync();
            var cities = page.GetCities().ToList();

            // Assert
            Assert.Equal(citiesCount, cities.Count);
            Assert.Equal("Калининград", cities[citiesCount-1].Name);
        }

        [Fact]
        public async Task GetCities_CorruptedPage_Success()
        {
            // Arrange
            var citiesCount = 0;
            var requestProviderMock = new Mock<IRequestProvider>();
            requestProviderMock.Setup(x => x.GetAsync(It.IsAny<Uri>())).Returns(Task.FromResult("Corrupted page"));
            var page = new MainPage(new Uri("https://yandex.ru/pogoda"), requestProviderMock.Object);

            // Act
            await page.LoadPageAsync();
            var cities = page.GetCities().ToList();

            // Assert
            Assert.Equal(citiesCount, cities.Count);
        }
    }
}
