using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PermissionManagement.Domain.Common;
using PermissionManagement.Domain.Employees;
using PermissionManagement.Domain.PermisionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermissionManagement.Infrastructure.EF.Configurations
{
    internal class PermissionTypeConfiguration : IEntityTypeConfiguration<PermissionType>
    {
        public void Configure(EntityTypeBuilder<PermissionType> builder)
        {            
            builder.ToTable(nameof(PermissionType));
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasMaxLength(500)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired();
            
        }
    }
}
