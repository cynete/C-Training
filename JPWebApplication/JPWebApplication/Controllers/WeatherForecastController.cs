using Microsoft.AspNetCore.Mvc;

namespace JPWebApplication.Controllers
{
    [ApiController]
    //[ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [Route("test/GetWeatherForecast")]
        //base route override
        [Route("~/test/WeatherForecast/Get")]
        [HttpGet]
        //[HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [Route("test/GetWeatherForecast2")]
        [HttpGet]
        //[HttpGet(Name = "GetWeatherForecast1")]
        public string Get1()
        {
            return "Hello world. Im from Get1";
        }
    }
}
