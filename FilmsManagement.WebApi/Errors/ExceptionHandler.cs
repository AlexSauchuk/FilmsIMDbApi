using System;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using FilmsManagement.Infrastructure.Core.Exceptions;
using Newtonsoft.Json;

namespace FilmsManagement.WebApi.Errors
{
    public class ExceptionHandler : IExceptionHandler
    {
        private static readonly ErrorResponseModel DefaultErrorResponse = new ErrorResponseModel
        {
            HttpStatusCode = HttpStatusCode.InternalServerError,
            Description = "An error occured while processing the request",
            Message = "Internal server error"
        };

        private readonly ILogger<ExceptionHandler> _logger;

        public ExceptionHandler(ILogger<ExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async Task HandleException(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
            var exception = exceptionHandlerPathFeature.Error;

            _logger.LogError(exception, "Exception handler: Exception occured.");

            ErrorResponseModel errorResponseModel;

            switch (exception)
            {
                case FilmsSearchRequestException ex:
                    errorResponseModel = new ErrorResponseModel 
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Description = "",
                        Message = ex.Message
                    };
                    break;
                case MovieNotFoundException ex:
                    errorResponseModel = new ErrorResponseModel
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Description = "Movie was not found in IMDb data",
                        Message = ex.Message
                    };
                    break;
                case UserNotFoundException ex:
                    errorResponseModel = new ErrorResponseModel
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Description = "",
                        Message = ex.Message
                    };
                    break;
                case ArgumentException ex:
                    errorResponseModel = new ErrorResponseModel
                    {
                        HttpStatusCode = HttpStatusCode.BadRequest,
                        Description = "",
                        Message = ex.Message
                    };
                    break;
                default:
                    errorResponseModel = DefaultErrorResponse;
                    break;
            }

            context.Response.StatusCode = (int) errorResponseModel.HttpStatusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;
            var bodyContent = JsonConvert.SerializeObject(errorResponseModel);

            await context.Response.WriteAsync(bodyContent);
        }
    }
}
