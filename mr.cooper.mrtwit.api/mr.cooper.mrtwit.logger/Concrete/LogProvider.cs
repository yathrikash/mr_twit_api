using mr.cooper.mrtwit.logger.Models;
using NLog;

namespace mr.cooper.mrtwit.logger.Concrete
{
    public static class LogProvider
    {
        public static IMrLogger GetLogger()
        {
            MrLogger.InitializeLogger("mr.cooper.mrtwit");
            return MrLogger.Instance;

        }
    }
}
