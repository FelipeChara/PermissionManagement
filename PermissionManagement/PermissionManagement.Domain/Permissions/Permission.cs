namespace PermissionManagement.Domain.Permissions
{
    public class Permission
    {
        public Permission(Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, DateTime createdDate)
        {
            Id = Guid.NewGuid();
            EmployeeId = employeeId;
            PermissionTypeId = permissionTypeId;
            StartDate = startDate;
            EndDate = endDate;
            CreatedDate = createdDate;
        }

        public Permission(Guid id, Guid employeeId, Guid permissionTypeId, DateOnly startDate, DateOnly endDate, DateTime updatedDate)
        {
            Id = id;
            EmployeeId = employeeId;
            PermissionTypeId = permissionTypeId;
            StartDate = startDate;
            EndDate = endDate;
            UpdatedDate = updatedDate;
        }

        public Guid Id { get; init; }

        public Guid EmployeeId { get; private set; }

        public Guid PermissionTypeId { get; private set; }

        public DateOnly StartDate { get; private set; }

        public DateOnly EndDate { get; private set; }

        public DateTime CreatedDate { get; private set; }

        public DateTime? UpdatedDate { get; private set; }    
    }
}
