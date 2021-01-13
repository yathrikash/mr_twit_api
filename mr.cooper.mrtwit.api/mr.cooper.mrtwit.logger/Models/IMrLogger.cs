using System;
using System.Collections.Generic;
using System.Text;

namespace mr.cooper.mrtwit.logger.Models
{
    public interface IMrLogger
    {

        void Log(LogLevel logLevel, string message);
        void Log(LogLevel logLevel, Exception ex);

    }
}
