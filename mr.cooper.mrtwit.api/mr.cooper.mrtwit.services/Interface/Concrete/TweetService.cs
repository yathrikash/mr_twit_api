using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class TweetService : ITweetService
    {
        private readonly IMrLogger _logger;
        private readonly IDbContext<Tweet> _dbContext;
        private readonly IFeedService _feedService;
        private readonly IProfileService _profileService;

        public TweetService(IMrLogger logger, IDbContext<Tweet> dbContext
                                , IFeedService feedService
                                ,IProfileService profileService
            )
        {
            _logger = logger;
            _dbContext = dbContext;
            _feedService = feedService;
            this._profileService = profileService;
        }

        //public  void ReplyTweet(string tweetId,Tweet replyTweet)
        //{
        //    try
        //    {
        //       var tweet = _dbContext.Get(tweetId)?.FirstOrDefault();
        //        replyTweet._id = Guid.NewGuid().ToString();
        //        replyTweet.TweetId = Guid.NewGuid().ToString();
        //        tweet.Likes = 0;
        //        tweet.TweetedOn = DateTime.Now;
        //        tweet.HashTags = tweet.Content?.Replace("  ", " ")?.Split(' ')?.Where(x => x?.StartsWith('#') == true)?.Select(x => x)?.ToList();
        //        replyTweet.Type = MrTwitEnums.TweetType.Reply;

        //        _dbContext.Add(replyTweet);

        //        if (tweet == null)
        //        {
        //            _logger.Log(LogLevel.Warning, "Tweet not found, cannot add replies.");
        //            return;
        //        }
        //        if (tweet.Replies == null)
        //            tweet.Replies = new List<string>();
        //        if (!tweet.Replies.Contains(replyTweet.Content))
        //        {
        //            tweet.Replies.Add(replyTweet.Content);
        //            _dbContext.Update(tweet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Log(LogLevel.Error, "Something went wrong while following.");
        //        _logger.Log(LogLevel.Error, ex);
        //        throw;
        //    }
        //}
        public void ReplyTweet(string tweetId, string reply)
        {
            try
            {
                var tweet = _dbContext.Get(tweetId)?.FirstOrDefault();

                if (tweet == null)
                {
                    _logger.Log(LogLevel.Warning, "Tweet not found, cannot add replies.");
                    return;
                }
                if (tweet.Replies == null)
                    tweet.Replies = new List<string>();
                
                    tweet.Replies.Add(reply);
                    _dbContext.Update(tweet);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while following.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }




        public void AddTweet(Tweet tweet)
        {
            try
            {
                tweet._id = Guid.NewGuid().ToString();
                tweet.TweetId  = Guid.NewGuid().ToString();
                tweet.Likes = 0;
                tweet.TweetedOn = DateTime.Now;
                tweet.HashTags = tweet.Content?.Replace("  ", " ")?.Split(' ')?.Where(x=>x?.StartsWith('#') ==  true)?.Select(x => x)?.ToList();
                tweet.Type = MrTwitEnums.TweetType.Tweet;
                _dbContext.Add(tweet);

                UpdateFollowersFeed(tweet.UserId, tweet);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong adding profile.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        private void UpdateFollowersFeed(string userId, Tweet tweet)
        {

            var followers = _profileService.GetFollowers(userId);

            foreach(var follow in followers)
            {
                var feed = _feedService.GetFeed(follow);
                if (feed == null) continue;
                feed.Feeds.Add(new FeedContent { TweetedOn = tweet.TweetedOn, TweetId = tweet.TweetId });

                _feedService.AddFeed(feed);
            }
            var feedOwn = _feedService.GetFeed(userId);
            if (feedOwn == null) return;
            feedOwn.Feeds.Add(new FeedContent { TweetedOn = tweet.TweetedOn, TweetId = tweet.TweetId });

            _feedService.AddFeed(feedOwn);
        }

        public IList<Tweet> GetTweet(IList<string> tweetIds)
        {
            try
            {
                return _dbContext.Get(tweetIds)?.ToList(); 
                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while getting followers .");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public void LikeTweet(string tweetId)
        {
            try
            {
                var tweet = _dbContext.Get(tweetId)?.FirstOrDefault();
                tweet.Likes += 1;

                _dbContext.Update(tweet);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while following.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

    }
}
