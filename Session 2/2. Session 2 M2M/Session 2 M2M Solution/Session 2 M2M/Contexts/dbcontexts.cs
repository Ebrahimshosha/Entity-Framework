using Microsoft.EntityFrameworkCore;
using Session_2_M2M.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_M2M.Contexts
{
    internal class dbcontexts : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .; DataBase = EX05EF; Trusted_Connection = True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentCourses)
                .WithOne()
                .HasForeignKey(s=> s.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Course>()
                .HasMany(c=>c.CourseStudents)
                .WithOne()
				.OnDelete(DeleteBehavior.Cascade);


			modelBuilder.Entity<StudentCourse>().HasKey(SC => new { SC.StudentId, SC.CourseId }); // Composite PK
                
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; } 
    }
}
