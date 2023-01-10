using AutoMapper;
using MinimalApi.Base.Application.Models;
using MinimalApi.Base.Domain.Entities;

namespace MinimalApi.Base.Application.Tools.AutoMapper
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            /*  CreateMap<List<WeatherForecast>, ListForestCatOut>()
                  .ForMember(target => target.ListForecast, opt => opt.MapFrom(source => source));*/
            //CreateMap<WeatherForecast, WeatherForecastOutDto>().ForMember(o => o.Id, op => op.Ignore()).ReverseMap();
            CreateMap<WeatherForecast, WeatherForecastOutDto>().ReverseMap();
        }
    }
}
