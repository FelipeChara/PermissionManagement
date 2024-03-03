using Microsoft.EntityFrameworkCore;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;
using PermissionManagement.Infrastructure.EF;

namespace PermissionManagement.Infrastructure.Repositories
{
    internal class PermissionRepository(ApplicationDbContext context) : IPermissionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public Task<List<Permission>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Permission>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public void Modify(Permission entity)
        {
            _context.Set<Permission>().Attach(entity);
            _context.Entry(entity).Property(x => x.EmployeeId).IsModified = true;
            _context.Entry(entity).Property(x => x.PermissionTypeId).IsModified = true;
            _context.Entry(entity).Property(x => x.StartDate).IsModified = true;
            _context.Entry(entity).Property(x => x.EndDate).IsModified = true;
            _context.Entry(entity).Property(x => x.UpdatedDate).IsModified = true;
        }

        public async Task RequestAsync(Permission entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
        }
    }
}
