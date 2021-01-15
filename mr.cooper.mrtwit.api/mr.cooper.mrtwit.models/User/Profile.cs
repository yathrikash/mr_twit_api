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

        public IList<string> Followings { get; set; } = new List<string>();

        public IList<string> Followers { get; set; } = new List<string>();

        public string ProfileImageUrl { get; set; } = string.Empty;

        public string _id { get; set; }

    }


    public enum GenderEnum
    {
        Male,
        Female,
        Others
    }
}
