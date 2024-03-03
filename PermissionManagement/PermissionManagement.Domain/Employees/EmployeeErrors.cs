using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Domain.Employees
{
    public class EmployeeErrors
    {
        public static readonly Error NotFound = new(
            "Employee.Found",
            "No existe el empleado buscado por este id"
        );
    }
}
