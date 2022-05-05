using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
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
                options.SwaggerEndpoint($"/swagger/swagger.json", "Films management api");
            });
        }

        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(options => {
            });

            return services;
        }
    }
}
