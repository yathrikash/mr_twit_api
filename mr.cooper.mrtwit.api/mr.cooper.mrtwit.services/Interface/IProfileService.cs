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

        
        IList<Guid> GetFollowers(Guid userId);

        IList<Guid> GetFollowings(Guid userId);

        void AddFollower(Guid userId,Guid followerId);

        void AddFollowing(Guid userId, Guid followingId);
        Profile GetProfile(Guid userId);


    }
}
