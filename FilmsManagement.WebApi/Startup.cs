using FilmsManagement.Utility;
using FilmsManagement.WebApi.Errors;
using FilmsManagement.DependencyModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace FilmsManagement.WebApi
{
    public class Startup
    {
        protected IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
            services.AddLogging();

            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IExceptionHandler, ExceptionHandler>();

            RegisterDependencies(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFilmsManagementExceptionHandler();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            ConfigureApp(app, env);
        }

        private void ConfigureApp(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.EnableSwagger(Configuration);
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            services
                .RegisterMovieDomainService()
                .RegisterMovieSearchDomainService()
                .RegisterUserWatchListDomainService()
                .RegisterUtilities();
        }
    }
}
