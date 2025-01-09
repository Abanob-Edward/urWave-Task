using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace Product_Management_System.Middleware
{
    public static class ErrorHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorHandlingMiddleware(this IApplicationBuilder app, ILogger<ErrorHandlingMiddleware> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = contextFeature?.Error;

                    logger.LogError(exception, "An unhandled exception occurred.");

                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var response = new
                    {
                        Message = "An error occurred while processing your request.",
                      
                        StatusCodes = context.Response.StatusCode,
                        ExceptionType = exception?.GetType().Name
                    };

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });

            return app;
        }
    }
}
