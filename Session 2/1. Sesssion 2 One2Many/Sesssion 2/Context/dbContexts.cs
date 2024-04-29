using Microsoft.EntityFrameworkCore;
using Sesssion_2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesssion_2.Context
{
    internal class dbContexts : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = Ex04EF; Trusted_Connection = True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Fluent APIs One To Many

            modelBuilder.Entity<Department>()
                   .HasMany(D => D.Employees)
                   .WithOne(E => E.Department)
                   .IsRequired(false) // Fk that created from this Relation will be Not Required
                   .HasForeignKey(E => E.DepartmentId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Or

            //modelBuilder.Entity<Employee>()
            //    .HasOne(E => E.Department)
            //    .WithMany(D => D.Employees); 

            #endregion
        }

        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
