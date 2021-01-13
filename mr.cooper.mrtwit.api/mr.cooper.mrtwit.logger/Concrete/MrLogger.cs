using mr.cooper.mrtwit.logger.Models;
using System;

namespace mr.cooper.mrtwit.logger.Concrete
{
    public class MrLogger : IMrLogger
    {
        private static IMrLogger _instance;

        public static IMrLogger Instance
        {
            get
            {
                return _instance;
            }
        }
        public MrLogger(string appName)
        {
            //Need to use appName and do Nlog operatons
        }

        public static void InitializeLogger(string appName)
        {
            _instance = new MrLogger(appName);
        }
        public void Log(LogLevel logLevel, string message)
        {
            //Need to implement
        }

        public void Log(LogLevel logLevel, Exception ex)
        {
            //Need to implement

        }
    }
}
