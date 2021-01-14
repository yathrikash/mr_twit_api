
using System;

namespace mr.cooper.mrtwit.models
{
    public class Session
    {
        public string _id { get; set; }

        public string  SessionId{ get; set; }
        public string  UserId { get; set; }

        public string UserName { get; set; }
        public string Device { get; set; }

        public bool IsLoggedIn { get {
                return !string.IsNullOrEmpty(AuthKey);
            }  }

        public DateTime LastLoggedIn { get; set; } 

        public string AuthKey { get; set; }
    }
}
  