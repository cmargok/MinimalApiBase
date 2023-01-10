using MinimalApi.Base.Domain.Entities;

namespace MinimalApi.Base.Domain.RepositoriesContracts
{
    public interface IWeatherRepository
    {
        public Task<List<WeatherForecast>> GetAllAsync(CancellationToken token);
    }
}
