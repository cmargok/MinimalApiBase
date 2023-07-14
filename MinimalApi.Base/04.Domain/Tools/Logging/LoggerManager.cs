
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public sealed class LoggerManager : IApiLogger
    {

        private readonly List<IApiLogger> _apiLoggers;
        private readonly LoggingSettings _loggingSettings;

        public LoggerManager(ILoggerFactory loggerFactory, IOptions<LoggingSettings> settings)
        {
            _apiLoggers = new List<IApiLogger>();
            _loggingSettings = settings.Value;
            InitializeLoggers(loggerFactory);
        }



        private void InitializeLoggers(ILoggerFactory loggerFactory) 
        {
            if (_loggingSettings.LoggingActive)
            {
                foreach (var logger in _loggingSettings.GetActiveLoggers())
                {
                    _apiLoggers.Add(new ApiLogger(loggerFactory, logger));
                }
            }
        }



        public void LoggingInformation(string message)
        {
            if (_loggingSettings.LoggingActive)
            {
                foreach (var logger in _apiLoggers)
                {
                    logger.LoggingInformation(message);
                }
            }
        }

        public void LoggingWarning(string message)
        {
            if (_loggingSettings.LoggingActive)
            {
                foreach (var logger in _apiLoggers)
                {
                    logger.LoggingWarning(message);
                }
            }
        }

        public void LoggingError(Exception ex, string message)
        {
            if (_loggingSettings.LoggingActive)
            {
                foreach (var logger in _apiLoggers)
                {
                    logger.LoggingError(ex, message);
                }
            }
        }




    }

}
