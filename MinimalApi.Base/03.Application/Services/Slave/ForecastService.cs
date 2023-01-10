using AutoMapper;
using MinimalApi.Base.Application.Models;
using MinimalApi.Base.Domain.Enums;
using MinimalApi.Base.Domain.RepositoriesContracts;
using MinimalApi.Base.Domain.Shared;

namespace MinimalApi.Base.Application.Services.Slave
{
    public class ForecastService : IForecastService
    {
        private readonly IWeatherRepository _weatherRepository;
        public readonly IMapper _mapper;

        public ForecastService(IWeatherRepository weatherRepository, IMapper mapper)
        {
            _weatherRepository = weatherRepository;
            _mapper = mapper;
        }

        public async Task<ListForestCatOut> GetListForestAsync(CancellationToken token)
        {
            var ListWeatherDB = await _weatherRepository.GetAllAsync(token);
         
            var ListWeatherDto= new ListForestCatOut();


            if(ListWeatherDB is not null)
            {
                ListWeatherDto.ListForecast = _mapper.Map<List<WeatherForecastOutDto>>(ListWeatherDB);
                ListWeatherDto.Result = ResultStatus.Success.GetDescription();
                ListWeatherDto.Message = "Operacion Exitosa";
                CreateSendLogApi();
                return ListWeatherDto;
            }

            ListWeatherDto.Result = ResultStatus.NoRecords.GetDescription();
            ListWeatherDto.Message = "No Data found";
            CreateSendLogApi();
            return ListWeatherDto;

        }

        private void CreateSendLogApi()
        {
            
        }
    }
}
