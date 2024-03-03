using PermissionManagement.Domain.Common;

namespace PermissionManagement.Domain.Employees
{
    public class Employee(string? nombre, string? apellido, Email? email)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Nombre { get; private set; } = nombre;

        public string? Apellido { get; private set; } = apellido;

        public Email? Email { get; private set; } = email;
    }
}
