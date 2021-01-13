using mr.cooper.mrtwit.logger.Models;
using mr.cooper.mrtwit.models;
using mr.cooper.mrtwit.repository;
using mr.cooper.mrtwit.repository.mongodb.Interface.Concrete;
using System;
using System.Collections.Generic;
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
    }
}
