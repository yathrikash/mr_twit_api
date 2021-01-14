using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using System;
using System.Linq;

namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class UserService :IUserService
    {
        private readonly IDbContext<Session> _dbSessionContext;
        private readonly IProfileService _profileService;

        public IMrLogger _logger { get; }
        public IDbContext<User> _dbContext { get; }
        public UserService(IMrLogger logger, IDbContext<User> dbContext,
            IDbContext<Session> dbSessionContext,
            IProfileService profileService
            
            )
        {
            _logger = logger;
            _dbContext = dbContext;
            this._dbSessionContext = dbSessionContext;
            this._profileService = profileService;
        }

       

        public void AddUser(UserWithProfile userInfo)
        {
            try
            {
                userInfo.UserInfo.UserId = Guid.NewGuid().ToString();
                userInfo.UserInfo.CreatedOn = DateTime.Now;
                userInfo.UserInfo._id = Guid.NewGuid().ToString();
                _dbContext.Add(userInfo.UserInfo);

                userInfo.ProfileInfo.UserId = userInfo.UserInfo.UserId;
                _profileService.AddProfile(userInfo.ProfileInfo);

                
                 _logger.Log(LogLevel.Info, "User Successfully created.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "User creation failed.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public User GetUser(string userName)
        {
            try
            {
                return _dbContext.Get(userName)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "Something went wrong while fetching user.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public Session SignIn(SignIn userInfo)
        {
            var userDbDetails = this.GetUser(userInfo.UserName);
            var userSession = new Session() {
                AuthKey = userInfo.Password,
                Device = userInfo.Device,
                LastLoggedIn = DateTime.Now,
                SessionId = Guid.NewGuid().ToString(),
                _id = Guid.NewGuid().ToString(),
                UserId = userDbDetails.UserId,
                UserName = userDbDetails.UserName
            };

            _dbSessionContext.Add(userSession);
            return userSession;
        }

        public bool IsValidUser(Session ses)
        {
            var userInfo = this.GetUser(ses.UserName);

            var session = _dbSessionContext.Get(userInfo.UserId)?.Where(x=>x.Device == ses.Device)?.FirstOrDefault();
            return session != null && session.IsLoggedIn && ses.AuthKey == session.AuthKey;
        }

        public void SignOut(string userName,string device)
        {
            var userInfo = this.GetUser(userName);

            var session = _dbSessionContext.Get(userInfo.UserId)?.Where(x => x.Device == device)?.FirstOrDefault();
            session.AuthKey = null;
            _dbSessionContext.Update(session);
        }

        
    }
}
