using AutoMapper;
using PermissionManagement.Application.Permissions.Get;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.Abstractions.Mapper
{
    public class Permission_PermissionDTO_Profile : Profile
    {
        public Permission_PermissionDTO_Profile()
        {
            CreateMap<Permission, PermissionDTO>();
        }
    }
}
