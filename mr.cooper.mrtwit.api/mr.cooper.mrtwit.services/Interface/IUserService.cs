using mr.cooper.mrtwit.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.services.Interface
{
    public interface IUserService
    {
        void AddUser(User userInfo);
        User GetUser(string userId);
    }
}
