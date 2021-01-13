using Microsoft.AspNetCore.Mvc;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.services.Interface;

namespace mr.cooper.mrtwit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class UserController : ControllerBase
    {
        private readonly IMrLogger _logger;
        private readonly IUserService _userService;

        public UserController(IMrLogger logger
                                  , IUserService userService
                                 )
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        [Route("{userId}")]
        public  User Get(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get user: {userId}");

            return _userService.GetUser(userId);
        }


        [HttpPost]
        public IActionResult AddUser([FromBody] User userInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for add user: {userInfo.UserName}");
            _userService.AddUser(userInfo);
            return Ok();
        }

    }
}
