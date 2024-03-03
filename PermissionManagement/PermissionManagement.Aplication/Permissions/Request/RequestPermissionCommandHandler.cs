using PermissionManagement.Application.Abstractions.CQRS;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Permissions.Request
{
    internal class RequestPermissionCommandHandler(
        IPermissionRepository permissionRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<RequestPermissionCommand, Guid>
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository = permissionTypeRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(RequestPermissionCommand request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

            if (employee == null)
            {
                return Result.Failure<Guid>(EmployeeErrors.NotFound);
            }

            PermissionType? permissionType = await _permissionTypeRepository.GetByIdAsync(request.PermissionTypeId, cancellationToken);

            if (permissionType == null)
            { 
                return Result.Failure<Guid>(PermissionTypeErrors.NotFound);
            }
            if (!permissionType.Status)
            {
                return Result.Failure<Guid>(PermissionTypeErrors.Inactive);
            }

            if (await _permissionRepository.IsOverlappingAsync(request.EmployeeId, request.PermissionTypeId, request.StartDate, request.EndDate, cancellationToken))
            {
                return Result.Failure<Guid>(PermissionErrors.Overlap);
            }

            Permission permission = new(
                request.EmployeeId,
                request.PermissionTypeId,
                request.StartDate,
                request.EndDate,
                DateTime.Now
            );

            await _permissionRepository.RequestAsync(permission, cancellationToken);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return permission.Id;
        }
    }
}
