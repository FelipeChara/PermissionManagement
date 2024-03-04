using Nest;
using PermissionManagement.Application.Abstractions.Services;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Infrastructure.Services
{
    internal class SearchService(ElasticClient client) : ISearchService
    {
        private readonly ElasticClient _client = client;

        public async Task<bool> SendPermission(Permission permission)
        {
            IndexResponse indexResponse = await _client.IndexDocumentAsync(permission);

            return indexResponse.IsValid;
        }
    }
}
