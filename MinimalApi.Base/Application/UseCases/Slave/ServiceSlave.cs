

namespace MinimalApi.Base.Application.UseCases.Slave
{
    public class ServiceSlave : IServiceSlave
    {

        private readonly IConfiguration _configuration;

        public ServiceSlave(IConfiguration configuration)
        {
            _configuration = configuration;
        }



        private string GenerateToken()
        {
            return "token";
        }
    }
}
