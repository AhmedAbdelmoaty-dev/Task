
using Application.Exceptions;

namespace API.Middlewares
{
    public class ErrorHandelingMiddeware : IMiddleware
    {
        
        private async Task HandleExceptionrResponseAsync(HttpContext context,int statusCode,string message , IDictionary<string, string[]>? errors = null)
        {
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json";

            var response = new { statusCode, message,errors };
            await context.Response.WriteAsJsonAsync(response);
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (NotFoundException notFoundException)
            {
                await HandleExceptionrResponseAsync(context, notFoundException.StatusCode, notFoundException.Message);
            }
            catch (BadRequestException badRequest)
            {
                await HandleExceptionrResponseAsync(context, badRequest.StatusCode, badRequest.Message,badRequest.Errors);
            }
            catch (Exception ex)
            {

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"Something went wrong ... , {ex.Message}");
            }
        }
    }
}
