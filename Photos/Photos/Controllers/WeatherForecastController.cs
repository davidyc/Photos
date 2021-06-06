using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Photos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Photos.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();

            var db = new PhotosDBContext();
            var test = db.Test;


            return test.Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index.Id),
                TemperatureC = rng.Next(-20, 55),
                Summary = index.Test
            })
            .ToArray();
        }
    }
}
