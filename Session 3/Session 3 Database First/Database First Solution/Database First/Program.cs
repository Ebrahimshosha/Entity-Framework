using Database_First.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Database_First
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// First : We install " Ef Core Power Tool " Extesnsion
			using NorthwindContext northwindContext = new NorthwindContext();

			#region Local Vs Remote

			//northwindContext.Products.Load(); // Populate Local With All Products From Database  

			//if (northwindContext.Products.Local.Any(p => p.UnitsInStock == 0))
			//    Console.WriteLine("There is at least one Product out of Stock");
			//else if (northwindContext.Products.Any(p => p.UnitsInStock == 0))
			//    Console.WriteLine("There is at least one Product out of Stock");
			//else
			//    Console.WriteLine("There is No Product out of Stock");

			//var Res = northwindContext.Products.Find(1); // Find → Automaticly Will check first in Local Then Remotly
			//Res = northwindContext.Find<Product>(1); // Another Syntax in EF Core 3.2

			#endregion

			#region Run SQL Query


			#region 1. Excute Select Statement : FromSqlRaw(), FromSqlInterpolated()

			//int Count = 2;

			//var catogery = northwindContext.Categories.FromSqlRaw("select * from categories");
			//catogery = northwindContext.Categories.FromSqlRaw("select top({0}) * from categories", Count);
			//catogery = northwindContext.Categories.FromSqlInterpolated($"select top({Count}) * from categories");


			//foreach (var item in catogery)
			//{
			//    Console.WriteLine(item);
			//} 

			#endregion

			#region 2. Excute DML Statment : [ insert, update, delete ] ExcuteSqlRaw(), ExcuteSqlInterpolated()

			//northwindContext.Database.ExecuteSqlRaw("update categories set categoryName = 'new' where categoryId = 2");
			//northwindContext.Database.ExecuteSqlInterpolated($"update categories set categoryName = 'new' where categoryId = 2");

			#endregion

			#endregion

			#region Calling Stored Procedure

			#region First Way

			//var CategoryName = new SqlParameter("@CategoryName", "Beverages") { Direction = System.Data.ParameterDirection.Input };
			//var OrdYear = new SqlParameter("@OrdYear", "1998") { Direction = System.Data.ParameterDirection.Input };

			//var Result = northwindContext.salesByCategories.FromSqlRaw("EXEC SalesByCategory @CategoryName, @OrdYear", CategoryName, OrdYear).ToList();

			//foreach (var item in Result)
			//{
			//	Console.WriteLine(item.ProductName,item.TotalPurchase);
			//}

			//// Must Dbset for salesByCategories in context
			//// on OnModelCreating  Dbset doesn't convert to table

			#endregion

			#region Second Way → Ef Core Power Tool

			//// First : We install " Ef Core Power Tool " Extesnsion
			///
			//NorthwindContextProcedures Procedures = new NorthwindContextProcedures(northwindContext);
			//var products = Procedures.SalesByCategoryAsync("Beverages", "1998");
			//foreach (var product in products.Result)
			//{
			//	Console.WriteLine(product);
			//}  

			#endregion

			#endregion

		}
	}

}