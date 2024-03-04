namespace PermissionManagement.Domain.Employees
{
    public interface IEmployeeRepository
    {
        /// <summary>
        /// Obtiene empleado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
