using MinimalApi.Base.Domain.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Base.Application.Models
{
    public class ListForestCatOut : BaseOut
    {
        public List<WeatherForecastOutDto> ListForecast { get; set; }
    }
}
