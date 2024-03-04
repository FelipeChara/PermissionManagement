using Newtonsoft.Json;

namespace PermissionManagement.API.Middleware
{
    public class RegistryContextMiddleware(RequestDelegate next, ILogger<RegistryContextMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<RegistryContextMiddleware> _logger = logger;

        public async Task InvokeAsync(HttpContext context)
        {
            //Informacion Request
            string message = $"Request Information: Method: {context.Request.Method} Api: {context.Request.Path}";            
 
            _logger.LogInformation(message);

            await _next(context);            
        }
    }
}
