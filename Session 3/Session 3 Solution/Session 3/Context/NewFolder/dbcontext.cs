using Microsoft.EntityFrameworkCore;
using Session_3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_3.Context.NewFolder
{
    internal class dbcontext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server = .;Database = Ex07EF;Trusted_Connection = True;TrustServerCertificate=true", x => x.UseDateOnlyTimeOnly());
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Department>().ToTable("Departments");

			modelBuilder.Entity<Department>()
                .Property(D => D.Id)
                .UseIdentityColumn(10, 10);

            modelBuilder.Entity<Department>()
                .Property(D => D.DateOfCreation)
                .IsRequired(false)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Employee>()
                .HasOne(E => E.Department)
                .WithMany()
                .IsRequired(false);

            modelBuilder.Entity<EmplyeeDepartmentView>().ToView("EmplyeeDepartment").HasNoKey();
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmplyeeDepartmentView> EmplyeeDepartmentView { get; set; }
    }
}
