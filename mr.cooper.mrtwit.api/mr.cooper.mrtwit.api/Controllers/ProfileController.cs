using Microsoft.AspNetCore.Mvc;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProfileController : ControllerBase
    {
        private readonly IMrLogger _logger;
        private readonly IProfileService _profileService;

        public ProfileController(IMrLogger logger
                                  , IProfileService profileService
                                 )
        {
            _logger = logger;
            _profileService = profileService;
        }

        [HttpGet]
        [Route("{userId}")]
        public  Profile Get(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get user: {userId}");
            return _profileService.GetProfile(userId?.ToLower());
        }

        [HttpGet]
        [Route("{userId}/followers")]
        public IList<string> GetFollower(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get followers of user: {userId}");
            return _profileService.GetFollowers(userId?.ToLower());
        }

        [HttpGet]
        [Route("{userId}/followings")]
        public IList<string> GetFollowings(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get followings of user: {userId}");
            return _profileService.GetFollowings(userId?.ToLower());
        }


        [HttpPost]
        public IActionResult AddProfile([FromBody] Profile userInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for add profile : {userInfo.Name}");
            _profileService.AddProfile(userInfo);
            return Ok();
        }


        [HttpPut]
        [Route("{userId}/addfollower/{followerId}")]
        public IActionResult AddFollower(string userId, string followerId)
        {
            _logger.Log(LogLevel.Info, $"Request received for add follower:{followerId} for : {userId}");

            _profileService.AddFollower(userId?.ToLower(), followerId?.ToLower());
            return Ok();
        }

        [HttpPut]
        [Route("{userId}/addfollowing/{followingId}")]
        public IActionResult AddFollowing(string userId, string followingId)
        {
            _logger.Log(LogLevel.Info, $"Request received for add follower:{followingId} for : {userId}");
            _profileService.AddFollowing(userId?.ToLower(), followingId?.ToLower());
            return Ok();
        }
    }
}
