namespace PermissionManagement.Application.Exceptions
{
    public class ValidationException(IEnumerable<ValidationError> error) : Exception
    {
        public IEnumerable<ValidationError> Errors { get; } = error;
    }
}
