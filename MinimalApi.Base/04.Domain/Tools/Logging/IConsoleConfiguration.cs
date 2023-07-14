using NLog.Config;
using NLog.Targets;
using NLog.Targets.Seq;
using NLog.Targets.Wrappers;
using LogLevel = NLog.LogLevel;

namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public interface IConsoleConfiguration
    {
        public ColoredConsoleTarget? ConsoleTargetConfig { get; set; }
        public bool ConsoleLog { get; set; }
        public LogLevel ConsoleLogLevel { get; set; }
        public string ConsoleTargetName { get; set; }
    }
    public class ConsoleConfiguration : IConsoleConfiguration
    {
        public ColoredConsoleTarget? ConsoleTargetConfig { get; set; }
        public bool ConsoleLog { get; set; } = true;
        public LogLevel ConsoleLogLevel { get; set; } = LogLevel.Info;
        public string ConsoleTargetName { get; set; } = "console";
    }

    public class MyCustomLoggingConfiguration
    {
        public bool DefaultConsoleLogSettings { get; set; } = true;
        public ConsoleConfiguration ConsoleConfiguration { get; set; }


        //private readonly LoggingSettings _loggingSettings;

        public MyCustomLoggingConfiguration()
        {
            ConsoleConfiguration = new ConsoleConfiguration();
        } 

    }

    internal sealed class TargetsConfiguration
    {
        public IConsoleConfiguration ConsoleConfiguration { get; set; }
        public TargetsConfiguration()
        {
            ConsoleConfiguration = new ConsoleConfiguration();
        }
        public LoggingConfiguration AddDefaultColoredConsoleTarget(LoggingConfiguration loggerconfig, string LoggerName)
        {
            ConsoleConfiguration.ConsoleTargetConfig = new ColoredConsoleTarget();
            ConsoleConfiguration.ConsoleTargetConfig.Name = ConsoleConfiguration.ConsoleTargetName;
            ConsoleConfiguration.ConsoleTargetConfig.Layout = @"${longdate} ${uppercase:${level}} ${logger} ${message}";
            AddRule(loggerconfig, ConsoleConfiguration.ConsoleTargetName, ConsoleConfiguration.ConsoleLogLevel, ConsoleConfiguration.ConsoleTargetConfig, LoggerName);

            return loggerconfig;

        }

        public LoggingConfiguration AddCustomConsoleTarget(LoggingConfiguration loggerconfig, ColoredConsoleTarget consoleTarget, string LoggerName)
        {
            if (consoleTarget is null)
            {
                AddDefaultColoredConsoleTarget(loggerconfig, LoggerName);
                return loggerconfig;
            }
            AddRule(loggerconfig, ConsoleConfiguration.ConsoleTargetName, ConsoleConfiguration.ConsoleLogLevel, consoleTarget, LoggerName);

            return loggerconfig;

        }




        public LoggingConfiguration AddDefaultFileTarget(LoggingConfiguration loggerconfig, string LoggerName)
        {
            var fileTarget = new FileTarget();
            fileTarget.FileName = "${basedir}/logs/${shortdate}.log";
            fileTarget.Layout = "${longdate} ${uppercase:${level}} ${logger} ${message}";

            config.AddTarget("file", fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

            return loggerconfig;

        }

        public LoggingConfiguration AddDefaultSeqTarget(LoggingConfiguration loggerconfig, string LoggerName)
        {
            var seqContainer = new BufferingTargetWrapper();
            seqContainer.BufferSize = 1024;
            seqContainer.FlushTimeout = 2000;
            seqContainer.SlidingTimeout = false;
            var seqTarget = new SeqTarget()
            {
                ServerUrl = "localhost",
                ApiKey = null,
            };

            seqTarget.Properties.Add(new SeqPropertyItem
            {
                Name = "Application",
                As = "Application",
                Value = "MinimalApi",
            });

            seqTarget.Properties.Add(new SeqPropertyItem
            {
                Name = "Environment",
                As = "Environment",
                Value = "Development",
            });

            seqContainer.WrappedTarget = seqTarget;

            config.AddTarget("file", fileTarget);
            config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, fileTarget));

            return loggerconfig;

        }



        private LoggingConfiguration AddRule(LoggingConfiguration loggerconfig, string TargetName, LogLevel level, Target target, string LoggerName)
        {

            loggerconfig.AddTarget(TargetName, target);
            loggerconfig.LoggingRules.Add(new LoggingRule(LoggerName, level, target));
            return loggerconfig;
        }

        
    }
}