namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public interface IEventLogger
    {
        public void LogWarn(string message);
        public void LogDebug(string message);
        public void LogInfo(string message);
    }
}