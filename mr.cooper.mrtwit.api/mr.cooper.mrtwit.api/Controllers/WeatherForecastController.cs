using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using mr.cooper.mrtwit.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly IMrLogger _logger;
        private readonly IUserService _userService;
      


        public WeatherForecastController(IMrLogger logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
           
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {

            _userService.AddUser(new User {UserName = "Prakash" });


               var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
