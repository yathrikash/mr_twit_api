using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class ProfileDBContext : MongoDbContext<Profile>
    {
        public const string ProfileDbCollection = "ProfileDbCollectionName";
        public ProfileDBContext(AppConfig config):base(config,ProfileDbCollection)
        {
            
        }
        
        public void Add(Profile data)
        {
            base.Add(data);
        }
    }
}
