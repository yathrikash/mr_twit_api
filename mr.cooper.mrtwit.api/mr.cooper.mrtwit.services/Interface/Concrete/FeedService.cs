using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using System;
using System.Linq;

namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class FeedService :IFeedService
    {
        public IMrLogger _logger { get; }
        public IDbContext<Feed> _dbContext { get; }
        public FeedService(IMrLogger logger, IDbContext<Feed> dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

       

        public void AddFeed(Feed feed)
        {
            try
            {
                if(feed._id == null)
                    feed._id = Guid.NewGuid().ToString();

                _dbContext.Add(feed);
                 _logger.Log(LogLevel.Info, "Feeds  Successfully added.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "Feed addition failed.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public Feed GetFeed(string userId)
        {
            try
            {
                return _dbContext.Get(userId)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "Something went wrong while fetching feed.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

       
    }
}
