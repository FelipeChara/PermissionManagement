using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Abstractions.Services
{
    public interface ISearchService
    {
        Task<bool> SendPermission(Permission permission);
    }
}
