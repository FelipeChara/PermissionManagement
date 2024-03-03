using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PermissionManagement.Application.Abstractions.Behaviours;

namespace PermissionManagement.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(ConfigureServices).Assembly);
                configuration.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddValidatorsFromAssembly(typeof(ConfigureServices).Assembly);

            return services;
        }
    }
}
