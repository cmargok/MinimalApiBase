using Asp.Versioning;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MinimalApi.Base.Presentation.ApiServices.OpenApiSupport
{
    public class HeaderParametersOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var actionMetadata = context.ApiDescription.ActionDescriptor.EndpointMetadata;
            operation.Parameters ??= new List<OpenApiParameter>();

            var apiVersionMetadata = actionMetadata
                .Any(metadataItem => metadataItem is ApiVersionMetadata);
            if (apiVersionMetadata)
            {
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "API-Version",
                    In = ParameterLocation.Header,
                    Description = "API Version header value",
                    Schema = new OpenApiSchema
                    {
                        Type = "String",
                        Default = new OpenApiString("0.1")
                    }
                });
                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "UserId",
                    In = ParameterLocation.Header,
                    Description = "User ID",
                    Schema = new OpenApiSchema
                    {
                        Type = "String",
                        Default = new OpenApiString("User Id")
                    }
                });

                operation.Parameters.Add(new OpenApiParameter
                {
                    Name = "ApiToken",
                    In = ParameterLocation.Header,
                    Description = "Token for Api Authentication",
                    Schema = new OpenApiSchema
                    {
                        Type = "String",
                        Default = new OpenApiString("Api Token #$")
                    }
                });

            }
        }
    }

}
