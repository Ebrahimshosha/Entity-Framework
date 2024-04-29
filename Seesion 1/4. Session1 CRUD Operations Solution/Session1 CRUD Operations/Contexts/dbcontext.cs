using Microsoft.EntityFrameworkCore;
using Session1_CRUD_Operations.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_CRUD_Operations.Contexts
{
    internal class dbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = .;Database = Ex03EF; Trusted_Connection = True");
        }


        public DbSet<Employee>? Employees { get; set; }
        
    }
}
