using AutoMapper;
using FluentAssertions;
using Moq;
using PermissionManagement.Application.Permissions.Get;
using PermissionManagement.Application.Permissions.Request;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Application.UnitTests.Permissions
{
    public class GetPermissionByEmployeeTest
    {
        private readonly Mock<IEmployeeRepository> mockEmployeeRepository;
        private readonly Mock<IPermissionRepository> mockPermissionRepository;
        private readonly Mock<IMapper> mockMapper;
        private readonly GetPermissionByEmployeeQueryHandler mockHandler;
        private readonly GetPermissionByEmployeeQuery mockQuery;
        private readonly Employee employee;

        public GetPermissionByEmployeeTest()
        {
            mockEmployeeRepository = new();
            mockPermissionRepository = new();
            mockMapper = new();

            mockHandler = new GetPermissionByEmployeeQueryHandler(mockPermissionRepository.Object, mockEmployeeRepository.Object, mockMapper.Object);

            mockQuery = new GetPermissionByEmployeeQuery(Guid.NewGuid());

            employee = new("Luis", "Chara", Email.Create("prueba@gmail.com").Value);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenEmployeeIsNull()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockQuery.EmployeeId, default)).ReturnsAsync((Employee?)null);

            Result<List<PermissionDTO>> result = await mockHandler.Handle(mockQuery, default);

            result.Error.Should().Be(EmployeeErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Success_WhenEmployeeIsValid()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockQuery.EmployeeId, default)).ReturnsAsync(employee);

            Result<List<PermissionDTO>> result = await mockHandler.Handle(mockQuery, default);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
