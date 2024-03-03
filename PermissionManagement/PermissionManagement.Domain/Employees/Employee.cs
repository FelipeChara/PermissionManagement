using PermissionManagement.Domain.Common;

namespace PermissionManagement.Domain.Employees
{
    public class Employee(string? name, string? lasName, Email? email)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Name { get; private set; } = name;

        public string? LastName { get; private set; } = lasName;

        public Email? Email { get; private set; } = email;
    }
}
