using AutoMapper;
using PermissionManagement.Application.Abstractions.CQRS;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Permissions.Get
{
    internal class GetPermissionByIdQueryHandler(IPermissionRepository permissionRepository, IMapper mapper)
        : IQueryHandler<GetPermissionByIdQuery, PermissionDTO?>
    {
        private readonly IPermissionRepository _permissionRepository = permissionRepository;
        private readonly IMapper _mapper = mapper;

        public async Task<Result<PermissionDTO?>> Handle(GetPermissionByIdQuery request, CancellationToken cancellationToken)
        {
            Permission? permission = await _permissionRepository.GetByIdAsync(request.Id, cancellationToken);

            if (permission == null)
            {
                return Result.Failure<PermissionDTO?>(PermissionErrors.NotFound);
            }

            PermissionDTO permissionDTO = _mapper.Map<PermissionDTO>(permission);

            return permissionDTO;
        }
    }

}
