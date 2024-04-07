using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC_Project.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Project.DAL.Data.Configurations
{
    internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar");

            builder.Property(e => e.Address)
                .IsRequired();

            builder.Property(e => e.Salary)
                .HasColumnType("decimal(12,2)");

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.Address)
                .IsRequired();

            builder.Property(e => e.Gender)
                .HasConversion<string>(); // probably the same 😂

            //builder.Property(e => e.Gender).HasConversion(
            //                    (g) => g.ToString(), // Convert the Enum to string when saving in database
            //                    (str) => (Gender)Enum.Parse(typeof(Gender), str, true) // Convert the string to Enum when reading from database
            //                );

            builder.Property(e => e.EmployeeType)
                .HasConversion<string>();

            //builder.Property(e => e.EmployeeType).HasConversion(
            //                    (g) => g.ToString(), // Convert the Enum to string when saving in database
            //                    (str) => (EmplyeeType)Enum.Parse(typeof(EmplyeeType), str, true) // Convert the string to Enum when reading from database
            //                );





        }
    }
}
