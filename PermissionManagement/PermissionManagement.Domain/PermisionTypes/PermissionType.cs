namespace PermissionManagement.Domain.PermisionTypes
{
    public class PermissionType(string? name, string? description, bool status)
    {
        public Guid Id { get; init; } = Guid.NewGuid();

        public string? Name { get; private set; } = name;

        public string? Description { get; private set; } = description;

        public bool Status { get; private set; } = status;
    }
}
