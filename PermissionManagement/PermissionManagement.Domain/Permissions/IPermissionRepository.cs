namespace PermissionManagement.Domain.Permissions
{
    public interface IPermissionRepository
    {
        Task<Permission> GetByIdAsync(Guid Id, CancellationToken cancellationToken = default);

        Task<List<Permission>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);

        void RequestAsync(Permission entity);

        void ModifyAsync(Permission entity);
    }
}
