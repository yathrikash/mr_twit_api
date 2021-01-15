using mr.cooper.mrtwit.models;
using System.Collections.Generic;

namespace mr.cooper.mrtwit.services.Interface
{
    public interface IUserService
    {
        void AddUser(UserWithProfile userInfo);
        User GetUser(string userId);

        IList<string> GetUser();
        Session SignIn(SignIn userInfo);
        bool IsValidUser(Session session);

        void SignOut(string userName, string deveice);
        
    }
}
