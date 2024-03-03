using Newtonsoft.Json;

namespace PermissionManagement.API.Middleware
{
    public class RegistryContextMiddleware(RequestDelegate next, ILogger<RegistryContextMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<RegistryContextMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            string message = $"Request Information: Method: {context.Request.Method} Api: {context.Request.Path}";

            if (context.Request.Method != "GET")
            {
                message += $" Body: {JsonConvert.SerializeObject(context.Request.Body)}";
            }
 
            _logger.LogInformation(message);

            await _next(context);            
        }
    }
}
