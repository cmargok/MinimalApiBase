using NLog.Filters;
using NLog.Internal;
using NLog.Layouts;
using NLog.Targets;
using NLog;
using NLog.Config;
using LogLevel = NLog.LogLevel;
using NLog.Targets.Seq;
using NLog.Targets.Wrappers;
using Microsoft.Extensions.Options;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public interface IApiLogger
    {
        public void LoggingWarning(string message);
        public void LoggingInformation(string message);
        public void LoggingError(Exception ex, string message);
    }
   
}