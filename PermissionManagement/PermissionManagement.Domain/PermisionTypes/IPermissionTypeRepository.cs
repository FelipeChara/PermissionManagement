namespace PermissionManagement.Domain.PermisionTypes
{
    public interface IPermissionTypeRepository
    {
        /// <summary>
        /// Obtiene tipo permiso por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<PermissionType?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
