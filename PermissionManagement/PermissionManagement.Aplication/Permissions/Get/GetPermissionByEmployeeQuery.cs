using PermissionManagement.Application.Abstractions.CQRS;

namespace PermissionManagement.Application.Permissions.Get
{
    public record GetPermissionByEmployeeQuery(Guid EmployeeId) : IQuery<List<PermissionDTO>>;
}
