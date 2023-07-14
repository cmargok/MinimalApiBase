using NLog;
using NLog.Config;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public class LoggerManagerOptions
    {
        public string LogSectionName { get; set; }

        private LoggingConfiguration _Loggerconfig;

        private Dictionary<LoggingTarget, string> _LoggersNames;


        public LoggerManagerOptions() {

            _Loggerconfig = new();
        }
        public void AddTargets(Action<MyCustomLoggingConfiguration> Targets = null!)
        {
            _Loggerconfig = new LoggingConfiguration();
            if (Targets != null)
            {
                var targetsConfig = new TargetsConfiguration();
                var options = new MyCustomLoggingConfiguration();
                Targets(options);



                if (options.ConsoleConfiguration.ConsoleLog)
                {

                    if (options.DefaultConsoleLogSettings)
                    {
                        _Loggerconfig = targetsConfig.AddDefaultColoredConsoleTarget(_Loggerconfig, LoggersNames[LoggingTarget.Console]);
                    }
                    else
                    {
                        _Loggerconfig = targetsConfig.AddCustomConsoleTarget(_Loggerconfig, options.ConsoleConfiguration.ConsoleTargetConfig!, LoggersNames[LoggingTarget.Console]);
                    }
                }





            }
        }
        public void SetDictionary(Dictionary<LoggingTarget, string> data)
        {
            _LoggersNames = data;
        }

        public LoggingConfiguration BuildConfig()
        {
            return _Loggerconfig;
        }



    }

}

