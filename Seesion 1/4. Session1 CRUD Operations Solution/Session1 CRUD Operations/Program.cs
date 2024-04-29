using Microsoft.EntityFrameworkCore;
using Session1_CRUD_Operations.Contexts;
using Session1_CRUD_Operations.Entities;
using System.ComponentModel;

namespace Session1_CRUD_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (dbcontext dbcontext = new dbcontext())
            //{
            //    // CURD => Queryable Object Model
            //}

            #region using is a Syntax Sugar => TRy{} Finally{} ↓

            //dbcontext dbcontext = new dbcontext();

            //try
            //{
            //    // CURD => Queryable Object Model
            //}
            //finally 
            //{
            //    // Dealocate | Free | Delete | Close | Dispose [Database Connection]
            //    dbcontext.Dispose();

            //} 
            #endregion

            // new Syntax Sugar 

            using dbcontext dbcontext = new dbcontext();

			#region Insert

			//Employee E01 = new Employee() { Name = "Ahmed", Age = 30, Salary = 50_000 };
			//Employee E02 = new Employee() { Name = "Maiaa", Age = 40, Salary = 15_000 };

			//Console.WriteLine(dbcontext.Entry(E01).State); // Detached

			//// Add Local
			////Console.WriteLine(dbcontext.Employees.Add(E01));
			////Console.WriteLine(dbcontext.Set<Employee>().Add(E01));
			//Console.WriteLine(dbcontext.Add(E01)); // EF Core 3.1
			//Console.WriteLine(dbcontext.Add(E02)); // EF Core 3.1

			//Console.WriteLine(dbcontext.Entry(E01).State); // Added Local

			//// Add to Remote (DataBase)
			//dbcontext.SaveChanges();

			//Console.WriteLine(dbcontext.Entry(E01).State); // Unchanged

			//Console.WriteLine($"Employee 01 Id = {E01.Id}");
			//Console.WriteLine($"Employee 02 Id = {E02.Id}"); 

			#endregion


			var employee = (from E in dbcontext.Employees
                            where E.Id == 1
                            select E).FirstOrDefault();

            //Console.WriteLine(employee?.Name ?? "NA");


            #region Update

            //Console.WriteLine(dbcontext.Entry(employee).State); // Unchanged

            //employee.Name = "Hamada";

            //Console.WriteLine(dbcontext.Entry(employee).State); // Modified

            //dbcontext.SaveChanges();

            //Console.WriteLine(dbcontext.Entry(employee).State); // Unchanged

            #endregion

            #region Delete

            //// Remove from Local
            //dbcontext.Employees.Remove(employee);

            //Console.WriteLine(dbcontext.Entry(employee).State); // Deleted

            //// Remove From Remote
            //dbcontext.SaveChanges();

            //Console.WriteLine(dbcontext.Entry(employee).State); // Detached

            #endregion

        }
    }
}