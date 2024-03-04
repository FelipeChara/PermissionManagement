using PermissionManagement.API.Middleware;

namespace PermissionManagement.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }

        public static void UseRegistryInfoRequest(this IApplicationBuilder app)
        {
            app.UseMiddleware<RegistryContextMiddleware>();
        }
    }
}
