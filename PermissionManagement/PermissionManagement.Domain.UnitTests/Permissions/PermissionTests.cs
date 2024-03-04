using FluentAssertions;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Domain.UnitTests.Permissions
{
    public class PermissionTests
    {
        [Fact]
        public void Create_Should_SetProperty()
        {
            Permission permission = new(
                PermissionMock.EmployeeId,
                PermissionMock.PermissionTypeId,
                PermissionMock.StartDate,
                PermissionMock.EndDate,
                PermissionMock.CreatedDate
                );

            permission.EmployeeId.Should().Be(PermissionMock.EmployeeId);
            permission.PermissionTypeId.Should().Be(PermissionMock.PermissionTypeId);
            permission.StartDate.Should().Be(PermissionMock.StartDate);
            permission.CreatedDate.Should().Be(PermissionMock.CreatedDate);
            permission.UpdatedDate.Should().BeNull();
        }

        [Fact]
        public void Modify_Should_SetProperty()
        {
            Permission permission = new(
                PermissionMock.Id,
                PermissionMock.EmployeeId,
                PermissionMock.PermissionTypeId,
                PermissionMock.StartDate,
                PermissionMock.EndDate,
                PermissionMock.UpdatedDate
                );

            permission.Id.Should().Be(PermissionMock.Id);
            permission.EmployeeId.Should().Be(PermissionMock.EmployeeId);
            permission.PermissionTypeId.Should().Be(PermissionMock.PermissionTypeId);
            permission.StartDate.Should().Be(PermissionMock.StartDate);
            permission.UpdatedDate.Should().Be(PermissionMock.UpdatedDate);
        }
    }
}
