using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.models
{
   public class Profile
    {
        public string ProfileId { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public  GenderEnum Gender { get; set; }

        public IList<string> Followings { get; set; } 

        public IList<string> Followers { get; set; }

        public string ProfileImageUrl { get; set; }

        public string _id { get; set; }

    }


    public enum GenderEnum
    {
        Male,
        Female,
        Others
    }
}
