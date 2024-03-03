using PermissionManagement.Application.Abstractions.CQRS;

namespace PermissionManagement.Application.Permissions.Modify
{
    public record ModifyPermissionCommand(Guid Id, Guid EmployeeId, Guid PermissionTypeId, DateOnly StartDate, DateOnly EndDate) : ICommand<Guid>;

}
