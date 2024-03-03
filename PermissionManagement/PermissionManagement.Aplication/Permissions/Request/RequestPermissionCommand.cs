using PermissionManagement.Application.Abstractions.CQRS;

namespace PermissionManagement.Application.Permissions.Request
{
    public record RequestPermissionCommand(Guid EmployeeId, Guid PermissionTypeId, DateOnly StartDate, DateOnly EndDate) : ICommand<Guid>;
}
