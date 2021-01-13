using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class ProfileService : IProfileService
    {
        private readonly IMrLogger _logger;
        private readonly IDbContext<Profile> _dbContext;

        public ProfileService(IMrLogger logger, IDbContext<Profile> dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public  void AddFollower(string userId, string followerId)
        {
            try
            {
                var profile= _dbContext.Get(userId)?.FirstOrDefault();

                if (profile == null)
                {
                    _logger.Log(LogLevel.Warning, "Profile not found, follower cannot be added.");
                    return;
                }
                if (profile.Followers== null)
                    profile.Followers  = new List<string>();

                if (!profile.Followers.Contains(followerId))
                {
                    profile.Followers.Add(followerId);
                    _dbContext.Update(profile);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while adding follower.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public  void AddFollowing(string userId,string followingId)
        {
            try
            {
               var profile = _dbContext.Get(userId)?.FirstOrDefault(); 
                
                if (profile == null)
                {
                    _logger.Log(LogLevel.Warning, "Profile not found, cannot add following.");
                    return;
                }
                if (profile.Followings == null)
                    profile.Followings = new List<string>();
                if (!profile.Followings.Contains(followingId))
                {
                    profile.Followings.Add(followingId);
                    _dbContext.Update(profile);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while following.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public void AddProfile(Profile profileInfro)
        {
            try
            {
                profileInfro._id = Guid.NewGuid().ToString();
                profileInfro.ProfileId = Guid.NewGuid().ToString();
                _dbContext.Add(profileInfro);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong adding profile.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public IList<string> GetFollowers(string userId)
        {
            try
            {
                return _dbContext.Get(userId)?.FirstOrDefault()?.Followers; 
                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while getting followers .");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public IList<string> GetFollowings(string userId)
        {
            try
            {
                return  _dbContext.Get(userId)?.FirstOrDefault()?.Followings; 
                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while getting Followings .");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public  Profile GetProfile(string userId)
        {
            try
            {
             return _dbContext.Get(userId)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Error, "Something went wrong while getting profile .");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

    }
}
