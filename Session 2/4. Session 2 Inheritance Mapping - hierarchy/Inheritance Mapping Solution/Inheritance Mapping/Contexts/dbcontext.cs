using Inheritance_Mapping.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Mapping.Contexts
{
    internal class dbcontext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; Database = EX09EF ; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			// Fluent APIs

			// hierarchy table (FullTimeEmployee + PartTimeEmployee in one table)
			modelBuilder.Entity<FullTimeEmployee>().HasBaseType<Employee>();
            modelBuilder.Entity<PartTimeEmployee>().HasBaseType<Employee>();

			modelBuilder.Entity<FullTimeEmployee>()
                .Property(F => F.Salary)
                .HasColumnType("decimal(18,3)");

            modelBuilder.Entity<PartTimeEmployee>()
                .Property(P => P.HourRate)
                .HasColumnType("decimal(10,2)");
        }

        //Table Per Concrete Class → TPCC
        //public DbSet<FullTimeEmployee> fullTimeEmployees { get; set; }
        //public DbSet<PartTimeEmployee> partTimeEmployees { get; set; }
        public DbSet<Employee> Employees { get; set;}
    }
}
