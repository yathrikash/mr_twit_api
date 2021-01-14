using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class TweetDBContext : MongoDbContext<Tweet>
    {
        public const string TweetDbCollection = "TweetDbCollectionName";
        public TweetDBContext(AppConfig config):base(config,TweetDbCollection)
        {
            
        }


        public override void Add(Tweet data)
        {
            Collection.InsertOne(data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId or TweetId based on your requirement"></param>
        /// <returns></returns>
        public override IEnumerable<Tweet> Get(string id)
        {
            return Collection.Find<Tweet>(x => x.UserId == id || x.TweetId == id)?.ToEnumerable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIds or TweetIds based on your requirement"></param>
        /// <returns></returns>
        public override IEnumerable<Tweet> Get(IList<string> ids)
        {
            return Collection.Find<Tweet>(x => ids.Contains(x.UserId )|| ids.Contains(x.TweetId))?.ToEnumerable();
        }


        public override void Update(Tweet updatedData)
        {
            var filter = Builders<Tweet>.Filter.Eq(s => s.TweetId, updatedData.TweetId);
                                                
            var update = Builders<Tweet>.Update
                            .Set(s => s.Likes, updatedData.Likes)
                            .Set(s => s.Replies, updatedData.Replies)
                            .Set(s => s.HashTags, updatedData.HashTags);
            Collection.UpdateMany(filter, update);
        }

    }
}
