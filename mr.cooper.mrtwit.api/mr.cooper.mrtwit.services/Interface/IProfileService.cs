using mr.cooper.mrtwit.models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.services.Interface
{
    public  interface IProfileService
    {
        void AddProfile(Profile profileInfro);

        
        IList<string> GetFollowers(string userId);

        IList<string> GetFollowings(string userId);

        void AddFollower(string userId,string followerId);

        void AddFollowing(string userId, string followingId);
        Profile GetProfile(string userId);


    }
}
