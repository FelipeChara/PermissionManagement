using Microsoft.EntityFrameworkCore;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;
using PermissionManagement.Infrastructure.EF;

namespace PermissionManagement.Infrastructure.Repositories
{
    internal class PermissionRepository(ApplicationDbContext context) : IPermissionRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<List<Permission>> GetByEmployeeIdAsync(Guid employeeId, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Permission>().Where(x => x.EmployeeId == employeeId).ToListAsync(cancellationToken);
        }

        public async Task<Permission?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Permission>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<bool> IsOverlappingAsync(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Permission>()
                .AnyAsync(
                    x =>
                        x.PermissionTypeId == permissionTypeId &&
                        x.EmployeeId == employeeId &&
                        x.StartDate <= endDate &&
                        x.EndDate >= startDate,
                     cancellationToken
                    );
        }

        public async Task<bool> IsOverlappingModifyAsync(Guid id, Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            return await _context.Set<Permission>()
                .AnyAsync(
                    x =>
                        x.PermissionTypeId == permissionTypeId &&
                        x.EmployeeId == employeeId &&
                        x.StartDate <= endDate &&
                        x.EndDate >= startDate &&
                        x.Id != id,
                     cancellationToken
                    );
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
