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

    public class TweetController : ControllerBase
    {
        private readonly IMrLogger _logger;
        private readonly ITweetService _tweetService;

        public TweetController(IMrLogger logger
                                  , ITweetService tweetService
                                 )
        {
            _logger = logger;
            _tweetService = tweetService;
        }

        [HttpGet]
        [Route("{tweetId}")]
        public Tweet Get(string tweetId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get tweet: {tweetId}");
            return _tweetService.GetTweet(new List<string> { tweetId })?.FirstOrDefault();
        }

        [HttpGet]
        [Route("user/{userId}")]
        public IEnumerable<Tweet> GetTweetsOfUser(string userId)
        {
            _logger.Log(LogLevel.Info, $"Request received for get tweets of user: {userId}");
            return _tweetService.GetTweet(new List<string> { userId });
        }

        [HttpPut]
        [Route("tweets")]
        //User like Odata query to accept multiple ids.
        public IList<Tweet> Get([FromBody] string[] tweetIds)

        {
            _logger.Log(LogLevel.Info, $"Request received for get tweets count: {tweetIds?.Count()}");
            return _tweetService.GetTweet(tweetIds);
        }

        [HttpPut]
        [Route("reply/{tweetId}")]
        public IActionResult ReplyTweet(string tweetId, [FromBody]Tweet reply)
        {
            _logger.Log(LogLevel.Info, $"Request received for reply to :{tweetId} from : {reply?.UserId}");
            _tweetService.ReplyTweet(tweetId,reply);
            return Ok();
        }


        [HttpPost]
        public IActionResult AddTweet([FromBody] Tweet tweet)
        {
            _logger.Log(LogLevel.Info, $"Request received new tweet from : {tweet?.UserId}");
            _tweetService.AddTweet(tweet);
            return Ok();
        }

        [HttpPut]
        [Route("like/{tweetId}")]
        ///For simplicity just added likes, not added who liked
        public IActionResult LikeTweet(string tweetId)
        {
            _logger.Log(LogLevel.Info, $"Request received for liking tweet :{tweetId}.");
            _tweetService.LikeTweet(tweetId);
            return Ok();
        }


    }
}
