namespace PermissionManagement.Application.Exceptions
{
    public record ValidationError(string Property, string Message);
}
