using FluentAssertions;
using Moq;
using PermissionManagement.Application.Abstractions.Services;
using PermissionManagement.Application.Permissions.Request;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;


namespace PermissionManagement.Application.UnitTests.Permissions
{
    public class RequestPermissionTests
    {
        private readonly Mock<IEmployeeRepository> mockEmployeeRepository;
        private readonly Mock<IPermissionTypeRepository> mockPermissionTypeRepository;
        private readonly Mock<IPermissionRepository> mockPermissionRepository;
        private readonly Mock<ISearchService> mockSearchService;
        private readonly Mock<IUnitOfWork> mockUnitOfWork;
        private readonly RequestPermissionCommandHandler mockHandler;
        private readonly RequestPermissionCommand mockCommand;
        private readonly Employee employee;
        private readonly PermissionType permissionTypeActive;
        private readonly PermissionType permissionTypeInactive;

        public RequestPermissionTests() 
        {
            mockEmployeeRepository = new();
            mockPermissionTypeRepository = new();
            mockPermissionRepository = new();
            mockSearchService = new();
            mockUnitOfWork = new();

            mockHandler = new RequestPermissionCommandHandler(mockPermissionRepository.Object, mockPermissionTypeRepository.Object, mockEmployeeRepository.Object, mockUnitOfWork.Object, mockSearchService.Object);

            mockCommand = new RequestPermissionCommand(Guid.NewGuid(), Guid.NewGuid(), new DateOnly(2023, 1 , 10), new DateOnly(2023, 1 , 10));

            employee = new("Luis", "Chara", Email.Create("prueba@gmail.com").Value);
            permissionTypeActive = new("Conuslta", "Realiza consultas", true);
            permissionTypeInactive = new("Conuslta", "Realiza consultas", false);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenEmployeeIsNull()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync((Employee?)null);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(EmployeeErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionTypeIsNull()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync((PermissionType?)null);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionTypeErrors.NotFound);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionTypeIsInactive()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync(permissionTypeInactive);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionTypeErrors.Inactive);
        }

        [Fact]
        public async Task Handle_Slould_Failure_WhenPermissionIsOverlap()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync(permissionTypeActive);
            mockPermissionRepository.Setup(x => x.IsOverlappingAsync(mockCommand.EmployeeId, mockCommand.PermissionTypeId, mockCommand.StartDate, mockCommand.EndDate, default)).ReturnsAsync(true);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.Error.Should().Be(PermissionErrors.Overlap);
        }

        [Fact]
        public async Task Handle_Slould_Success_WhenPermissionIsValid()
        {
            mockEmployeeRepository.Setup(x => x.GetByIdAsync(mockCommand.EmployeeId, default)).ReturnsAsync(employee);
            mockPermissionTypeRepository.Setup(x => x.GetByIdAsync(mockCommand.PermissionTypeId, default)).ReturnsAsync(permissionTypeActive);
            mockPermissionRepository.Setup(x => x.IsOverlappingAsync(mockCommand.EmployeeId, mockCommand.PermissionTypeId, mockCommand.StartDate, mockCommand.EndDate, default)).ReturnsAsync(false);

            Result<Guid> result = await mockHandler.Handle(mockCommand, default);

            result.IsSuccess.Should().BeTrue();
        }


    }
}
