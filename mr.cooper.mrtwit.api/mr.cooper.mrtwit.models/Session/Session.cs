
using System;

namespace mr.cooper.mrtwit.models.Session
{
    public class Session
    {
        public Guid SessionId{ get; set; }
        public Guid UserId { get; set; }
        public string Device { get; set; }

        public bool IsLoggedIn { get; set; }

        public DateTime LastLoggedIn { get; set; } 
    }
}
  