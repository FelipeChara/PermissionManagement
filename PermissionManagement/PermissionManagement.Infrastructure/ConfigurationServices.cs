using Elasticsearch.Net;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using PermissionManagement.Application.Abstractions.Services;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;
using PermissionManagement.Infrastructure.EF;
using PermissionManagement.Infrastructure.Repositories;
using PermissionManagement.Infrastructure.Services;

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
            services.AddScoped<ISearchService, SearchService>();

            var url = configuration["urlElasticSearch"] ?? throw new InvalidOperationException("url ElasticSearch not found");
            var index = configuration["indexDefaultElasticSearch"] ?? throw new InvalidOperationException("index ElasticSearch not found");

            // Elasticsearch connection
            var pool = new SingleNodeConnectionPool(new Uri(url));
            var settings = new ConnectionSettings(pool).DefaultIndex(index);
            var client = new ElasticClient(settings);
            services.AddSingleton(client);

            return services;
        }
    }
}
