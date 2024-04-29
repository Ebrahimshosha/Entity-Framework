using LinkDev.Common;
using Microsoft.EntityFrameworkCore;
using Session_1_Fluent_API.configuration;
using Session_1_Fluent_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1_Fluent_API.Contexts
{
    internal class dbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = Ex02EF; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			// Fluent APIs 

			#region Fluent APIs

			//modelBuilder.Entity<Department>(EB =>
			//    {
			//        EB.HasKey("DepId");
			//        EB.HasKey(D => D.DepId);
			//        EB.HasKey(nameof(Department.DepId));

			//        EB.Property(D => D.DepId)
			//                    .UseIdentityColumn(10, 10);

			//        EB.Property(D => D.Name)
			//          .HasColumnName("DepName")
			//          .HasColumnType("varchar")
			//          .HasMaxLength(50)
			//          .IsRequired(true);
			//        //.HasAnnotation("MaxLength",50);

			//        EB.Property(D => D.DateOfCreation)
			//          .HasComputedColumnSql("GETDATE()");

			//    }); 
			#endregion

			modelBuilder.ApplyConfiguration<Department>(new DepartmentConfigration());

			base.OnModelCreating(modelBuilder);
		}

        public DbSet<Department> Departments { get; set; }
    }
}
