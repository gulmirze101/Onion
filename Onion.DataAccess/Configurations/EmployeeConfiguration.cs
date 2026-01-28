using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Onion.Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Onion.DataAccess.Configurations
{
    internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.Position)
                .IsRequired()
                .HasMaxLength(256);
            builder.Property(x => x.ImagePath)
                .IsRequired()
                .HasMaxLength(1024);
            builder.Property(x => x.Salary)
                .IsRequired()
                .HasPrecision(9,2);

            builder.ToTable(options =>
            {
                options.HasCheckConstraint("CK_Employee_Salary", "[Salary]>=0");
            });

            builder.HasOne(x => x.Department).WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
