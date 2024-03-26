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
    internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Fluent API for configuring the Department entity

            builder.Property(d => d.Id)
                .UseIdentityColumn(10, 10);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar");


        }
    }
}
