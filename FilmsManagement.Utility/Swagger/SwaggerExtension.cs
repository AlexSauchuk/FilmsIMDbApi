using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FilmsManagement.Utility.Swagger
{
    public static class SwaggerExtension
    {
        public static void UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger(options => {
                options.PreSerializeFilters.Add((swagger, httpReq) => {
                    if (httpReq.Host.Host.StartsWith("localhost", System.StringComparison.OrdinalIgnoreCase))
                    {
                        swagger.Servers.Add(new OpenApiServer { Url = $"https://{httpReq.Host}" });
                        swagger.Servers.Add(new OpenApiServer { Url = $"http://{httpReq.Host}" });
                    }
                    else if (!swagger.Servers.Any())
                    {
                        swagger.Servers.Add(new OpenApiServer { Url = $"https://{httpReq.Host}" });
                    }
                });
            });

            app.UseSwaggerUI(options => {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen();

            return services;
        }

        public static IServiceCollection AddSwaggerDocumentation<T>(this IServiceCollection services, string xmlDocumentationPath)
            where T : IDocumentFilter
        {
            services.AddSwaggerDocumentation();

            OpenApiSchema TimeSpanSchemaFactory() => new OpenApiSchema { Type = "string", Format = "time-span", Example = new OpenApiString(TimeSpan.Zero.ToString()) };
            services.ConfigureSwaggerGen(s =>
            {
                s.MapType<TimeSpan>(TimeSpanSchemaFactory);
                s.MapType<TimeSpan?>(TimeSpanSchemaFactory);
                s.IncludeXmlComments(xmlDocumentationPath);
                s.DocumentFilter<T>();
            });

            return services;
        }
    }
}
