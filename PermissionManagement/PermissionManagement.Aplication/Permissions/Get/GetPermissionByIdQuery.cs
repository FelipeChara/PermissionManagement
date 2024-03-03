using PermissionManagement.Application.Abstractions.CQRS;

namespace PermissionManagement.Application.Permissions.Get
{
    public record GetPermissionByIdQuery(Guid Id) : IQuery<PermissionDTO?>;
}
