namespace MinimalApi.Base.Presentation.Filters
{
    public class AuthorizationProxy : IEndpointFilter
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthorizationProxy> _logger;

        public AuthorizationProxy(IConfiguration configuration, ILogger<AuthorizationProxy> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }


        public virtual async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            _logger.LogInformation("Validate headers");
            string? UserId = context.HttpContext.Request.Headers["UserId"];
            string? ApiTokenIncoming = context.HttpContext.Request.Headers["ApiToken"];

            if (UserId is not null)
            {
                string? Apitoken = _configuration["Security:ApiToken"];
                if (ApiTokenIncoming is not null && ApiTokenIncoming.Equals(Apitoken))
                {
                    var result = await next(context);
                    _logger.LogInformation("Headers validation Completed");
                    return result;
                }

            }
            _logger.LogWarning("Unauthorized - headers");
            return Results.Unauthorized();


        }


    }
}
