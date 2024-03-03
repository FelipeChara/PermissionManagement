using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;
using PermissionManagement.Infrastructure.EF;
using PermissionManagement.Infrastructure.Repositories;

namespace PermissionManagement.Infrastructure
{
    public static class ConfigurationServices
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(op =>
            {
                op.UseSqlServer(configuration.GetConnectionString("DdConnection") ?? throw new InvalidOperationException("Connection string not found"));
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionTypeRepository, PermissionTypeRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }
    }
}
