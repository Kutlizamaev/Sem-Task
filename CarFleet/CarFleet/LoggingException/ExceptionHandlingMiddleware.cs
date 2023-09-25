using CarFleet.BLL.DTO;
using System.Net;
using System.Text.Json;
using CarFleet.HOST.Logs;

namespace CarFleet.HOST.LoggingException
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _loggerFactory = loggerFactory;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, string exMessage)
        {
            _loggerFactory.AddProvider(new FileLoggerProvider());
            var logger = _loggerFactory.CreateLogger("Logger");

            logger.LogError($"[{DateTime.Now}] Error: {exMessage}");
        }
    }
}
