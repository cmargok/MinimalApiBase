namespace MinimalApi.Base._02.Infrastructure.Integration.Logging
{
    public static class LoggingUnitOfMeasurement
    {
        public static UnitOfLogging UseUnitOfLogging(this IServiceCollection services)
        {
            return new UnitOfLogging(services);
        }
    }
}
