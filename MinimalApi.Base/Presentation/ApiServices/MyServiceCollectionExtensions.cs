using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using MinimalApi.Base.Application.InfrastructureContracts;
using MinimalApi.Base.Infrastructure.Security;

namespace MinimalApi.Base.Presentation.ApiServices
{
    public static class MyServiceCollectionExtensions
    {
        public static IServiceCollection AddHttpClientsGroup(this IServiceCollection services)
        {

            services.AddHttpClient<ISecurityApi, SecurityApi>(
                client =>
                {
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                });

            return services;
        }

        public static IServiceCollection AddServicesGroup(this IServiceCollection services)
        {




            return services;
        }

        public static IServiceCollection AddConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.Configure < JwtOptions>(configuration.GetSection("Security:Jwt"));
                


            return services;
        }





    }
}
