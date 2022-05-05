using System;
using System.Collections.Generic;
using System.IO;
using FilmsManagement.Utility.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilmsManagement.WebApi
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            if (IsSwaggerDisabled(configuration))
            {
                return services;
            }

            var xmlDocumentationPath = Path.Combine(AppContext.BaseDirectory, $"{typeof(ServerListDocumentFilter).Assembly.GetName().Name}.xml");

            services.AddSwaggerDocumentation();

            return services;
        }

        public static IApplicationBuilder EnableSwagger(this IApplicationBuilder appBuilder, IConfiguration configuration)
        {
            if (IsSwaggerDisabled(configuration))
            {
                return appBuilder;
            }

            appBuilder.UseSwaggerDocumentation();
            return appBuilder;
        }

        private static bool IsSwaggerDisabled(IConfiguration configuration)
        {
            bool.TryParse(configuration["UseSwaggerDocumentation"], out var swaggerDisabled);
            return !swaggerDisabled;
        }
    }

    public class ServerListDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Servers = new List<OpenApiServer>
            {
                new OpenApiServer { Description = "local", Url = "http://localhost:12345" }
            };
            swaggerDoc.Info.Title = "Films management API";
        }
    }
}
