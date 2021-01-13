using mr.cooper.mrtwit.logger.Models;
using NLog;
using NLog.Web;
using System;

namespace mr.cooper.mrtwit.logger.Concrete
{
    public class MrLogger : IMrLogger
    {
        private static IMrLogger _instance;
        private static ILogger _logger;
        public static IMrLogger Instance
        {
            get
            {
                return _instance;
            }
        }
        public MrLogger(ILogger logger)
        {
            _logger = logger;
        }

        public static void InitializeLogger(string appName)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            _instance = new MrLogger(logger);
        }
        public void Log(Models.LogLevel logLevel, string message)
        {
            _logger.Log(GetNlogLevel(logLevel), message);
            
        }

        public void Log(Models.LogLevel logLevel, Exception ex)
        {
            _logger.Log(GetNlogLevel( logLevel), ex);
        }


        private NLog.LogLevel GetNlogLevel(Models.LogLevel level)
        {
            switch (level)
            {
                case Models.LogLevel.Error:
                    return NLog.LogLevel.Error;
                    break;
                case Models.LogLevel.Warning:
                    return NLog.LogLevel.Warn;
                    break;
                case Models.LogLevel.Trace:
                    return NLog.LogLevel.Trace;
                    break;
                case Models.LogLevel.Info:
                    return NLog.LogLevel.Info;
                    break;
                default:
                    return NLog.LogLevel.Info;
                    break;
            }
        }
    }
}
