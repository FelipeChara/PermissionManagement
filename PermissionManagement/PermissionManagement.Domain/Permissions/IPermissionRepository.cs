namespace PermissionManagement.Domain.Permissions
{
    public interface IPermissionRepository
    {
        Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        Task<List<Permission>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default);

        Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);

        Task RequestAsync(Permission entity, CancellationToken cancellationToken = default);

        void Modify(Permission entity);
    }
}
