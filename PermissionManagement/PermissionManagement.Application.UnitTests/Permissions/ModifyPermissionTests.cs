using FluentAssertions;
using Moq;
using PermissionManagement.Application.Abstractions.Services;
using PermissionManagement.Application.Permissions.Modify;
using PermissionManagement.Application.Permissions.Request;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagement.Application.UnitTests.Permissions
{
    public  class ModifyPermissionTests
    {
        private readonly Mock<IEmployeeRepository> mockEmployeeRepository;
        private readonly Mock<IPermissionTypeRepository> mockPermissionTypeRepository;
        private readonly Mock<IPermissionRepository> mockPermissionRepository;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly ModifyPermissionCommandHandler mockHandler;
        private readonly ModifyPermissionCommand mockCommand;
        private readonly Employee employee;
        private readonly PermissionType permissionTypeActive;
        private readonly Permission permission;

        public ModifyPermissionTests()
        {
            mockEmployeeRepository = new();
            mockPermissionTypeRepository = new();
            mockPermissionRepository = new();
            mockUnitOfWork = new();

            mockHandler = new ModifyPermissionCommandHandler(mockPermissionRepository.Object, mockPermissionTypeRepository.Object, mockEmployeeRepository.Object, mockUnitOfWork.Object);

            mockCommand = new ModifyPermissionCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2023, 1, 10), new DateOnly(2023, 1, 10));

            employee = new("Luis", "Chara", Email.Create("prueba@gmail.com").Value);
            permissionTypeActive = new("Conuslta", "Realiza consultas", true);
            permission = new(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2023, 1, 10), new DateOnly(2023, 1, 10), DateTime.Now);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionIsNull()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockCommand.Id, default)).ReturnsAsync((Permission?)null);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenEmployeeIsNull()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockCommand.Id, default)).ReturnsAsync(permission);
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync((Employee?)null);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(EmployeeErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionTypeIsNull()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockCommand.Id, default)).ReturnsAsync(permission);
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync((PermissionType?)null);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionTypeErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionIsOverlap()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockCommand.Id, default)).ReturnsAsync(permission);
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync(permissionTypeActive);
            mockPermissionRepository.Setup(x => x.IsOverlappingModifyAsync(mockCommand.Id, mockCommand.EmployeeId, mockCommand.PermissionTypeId, mockCommand.StartDate, mockCommand.EndDate, default)).ReturnsAsync(true);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionErrors.Overlap);
        }

        [Fact]
        public async Task Handle_Slould_Success_WhenPermissionIsValid()
        {
            mockPermissionRepository.Setup(x => x.GetByIdAsync(mockCommand.Id, default)).ReturnsAsync(permission);
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync(permissionTypeActive);
            mockPermissionRepository.Setup(x => x.IsOverlappingModifyAsync(mockCommand.Id, mockCommand.EmployeeId, mockCommand.PermissionTypeId, mockCommand.StartDate, mockCommand.EndDate, default)).ReturnsAsync(false);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.IsSuccess.Should().BeTrue();
        }
    }
}
