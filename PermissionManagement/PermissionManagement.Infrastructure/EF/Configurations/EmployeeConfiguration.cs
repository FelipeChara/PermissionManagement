using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;

namespace PermissionManagement.Infrastructure.EF.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable(nameof(Employee));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.LastName)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired()
                .HasConversion(e => e.Value, value => Email.Create(value).Value);                
        }
    }
}
