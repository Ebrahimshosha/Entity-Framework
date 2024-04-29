using LinkDev.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Session_1_Fluent_API.configuration
{
    internal class DepartmentConfigration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> EB)
        {

            EB.HasKey("DepId");
            EB.HasKey(D => D.DepId);
            EB.HasKey(nameof(Department.DepId));

            EB.Property(D => D.DepId)
                        .UseIdentityColumn(10, 10);

            EB.Property(D => D.Name)
                      .HasColumnName("DepName")
                      .HasColumnType("varchar")
                      .HasMaxLength(50)
                      .IsRequired(true);

            EB.Property(D => D.DateOfCreation)
                      .HasComputedColumnSql("GETDATE()");


        }
    }
}
