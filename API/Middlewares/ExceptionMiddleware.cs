using SharedObjects.Commons;
using System.Net;

namespace API.Middlewares
{
    public class CatchGlobalErrors
    {
        private readonly RequestDelegate _next;
        public CatchGlobalErrors(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

            context.Response.ContentType = "application/json";

            if (exception.GetType() == typeof(CustomException))
            {
                context.Response.StatusCode = ((CustomException)exception).statusCode;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            await context.Response.WriteAsync(new ResponseResult()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            }.ToString());
        }
    }

    public static class CatchGlobalErrorsExtensions
    {
        public static void UseExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<CatchGlobalErrors>();
        }
    }
}