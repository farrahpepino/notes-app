using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace server.Middlewares{

    public class GlobalExceptionHandler{
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly RequestDelegate _next;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, RequestDelegate next){
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context){
            try {
                await _next(context);
            }
            catch (Exception ex){
                _logger.LogError("Unhandled exception.");

                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                context.Response.ContentType = "application/json";
                
                var errorResponse = new {
                    status = context.Response.StatusCode,
                    error = "An unexpected error occurred",
                    detail = ex.Message,
                    timestamp = DateTime.Now
                };

                await context.Response.WriteAsJsonAsync(errorResponse);
            }
        }
    }
}