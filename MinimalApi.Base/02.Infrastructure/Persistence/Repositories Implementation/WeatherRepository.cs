using Microsoft.EntityFrameworkCore;
using MinimalApi.Base.Domain.Entities;
using MinimalApi.Base.Domain.RepositoriesContracts;

namespace MinimalApi.Base.Infrastructure.Persistence.Repositories_Implementation
{
    public class WeatherRepository : IWeatherRepository
    {
        private readonly ApplicationDBContext _context;

        public WeatherRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<WeatherForecast>> GetAllAsync(CancellationToken token)
                => await _context.WeatherForecasts.ToListAsync(token);
        
    }
}
