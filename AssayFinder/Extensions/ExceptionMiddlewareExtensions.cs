using Entities.ErrorModels;
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
                    // Set status code to 500
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    // Set response to JSON
                    context.Response.ContentType = "application/json";
                    
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    
                    // If an exception is caught...
                    if (contextFeature != null)
                    {
                        // Log the error
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
                        
                        // Populate with status code and error message
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error.",
                        }
                        // Convert to JSON object
                        .ToString());
                    }
                });
            });
        }
    }
}
