using FluentAssertions;
using PermissionManagement.Domain.Abstractions;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;

namespace PermissionManagement.Domain.UnitTests.Employees
{
    public class EmployeeTests
    {
        [Fact]
        public void Create_Should_SetProperty() 
        {
            Employee employee = new(
                EmployeeMock.Name,
                EmployeeMock.LastName,
                EmployeeMock.Email
                );

            employee.Name.Should().Be(EmployeeMock.Name);
            employee.LastName.Should().Be(EmployeeMock.LastName);
            employee.Email.Should().Be(EmployeeMock.Email);
        }

        [Fact]
        public void Create_Should_Email_Failure()
        {
            string email = "prueba";

            Result<Email> result = Email.Create(email);

            result.IsFailure.Should().BeTrue();
            result.IsSuccess.Should().BeFalse();
        }
    }
}
