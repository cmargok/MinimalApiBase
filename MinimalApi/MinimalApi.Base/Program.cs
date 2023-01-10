using Asp.Versioning;
using Asp.Versioning.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Base;
using MinimalApi.Base.Application.UseCases.Slave;
using MinimalApi.Base.Presentation.ApiServices;
using MinimalApi.Base.Presentation.ApiServices.OpenApiSupport;
using MinimalApi.Base.Presentation.Controllers;
using MinimalApi.Base.Presentation.Middlewares;
using Newtonsoft.Json;
using NLog;
using NLog.Web;
using System.Net.Http.Headers;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

logger.Debug("Init Minimal Aii");

try
{
     var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.

    builder.Services.AddScoped<IServiceSlave, ServiceSlave>();


    builder.Services.AddHttpClientsGroup();

    builder.Services.AddConfigureJWT(builder.Configuration);



    //============= Api Versioning ===============
    builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ApiVersionReader = new HeaderApiVersionReader("API-Version");
    });  
    builder.Services.AddEndpointsApiExplorer();

    //======================== Logging =========================
    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();









    builder.Services.AddSwaggerGen(setup =>
    {
        setup.OperationFilter<HeaderParametersOperationFilter>();
    });






    //======================== Init App ====================

    var app = builder.Build();
    var versionSet = app.NewApiVersionSet()
                        .HasApiVersion(new ApiVersion(1, 0))
                        .ReportApiVersions()
                        .Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();


    //==================== MiddleWares ===============================

    app.UseMiddleware<OperationCanceledMiddleware>();



    //===================== Controllers =============================


    app.RegisterProductsEndpoints(versionSet, app.Logger);





    app.Run();




    /* .AddEndpointFilter(async (invocationContext, next) => 
       {        

           string? localToken = invocationContext.HttpContext.Request.Headers["ProxyToken"];
           string? incomingToken = builder.Configuration["ProxyToken"];

           if (localToken != incomingToken)
           {
               return Results.Unauthorized();
           }

           return await next(invocationContext);


       })*/
}
catch (Exception ex)
{
    logger.Error(ex, "Program has stopper because an exception was found");
    throw;
}
finally
{
    LogManager.Shutdown();
}

