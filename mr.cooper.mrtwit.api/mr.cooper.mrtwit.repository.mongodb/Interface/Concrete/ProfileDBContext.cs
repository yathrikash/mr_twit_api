using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class ProfileDBContext : MongoDbContext<Profile>
    {
        public const string ProfileDbCollection = "ProfileDbCollectionName";
        public ProfileDBContext(AppConfig config):base(config,ProfileDbCollection)
        {
            
        }
        
        


        public  override void Add(Profile data)
        {
            Collection.InsertOne(data);
        }

        public override   IEnumerable<Profile> Get(Guid userId)
        {
         return  Collection.Find<Profile>(x => x.UserId == userId).ToEnumerable();
        }



        public override void Update(Profile updatedData)
        {
            var filter = Builders<Profile>.Filter.Eq(s => s.UserId, updatedData.UserId);
            var update = Builders<Profile>.Update
                            .Set(s => s.Followers, updatedData.Followers)
                            .Set(s => s.Followings, updatedData.Followings);
            Collection.UpdateMany(filter, update);
        }

       



    }
}
