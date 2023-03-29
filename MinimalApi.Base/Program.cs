using Asp.Versioning;
using Microsoft.EntityFrameworkCore;
using MinimalApi.Base._02.Infrastructure.Integration.Logging;
using MinimalApi.Base.Infrastructure.Persistence;
using MinimalApi.Base.Presentation.ApiServices;
using MinimalApi.Base.Presentation.ApiServices.OpenApiSupport;
using MinimalApi.Base.Presentation.Controllers;
using MinimalApi.Base.Presentation.Filters;
using MinimalApi.Base.Presentation.Middlewares;
using NLog;
using NLog.Fluent;
using NLog.Web;

var logger = LogManager.GetLogger("FileConsoleLogger");

try
{

    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
   

    builder.Services.AddDbContext<ApplicationDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("MinimalApiDB")));

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddApplicationServicesGroup();

    builder.Services.AddInfrastructureRepositoriesGroup();

    builder.Services.AddHttpClientsGroup();

    builder.Services.AddConfigureJWT(builder.Configuration);


    //Options pattern config settings

    builder.Services.Configure<SecuritySettings>(builder.Configuration.GetSection("Security"));
    builder.Services.Configure<LoggingSettings>(builder.Configuration.GetSection("LogSettings"));


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
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
    builder.Host.UseNLog();
    builder.Services.AddSingleton<IApiLogger, LoggerManager>();


    builder.Services.AddSwaggerGen(setup =>
    {
        setup.OperationFilter<HeaderParametersOperationFilter>();
    });

    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll",
            policy => policy.AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin());
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


    app.UseCors("AllowAll");
    //===================== Controllers =============================

    app.RegisterProductsEndpoints(versionSet);

    app.Run();

    /* .AddEndpointFilter(async (invocationContext, next) => 
        {        

            string? localToken = invocationContext.HttpContext.Request.Headers["ProxyToken"];
                if (localToken != incomingToken)
            {
                return Results.Unauthorized();
            }

            return await next(invocationContext);


        })*/


}
catch(Exception ex)
{
    logger.Error(logger.IsErrorEnabled ? ex.ToString() : ex);
    throw;
}
finally
{
    LogManager.Shutdown();
}