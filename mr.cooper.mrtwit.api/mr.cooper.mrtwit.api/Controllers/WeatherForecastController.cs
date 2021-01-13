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
        private readonly IProfileService _profileService;
      


        public WeatherForecastController(IMrLogger logger, IProfileService profileService)
        {
            
            _logger = logger;
            _profileService = profileService;
           
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var userId = Guid.NewGuid();
            var followerId = Guid.NewGuid();
            var followingId = Guid.NewGuid();
            _profileService.AddProfile(new Profile
            {
                Name = "Prakash",
                Gender = GenderEnum.Male,
                UserId = userId
            });

            _profileService.AddFollowing(userId,followingId);
            _profileService.AddFollower(userId, followerId);

            var followers = _profileService.GetFollowers(userId);
            var followings = _profileService.GetFollowings(userId);
            var profile = _profileService.GetProfile(userId);
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
