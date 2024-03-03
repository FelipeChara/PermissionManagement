namespace PermissionManagement.Application.Permissions.Get
{
    public record PermissionDTO
    {
        public Guid Id { get; init; }

        public Guid EmployeeId { get; set; }

        public Guid PermissionTypeId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public DateTime CreatedDate { get; set; }

    }
}
