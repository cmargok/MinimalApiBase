using Microsoft.Extensions.Logging;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public sealed class LoggingSettings
    {
        public bool LoggingActive { get; set; } = false;
        public List<LoggersInitialConfigs> Loggers { get; set; }

        public IEnumerable<string> GetActiveLoggers()
        {      
            foreach(var logger in Loggers)
            {
                if(logger.Active)
                {
                    yield return logger.Name;
                }
            }
        }

        public class LoggersInitialConfigs
        {
            public bool Active { get; set; } = false;
            public string Name { get; set; } = string.Empty;
            public LoggingTarget Target { get; set; } = LoggingTarget.None;
        }
    }

    public enum LoggingTarget
    {
        None = 0,
        Console = 1,
        File = 2,
        Seq = 3,
        ElasticSearch = 4,
        Database = 5,
    }




}
