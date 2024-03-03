namespace PermissionManagement.Domain.Employees
{
    public interface IEmployeeRepository
    {
        Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
