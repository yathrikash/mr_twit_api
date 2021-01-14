using System;

namespace mr.cooper.mrtwit.models
{
    public class User
    {
        public string _id { get; set; }

        public string  UserId { get; set; }
        public string UserName { get; set; }
        
        public string HashedPassword { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Active { get; set; }

    }
}
