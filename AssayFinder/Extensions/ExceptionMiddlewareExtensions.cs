using Entities.ErrorModels;
using Entities.Exceptions;
using Interfaces;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace AssayFinder.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
        {
            // Set up middleware
            app.UseExceptionHandler(appError =>
            {
                // Error handling logic
                appError.Run(async context =>
                {
                    // Set response to JSON
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    // If an exception is caught...
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            // Not found 404
                            NotFoundException => StatusCodes.Status404NotFound,
                            // Any other error - Internal server error 500
                            _ => StatusCodes.Status500InternalServerError
                        };

                        // Log the error
                        logger.LogError($"Something went wrong: {contextFeature.Error}");

                        // Populate with status code and error message
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                        }.ToString()); // Convert to JSON object


                    }
                });
            });
        }
    }
}
