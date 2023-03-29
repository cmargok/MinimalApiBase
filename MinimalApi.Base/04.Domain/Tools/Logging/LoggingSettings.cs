namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public class LoggingSettings
    {
        public bool IsFileConsoleActivated { get; set; }
        public string FileConsoleLoggerName { get; set; } = String.Empty;
        public bool IsSeqActivated { get; set; }
        public string SeqLoggerName { get; set; } = String.Empty;
    }

}
