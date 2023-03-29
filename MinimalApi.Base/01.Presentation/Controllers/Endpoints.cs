using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Base._02.Infrastructure.Integration.Logging;
using MinimalApi.Base.Application.Models;
using MinimalApi.Base.Application.Services.Slave;
using MinimalApi.Base.Presentation.Filters;
using System;

namespace MinimalApi.Base.Presentation.Controllers
{
    public static class Endpoints
    {
        public static void RegisterProductsEndpoints(this IEndpointRouteBuilder endpoints,   ApiVersionSet versionSet)
        {
            endpoints.MapGet("/api/v1/GetAll", async (HttpContext _httpContext, [FromServices] IForecastService _forecastService, [FromServices] IApiLogger _logger, CancellationToken token)
             =>
            {
                _logger.LoggingInformation("hola mama");
                _logger.LoggingWarning("warning y errorrrrrrrrr");
//var mout =await _forecastService.GetListForestAsync(token);

                return Results.Ok("manrique");


            })
             .WithName("GetAllWeatherForecast")
             .WithApiVersionSet(versionSet).HasApiVersion(new ApiVersion(1, 0))
             .AddEndpointFilter<AuthorizationProxy>()
             .Produces<ListForestCatOut>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status400BadRequest)
             .Produces(StatusCodes.Status401Unauthorized)
             .Produces<ValidationProblemDetails>(StatusCodes.Status500InternalServerError);


        }
    }
}
