using FluentAssertions;
using PermissionManagement.Domain.PermisionTypes;

namespace PermissionManagement.Domain.UnitTests.PermissionTypes
{
    public class PermissionTypeTests
    {
        [Fact]
        public void Create_Should_SetProperty() 
        {
            PermissionType permissionType = new(
                PermissionTypeMock.Name,
                PermissionTypeMock.Description,
                PermissionTypeMock.Status
                );

            permissionType.Name.Should().Be(PermissionTypeMock.Name);
            permissionType.Description.Should().Be(PermissionTypeMock.Description);
            permissionType.Status.Should().Be(PermissionTypeMock.Status);
        }
    }
}
