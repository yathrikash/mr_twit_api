using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.models
{
   public class Profile
    {
        public Guid ProfileId { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public  GenderEnum Gender { get; set; }

        public IList<Guid> Following { get; set; }

        public IList<Guid> Followers { get; set; }

        public string ProfileImageUrl { get; set; }

    }


    public enum GenderEnum
    {
        Male,
        Female,
        Others
    }
}
