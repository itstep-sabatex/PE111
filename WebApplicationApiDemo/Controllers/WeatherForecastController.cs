using Microsoft.AspNetCore.Mvc;
using WebApplicationApiDemo.Services;

namespace WebApplicationApiDemo.Controllers
{
    [ApiController]
    //[Route("api/[controller]")] // api/v0/myFirstApi
    [Route("api/v0/myFirstApi")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly DateService _dateService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,DateService dateService)
        {
            _logger = logger;
            _dateService = dateService;
        }
        [HttpGet("CreatedDate")]
        public DateTime GetDataServiceCrete()
        {
            return _dateService.CreateDate;
        }

        //[HttpGet(Name = "GetWeatherForecast")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("ver2")]
        public IEnumerable<WeatherForecast> Get2()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("stringTest")] //{utcTime,localTime}
        public string GetString()
        {
            return "Hello World";
        }

    }
}