using MinimalApi.Base.Application.Models;

namespace MinimalApi.Base.Application.Services.Slave
{
    public interface IForecastService
    {
        public Task<ListForestCatOut> GetListForestAsync(CancellationToken token);
    }
}
