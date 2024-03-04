namespace PermissionManagement.Domain.Permissions
{
    public interface IPermissionRepository
    {
        /// <summary>
        /// Obtiene permiso por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Obtiene lista permisos por empleado
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<List<Permission>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Valida permisos existentes para crear permiso
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="permissionTypeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Valida permisos existentes para modificar permiso
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeId"></param>
        /// <param name="permissionTypeId"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> IsOverlappingModifyAsync(Guid id, Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);

        /// <summary>
        /// Guarda un permiso
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RequestAsync(Permission entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Edita un permiso
        /// </summary>
        /// <param name="entity"></param>
        void Modify(Permission entity);
    }
}
