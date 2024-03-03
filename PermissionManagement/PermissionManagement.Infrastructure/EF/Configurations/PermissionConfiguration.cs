
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using PermissionManagement.Domain.Permissions;

namespace PermissionManagement.Infrastructure.EF.Configurations
{
    internal class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(nameof(Permission));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.StartDate)
                .IsRequired();

            builder.Property(e => e.EndDate)
                .IsRequired();

            builder.Property(e => e.CreatedDate)
                .IsRequired();

            builder.Property(e => e.UpdatedDate);

            builder.HasOne<Employee>()
                .WithMany()
                .HasForeignKey(e => e.EmployeeId);

            builder.HasOne<PermissionType>()
                .WithMany()
                .HasForeignKey(e => e.PermissionTypeId);
        }
    }
}
