using PermissionManagement.Domain.Abstractions;

namespace PermissionManagement.Domain.PermisionTypes
{
    public  class PermissionTypeErrors
    {
        public static readonly Error NotFound = new(
            "PermissionType.Found",
            "No existe el tipo de permiso buscado por este id"
        );

        public static readonly Error Inactive = new(
            "PermissionType.Inactive",
            "El tipo de permiso esta inactivo"
        );
    }
}
