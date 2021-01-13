using MongoDB.Bson;
using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public abstract class MongoDbContext<T> : IDbContext<T> where T : class
    {
        private readonly IMongoDatabase _database = null;

        public MongoDbContext(AppConfig settings,string collectionNameInConfig)
        {
            var client = new MongoClient(settings.MongoConnectionName.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.MongoConnectionName.DataBaseName);
            if (settings.MongoConnectionName.CollectionNames.ContainsKey(collectionNameInConfig))
                InitializeCollection(settings.MongoConnectionName.CollectionNames[collectionNameInConfig]);
            else
                throw new ApplicationException($"Collection not initialized, please check the config whether '{collectionNameInConfig}' collection information available.");
        }

        public IMongoCollection<T> Collection { get; private set; }

        public virtual void Add(T data)
        {
            //Collection.InsertOne(data );
        }

        public virtual IEnumerable<T> Get(string userId)
        {
            return null;
        }

        public virtual void Update(T updatedData)
        {
           
    }

        private void InitializeCollection(string collectionName)
        {
            Collection = _database.GetCollection<T>(collectionName);
        }


        
       

    }
}