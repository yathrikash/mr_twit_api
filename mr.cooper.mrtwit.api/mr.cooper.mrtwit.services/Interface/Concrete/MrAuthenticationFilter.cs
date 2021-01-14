
using System.Web.Mvc.Filters;
namespace mr.cooper.mrtwit.services.Interface.Concrete
{
    public class MrAuthenticationFilter : IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            throw new System.NotImplementedException();
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
