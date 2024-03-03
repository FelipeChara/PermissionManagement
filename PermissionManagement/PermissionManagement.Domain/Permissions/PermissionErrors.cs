using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Domain.Permissions
{
    public class PermissionErrors
    {
        public static readonly Error NotFound = new(
            "Permission.Found",
            "No existe el permiso buscado por este id"
        );

        public static readonly Error Overlap = new(
            "Permission.Overlap",
            "El empleado ya cuenta con el permiso"
        );
    }
}
