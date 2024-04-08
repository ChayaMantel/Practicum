using Newtonsoft.Json;

namespace EmpManage.Middlewars
{
    public class TrackingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TrackingMiddleware> _logger;

        public TrackingMiddleware(RequestDelegate next, ILogger<TrackingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var startTime = DateTime.UtcNow;

                await _next(context);

                var endTime = DateTime.UtcNow;
                var elapsedTime = endTime - startTime;

                _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path} | Response Status Code: {context.Response.StatusCode} | Elapsed Time: {elapsedTime.TotalMilliseconds} ms");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An unhandled exception occurred in the tracking middleware.");
                throw;
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var result = JsonConvert.SerializeObject(new { error = ex.Message });
            return context.Response.WriteAsync(result);
        }
    }
}


