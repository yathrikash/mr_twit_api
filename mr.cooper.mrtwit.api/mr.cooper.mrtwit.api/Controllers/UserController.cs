using Microsoft.AspNetCore.Mvc;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.services.Interface;
using System.Collections.Generic;

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



        [HttpGet]
        [Route("")]
        public IList<string> Get()
        {
            _logger.Log(LogLevel.Info, $"Request received for get all user");

            return _userService.GetUser();
        }



        [HttpPost]
        public IActionResult AddUser([FromBody] UserWithProfile userInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for add user: {userInfo.UserInfo.UserName}");
            _userService.AddUser(userInfo);
            return Ok();
        }

        [HttpPost]
        [Route("signin")]

        public IActionResult SignIn([FromBody] SignIn userInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for sign in : {userInfo.UserName}");
            var session = _userService.SignIn(userInfo);
            return Ok(session);
        }

        [HttpPut]
        [Route("signout")]
        public IActionResult SignOut([FromBody] SignIn userInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for sign out : {userInfo.UserName}");
             _userService.SignOut(userInfo.UserName,userInfo.Device);
            return Ok();
        }

        [HttpPut]
        [Route("isValidUser")]
        public IActionResult IsValidUser([FromBody] Session sessoinInfo)
        {
            _logger.Log(LogLevel.Info, $"Request received for validate user  : {sessoinInfo.UserName}");
           var res =  _userService.IsValidUser(sessoinInfo);
            return Ok(res);
        }

    }
}
