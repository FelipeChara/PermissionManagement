using Microsoft.EntityFrameworkCore;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Infrastructure.EF;

namespace PermissionManagement.Infrastructure.Repositories
{
    internal class EmployeeRepository(ApplicationDbContext context) : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Employee>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
