using Microsoft.EntityFrameworkCore;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Infrastructure.EF;

namespace PermissionManagement.Infrastructure.Repositories
{
    internal class PermissionTypeRepository(ApplicationDbContext context) : IPermissionTypeRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<PermissionType?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.Set<PermissionType>().AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
