using Microsoft.AspNetCore.Mvc;
using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.services.Interface;

namespace mr.cooper.mrtwit.api.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class FeedController : ControllerBase
    {
        private readonly IMrLogger _logger;
        private readonly IFeedService _feedService;

        public FeedController(IMrLogger logger
                                  , IFeedService feedService
                                 )
        {
            _logger = logger;
            _feedService = feedService;
        }

        [HttpGet]
        [Route("{userId}")]
        public  Feed Get(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get user: {userId}");

            return _feedService.GetFeed(userId);
        }


    }
}
