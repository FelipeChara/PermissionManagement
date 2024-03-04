using AutoMapper;
using FluentAssertions;
using Moq;
using PermissionManagement.Application.Permissions.Get;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.UnitTests.Permissions
{
    public class GetPermissionByIdTests
    {
        private readonly Mock<IPermissionRepository> mockPermissionRepository;
        private readonly Mock<IMapper> mockMapper;
        private readonly GetPermissionByIdQueryHandler mockHandler;
        private readonly GetPermissionByIdQuery mockQuery;

        public GetPermissionByIdTests()
        {
            mockPermissionRepository = new();
            mockMapper = new();

            mockHandler = new GetPermissionByIdQueryHandler(mockPermissionRepository.Object, mockMapper.Object);

            mockQuery = new GetPermissionByIdQuery(Guid.NewGuid());
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionIsNull()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockQuery.Id, default)).ReturnsAsync((Permission?)null);

            Result<PermissionDTO?> result = await mockHandler.Handle(mockQuery, default);

            result.Error.Should().Be(PermissionErrors.NotFound);
        }        
    }
}
