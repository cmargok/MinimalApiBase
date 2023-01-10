using Microsoft.EntityFrameworkCore;
using MinimalApi.Base.Domain.Entities;

namespace MinimalApi.Base.Infrastructure.Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        {

        }
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }    
    }
}
