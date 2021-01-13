﻿using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class UserDBContext : MongoDbContext<User>
    {
        public const string UserDbCollection = "UserDbCollectionName";
        public UserDBContext(AppConfig config):base(config,UserDbCollection)
        {
            
        }
        
        public override void Add(User data)
        {
            Collection.InsertOne(data);
        }

        public override IEnumerable<User> Get(string userId)
        {
            return Collection.Find<User>(x => x.UserId == userId).ToEnumerable();
        }
    }
}
