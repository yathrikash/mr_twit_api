using mr.cooper.mrtwit.models;

namespace mr.cooper.mrtwit.services.Interface
{
    public interface IUserService
    {
        void AddUser(UserWithProfile userInfo);
        User GetUser(string userId);
        Session SignIn(SignIn userInfo);
        bool IsValidUser(Session session);

        void SignOut(string userName, string deveice);
        
    }
}
