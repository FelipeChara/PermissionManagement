using FluentValidation;

namespace PermissionManagement.Application.Permissions.Request
{
    public class RequestPermissionCommandValidator : AbstractValidator<RequestPermissionCommand>
    {
        public RequestPermissionCommandValidator()
        {
            RuleFor(r => r.EmployeeId).NotEmpty();
            RuleFor(r => r.PermissionTypeId).NotEmpty();
            RuleFor(r => r.StartDate).NotEmpty();
            RuleFor(r => r.EndDate).NotEmpty();
            RuleFor(r => r.StartDate).LessThan(r => r.EndDate);
        }
    }
}
