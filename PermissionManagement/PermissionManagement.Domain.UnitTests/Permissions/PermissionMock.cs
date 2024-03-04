namespace PermissionManagement.Domain.UnitTests.Permissions
{
    internal class PermissionMock
    {
        public static readonly Guid Id = Guid.NewGuid();
        public static readonly Guid EmployeeId = Guid.NewGuid();
        public static readonly Guid PermissionTypeId = Guid.NewGuid();
        public static readonly DateOnly StartDate = new(2023, 1, 10);
        public static readonly DateOnly EndDate = new(2023, 1, 15);
        public static readonly DateTime CreatedDate = DateTime.Now;
        public static readonly DateTime UpdatedDate = DateTime.Now;
    }
}
