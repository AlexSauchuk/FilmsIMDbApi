using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FilmsManagement.WebApi.Errors
{
    public static class ErrorHandlerRegistrationExtension
    {
        public static IApplicationBuilder UseFilmsManagementExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseExceptionHandler(app => {
                app.Run(context =>
                {
                    var exceptionHandler = context.RequestServices.GetRequiredService<IExceptionHandler>();
                    return exceptionHandler.HandleException(context);
                });
            });
        }
    }
}
