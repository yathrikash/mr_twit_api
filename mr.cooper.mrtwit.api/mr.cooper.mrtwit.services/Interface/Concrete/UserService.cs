using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using mr.cooper.mrtwit.repository.mongodb.Interface.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class UserService :IUserService
    {
        public IMrLogger _logger { get; }
        public IDbContext<User> _dbContext { get; }
        public UserService(IMrLogger logger, IDbContext<User> dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

       

        public void AddUser(User userInfo)
        {
            try
            {
                userInfo.UserId = Guid.NewGuid().ToString();
                userInfo.CreatedOn = DateTime.Now;
                userInfo._id = Guid.NewGuid().ToString();
                _dbContext.Add(userInfo);
                 _logger.Log(LogLevel.Info, "User Successfully created.");
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "User creation failed.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }

        public User GetUser(string userId)
        {
            try
            {
                return _dbContext.Get(userId)?.FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Info, "Something went wrong while fetching user.");
                _logger.Log(LogLevel.Error, ex);
                throw;
            }
        }
    }
}
