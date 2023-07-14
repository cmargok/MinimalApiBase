using System.ComponentModel.Design;
using System.Runtime;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public class ApiLogger : IApiLogger
    {
        private readonly ILogger _logger;      

        internal ApiLogger(ILoggerFactory loggerFactory, string NameLogger)
        {      
            _logger = loggerFactory.CreateLogger(NameLogger);                      
        }

        public void LoggingInformation(string message) 
        { 
            _logger.LogInformation(message);
        }

        public void LoggingWarning(string message)
        {
            _logger.LogWarning(message);
        }

        public void LoggingError(Exception ex, string message)
        {
            _logger.LogError(ex, message);           
        }
    }
