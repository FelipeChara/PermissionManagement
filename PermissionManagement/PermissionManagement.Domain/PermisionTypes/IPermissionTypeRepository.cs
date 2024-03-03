namespace PermissionManagement.Domain.PermisionTypes
{
    public interface IPermissionTypeRepository
    {
        Task<PermissionType?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
