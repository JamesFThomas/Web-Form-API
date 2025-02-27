/*using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_Form_API.Classes;
using static Web_Form_API.Controllers.WeatherForecastController;

namespace Web_Form_API.Controllers
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
        [Route("GetAllForecasts")]
        public IEnumerable<WeatherForecast> GetAllForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {

                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]
        [Route("GetForecast")]
        public WeatherForecast GetForecast()
        {
            var rng = new Random();
            return new WeatherForecast()
            {
                Date = DateTime.UtcNow,
                TemperatureC = 157,
                Summary = Summaries[6]
            };
        }

        [HttpGet]
        [Route("GetInfo")]
        public string GetInfo(string info)
        {
            return $"The information sent in your request is: {info}";
        }


        [HttpPost]
        [Route("PostPersonalData")]
        public string PostPersonalData([FromBody]Person personData )
        {
            return $"{personData.FirstName} {personData.LastName} is a wonderful person";
        }

    }
}
*/