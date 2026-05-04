using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace Asagram.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                   
                    context.Response.ContentType = "application/json";
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFoundException => StatusCodes.Status404NotFound,
                            ValidationAppException =>StatusCodes.Status422UnprocessableEntity,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        if (contextFeature.Error is ValidationAppException exception)
                        {
                            await context.Response
                            .WriteAsync(JsonSerializer.Serialize(new
                            {
                                exception.Errors
                            }));
                        }
                        else
                        {

                            await context.Response.WriteAsync(new ErrorDetails()
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                            }.ToString());
                        }
                    }

                    
                });
            });
        }
    }
}
