using FluentValidation;

namespace PermissionManagement.Application.Permissions.Modify
{
    public class ModifyPermissionCommandValidator : AbstractValidator<ModifyPermissionCommand>
    {
        public ModifyPermissionCommandValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.EmployeeId).NotEmpty();
            RuleFor(r => r.PermissionTypeId).NotEmpty();
            RuleFor(r => r.StartDate).NotEmpty();
            RuleFor(r => r.EndDate).NotEmpty();
            RuleFor(r => r.StartDate).LessThan(r => r.EndDate);
        }
    }
}
