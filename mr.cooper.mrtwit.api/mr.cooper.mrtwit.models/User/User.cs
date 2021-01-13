using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }

        public string HashedPassword { get; set; }

        public DateTime CreatedOn { get; set; }

        public bool Active { get; set; }

    }
}
