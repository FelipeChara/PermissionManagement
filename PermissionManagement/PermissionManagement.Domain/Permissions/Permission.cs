using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagement.Domain.Permissions
{
    public class Permission(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, DateTime createdDate, DateTime updatedDate)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public Guid EmployeeId { get; private set; } = employeeId;

        public Guid PermissionTypeId { get; private set; } = permissionTypeId;

        public DateOnly StartDate { get; private set; } = startDate;

        public DateOnly EndDate { get; private set; } = endDate;

        public DateTime CreatedDate { get; private set; } = createdDate;

        public DateTime UpdatedDate { get; private set; } = updatedDate;
    }
}
