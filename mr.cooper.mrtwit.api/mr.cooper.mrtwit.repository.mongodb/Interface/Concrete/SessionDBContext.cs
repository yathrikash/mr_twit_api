using MongoDB.Driver;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.models.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mr.cooper.mrtwit.repository.mongodb.Interface.Concrete
{
    public class SessionDBContext : MongoDbContext<Session>
    {
        public const string SessionDbCollection = "SessionDbCollectionName";
        public SessionDBContext(AppConfig config):base(config, SessionDbCollection)
        {
            
        }
        
        public override void Add(Session data)
        {
            var session = this.Get(data.UserId)?.Where(x=>x.Device== data.Device)?.FirstOrDefault();
            if (session == null)
                Collection.InsertOne(data);
            else
            {
                session.LastLoggedIn = DateTime.Now;
                this.Update(session);
            }
        }


        public override void Update(Session data)
        {
            var session = this.Get(data.UserId)?.Where(x => x.Device == data.Device)?.FirstOrDefault();
            if (session != null)
               
            {
                var filterId = Builders<Session>.Filter.Eq(s => s.UserId, data.UserId);
                var filterDevice = Builders<Session>.Filter.Eq(s => s.Device, data.Device);
                var filterAnd = Builders<Session>.Filter.And(filterId, filterDevice);
                var update = Builders<Session>.Update
                                .Set(s => s.AuthKey, data.AuthKey)
                                .Set(s => s.LastLoggedIn, data.LastLoggedIn)
                ;

                Collection.UpdateMany(filterAnd, update);
            }
        }


        public override void Delete(string sessionId)
        {
            Collection.DeleteMany(x => x.SessionId== sessionId);
        }

        public override IEnumerable<Session> Get(string userId)
        {
            return Collection.Find<Session>(x => x.UserId == userId)?.ToEnumerable();
        }
    }
}
