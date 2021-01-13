

namespace mr.cooper.mrtwit.models.Configuration
{
    public class MongoConnection
    {
        public string ConnectionString { get; set; }

        public string DataBaseName { get; set; }

        public CollectionDictionary CollectionNames { get; set; } = new CollectionDictionary();

        //public string UserDbCollectionName { get; set; }
        //public string ProfileDbCollectionName { get; set; }

    }
}
