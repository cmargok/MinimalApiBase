using Microsoft.Extensions.Options;

namespace MinimalApi.Base.Presentation.Filters
{
    public class AuthorizationProxy : IEndpointFilter
    {
        private readonly ILogger<AuthorizationProxy> _logger;
        private readonly SecuritySettings _securitySettings;


        public AuthorizationProxy( ILogger<AuthorizationProxy> logger, IOptions<SecuritySettings> securitySettings)
        {
            _securitySettings = securitySettings.Value;
            _logger = logger;
        }


        public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
           // _logger.LogInformation("Validate headers");
            string? UserId = context.HttpContext.Request.Headers["UserId"];
            string? ApiTokenIncoming = context.HttpContext.Request.Headers["ApiToken"];

            if (UserId is not null)
            {
                string? Apitoken = _securitySettings.ApiToken;
                if (ApiTokenIncoming is not null && ApiTokenIncoming.Equals(Apitoken))
                {
                    var result = await next(context);
                   // _logger.LogInformation("Headers validation Completed");
                    return result;
                }

            }
           // _logger.LogWarning("Unauthorized - headers");
            return Results.Unauthorized();
        }
    } 
}
