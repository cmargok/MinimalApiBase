using Asp.Versioning;
using Asp.Versioning.Builder;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Base.Application.Models;
using MinimalApi.Base.Application.UseCases.Slave;
using MinimalApi.Base.Presentation.Filters;
using System;

namespace MinimalApi.Base.Presentation.Controllers
{
    public static class Endpoints
    {
        public static void RegisterProductsEndpoints(this IEndpointRouteBuilder endpoints, ApiVersionSet versionSet, ILogger _logger)
        {
            endpoints.MapGet("/api/v1/GetAll", async (HttpContext _httpContext, [FromServices] IServiceSlave _iServiceSlave, CancellationToken token)
             =>
            {

              

                return Results.Ok("GetAllWeatherForecast");


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
