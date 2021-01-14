using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class FeedDBContext : MongoDbContext<Feed>
    {
        public const string FeedDbCollection = "FeedDbCollectionName";
        public FeedDBContext(AppConfig config):base(config, FeedDbCollection)
        {
            
        }
        
        public override void Add(Feed data)
        {
            var feed = this.Get(data.UserId)?.FirstOrDefault();
            if (feed == null)
                Collection.InsertOne(data);
            else
            {
                var filter = Builders<Feed>.Filter.Eq(s => s.UserId, data.UserId);

                var update = Builders<Feed>.Update
                                .Set(s => s.Feeds, data.Feeds);

                Collection.UpdateMany(filter, update);
            }
        }

        public override IEnumerable<Feed> Get(string userId)
        {
            return Collection.Find<Feed>(x => x.UserId == userId).ToEnumerable();
        }
    }
}
