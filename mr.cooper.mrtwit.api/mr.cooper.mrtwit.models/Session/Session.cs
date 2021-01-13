
using System;

namespace mr.cooper.mrtwit.models.Session
{
    public class Session
    {
        public string _id { get; set; }

        public string  SessionId{ get; set; }
        public string  UserId { get; set; }
        public string Device { get; set; }

        public bool IsLoggedIn { get; set; }

        public DateTime LastLoggedIn { get; set; } 
    }
}
  