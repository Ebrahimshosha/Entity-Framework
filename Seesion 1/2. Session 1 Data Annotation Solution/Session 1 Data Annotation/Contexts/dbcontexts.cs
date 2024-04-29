using System;
using Microsoft.EntityFrameworkCore;
using Session_1_Data_Annotation.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Session_1_Data_Annotation.Contexts
{
    internal class dbcontexts : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = Ex02EF; Trusted_Connection = True");

        }
        public DbSet<Employee> Employees { get; set; }
    }
}
