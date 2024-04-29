using Microsoft.EntityFrameworkCore;
using Session_1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1.Contexts
{

    // To connect With SQL Service must be pass 3 information ["Server Name","Db Name","Authentication Type"] (Connection String) to - Function ,
    // This Function Responsible For Connection With DataBase
    // Which is in "dbContexts" Class
    // Which is in "Microsoft.EntityFrameworkCore" Library
    // Which is in "Microsoft.EntityFrameworkCore.SqlServer" Paackage 
    internal class dbContexts :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source = DESKTOP-5VC6KUT;Initial Catalog = Ex01EF; Integrated Security = True") ;
            optionsBuilder.UseSqlServer("Server = .;Database = Ex01EF; Trusted_Connection = True");

        }

        // Employee Class will be Employees Table 
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department>departments { get; set; }
        public DbSet<Project> projects { get; set; }
        //public DbSet<Product> products { get; set; }
    }
}
