namespace Company.Application1.Tests;

using Company.Application1.Controllers;
using Company.Application1.Models;
using Microsoft.Extensions.Logging;

public class WeatherForecastTests
{
    [Fact]
    public void Get_Ok_ReturnList()
    {
        // arrange
        var log = new Mock<ILogger<WeatherForecastController>>();
        var controller = new WeatherForecastController(log.Object);

        // act
        var result = controller.Get();

        // assert
        Assert.IsType<IEnumerable<WeatherForecast>>(result);
        Assert.NotEmpty(result);
    }
}
