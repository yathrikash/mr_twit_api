using Microsoft.AspNetCore.Mvc;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.services.Interface;
using System;
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
        [Route("profiles/{userId}")]
        public  Profile Get(string userId)
        {
            if (!Guid.TryParse(userId, out Guid tempUserId))
                throw new ArgumentException($"Invalid Userid {userId}.");

            return _profileService.GetProfile(tempUserId);
        }
    }
}
