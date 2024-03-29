﻿using PermissionManagement.Application.Abstractions.CQRS;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Permissions.Modify
{
    internal class ModifyPermissionCommandHandler(
        IPermissionRepository permissionRepository,
        IPermissionTypeRepository permissionTypeRepository,
        IEmployeeRepository employeeRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<ModifyPermissionCommand, Guid>
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository = permissionTypeRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<Guid>> Handle(ModifyPermissionCommand request, CancellationToken cancellationToken)
        {
            Permission? permission = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (permission == null)
            {
                return Result.Failure<Guid>(PermissionErrors.NotFound);
            }

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

            if (await _permissionRepository.IsOverlappingModifyAsync(request.Id, request.EmployeeId, request.PermissionTypeId, request.StartDate, request.EndDate, cancellationToken))
            {
                return Result.Failure<Guid>(PermissionErrors.Overlap);
            }

            Permission permissionModify = new(
                request.Id,
                request.EmployeeId,
                request.PermissionTypeId,
                request.StartDate,
                request.EndDate,
                DateTime.Now
            );

            _permissionRepository.Modify(permissionModify);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return permission.Id;
        }
    }
}
