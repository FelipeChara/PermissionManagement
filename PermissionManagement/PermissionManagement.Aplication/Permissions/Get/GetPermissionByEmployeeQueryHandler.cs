using AutoMapper;
using PermissionManagement.Application.Abstractions.CQRS;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Permissions.Get
{
    internal class GetPermissionByEmployeeQueryHandler(IPermissionRepository permissionRepository, IEmployeeRepository employeeRepository, IMapper mapper)
        : IQueryHandler<GetPermissionByEmployeeQuery, List<PermissionDTO>>
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<List<PermissionDTO>>> Handle(GetPermissionByEmployeeQuery request, CancellationToken cancellationToken)
        {
            Employee? employee = await _employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

            if (employee == null)
            {
                return Result.Failure<List<PermissionDTO>>(EmployeeErrors.NotFound);
            }

            List<Permission> permissions = await _permissionRepository.GetByEmployeeIdAsync(request.EmployeeId, cancellationToken);

            List<PermissionDTO> permissionDTOs = permissions == null ? [] : _mapper.Map<List<PermissionDTO>>(permissions);

            return permissionDTOs;
        }
    }

}
