namespace PermissionManagement.Domain.Permissions
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);

        Task SaveAsync(Permission entity);

        Task UpdateAsync(int id, Permission entity);
    }
}
