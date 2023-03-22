using Serilog.Context;
using Serilog.Core;
using Serilog.Events;
using System.ComponentModel.Design;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public class OnwLogger : IEventLogger
    {
        private readonly ILogger<OnwLogger> _logger;
        public OnwLogger(ILogger<OnwLogger> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogInfo(string message)
        {              
            
             _logger.LogDebug(message);
            

        }

        public void LogWarn(string message)
        {
            _logger.LogWarning(message);
                 _logger.LogError(message+"      error");
        }
    }
        
    public class ApplicationEnricher : ILogEventEnricher
    {
        private readonly string _applicationName = "MinimalApi";

        public ApplicationEnricher()
        { 
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var applicationProperty = new LogEventProperty("Application", new ScalarValue(_applicationName));
            logEvent.AddPropertyIfAbsent(applicationProperty);
        }
    }



}
