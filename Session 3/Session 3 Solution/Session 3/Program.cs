using Microsoft.EntityFrameworkCore;
using Session_3.Context.NewFolder;

namespace Session_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			using dbcontext dbcontext = new dbcontext();

			#region load Navigational Property

			#region By Default Navigational Property [Related Data] doesn't loading 

			#region Ex01

			//var employee = (from E in dbcontext.Employees
			//                where E.Id == 2
			//                select E).FirstOrDefault();

			//Console.WriteLine($"EmpName : {employee?.Name ?? "NA"}, Dept : {employee?.Department?.Name ?? "No Department"}");

			#endregion

			#region EX02

			//var dep = (from D in dbcontext.Department
			//          where D.Id == 10
			//          select D).FirstOrDefault();

			//Console.WriteLine($"DepartmentId : {dep.Id}, DepartmentName : {dep.Name}");

			//foreach ( var emp in dep.Employees )
			//{
			//    Console.WriteLine($"EmployeetId : {emp.Id}, EmployeeName : {emp.Name}");

			//} 

			#endregion

			#endregion

			// To get/load Navigational Property [related data] from database There are 3 ways

			#region 1. Explicit Loading 

			#region EX 01

			//var employee = (from E in dbcontext.Employees
			//                where E.Id == 2
			//                select E).FirstOrDefault();

			//dbcontext.Entry(employee).Reference(E => E.Department).Load();

			//Console.WriteLine($"EmpName : {employee?.Name ?? "NA"}, Dept : {employee?.Department?.Name ?? "No Department"}");

			#endregion

			#region EX 02

			//var dep = (from D in dbcontext.Department
			//           where D.Id == 10
			//           select D).FirstOrDefault();

			//Console.WriteLine($"DepartmentId : {dep.Id}, DepartmentName : {dep.Name}");

			//dbcontext.Entry(dep).Collection(D=>D.Employees).Load();

			//foreach (var emp in dep.Employees)
			//{
			//    Console.WriteLine($"EmployeetId : {emp.Id}, EmployeeName : {emp.Name}");

			//}

			#endregion

			// DisAdvantage : more database query → Extra Trip, 2 request
			// Advantage : allows you to control when to load related data based on your application's needs,
			//			   potentially reducing the amount of data retrieved from the database

			#endregion

			#region 2. Eager Loading

			#region EX 01

			//var employee = (from E in dbcontext.Employees.Include(E=>E.Department)
			//                where E.Id == 2
			//                select E).FirstOrDefault();


			//Console.WriteLine($"EmpName : {employee?.Name ?? "NA"}, Dept : {employee?.Department?.Name ?? "No Department"}");

			#endregion

			#region EX 02

			//var dep = (from D in dbcontext.Department.Include(D => D.Employees)
			//           where D.Id == 10
			//           select D).FirstOrDefault();

			//Console.WriteLine($"DepartmentId : {dep.Id}, DepartmentName : {dep.Name}");

			//foreach (var emp in dep.Employees)
			//{
			//    Console.WriteLine($"EmployeetId : {emp.Id}, EmployeeName : {emp.Name}");

			//}

			#endregion

			// Include() => left Join between Two Tables, beacuase if there is an empoyee not exists in Department

			// Advantage : Only One database query [Only One Request]

			// DisAdvantage : Will always retrieve the related Data

			/*  Use Eager Loading :
             *  when the relations are not too much or
             *  When you are sure that you will use related Data with the main entity everywhere.
            */

			#endregion

			#region 3. Lazy Loading

			#region To enalble Lazy Loading Mood U need 4 things :

			// 1. Install Microsoft.EntityFrameworkCore.Proxies Package
			// 2. In OnConfiguring method in dbcontext class U add .UseLazyLoadingProxies() Function ,This Func exists in Microsoft.EntityFrameworkCore.Proxies Package
			// 3. All Navigational Property in Project Must be Virtual
			// 4. All Models [DbSet] must be public

			#endregion

			// it means :
			// delaying the data loading
			// Or until the specifically you request it
			// Or we can say on-demand loading.

			// note : Lazy Loading like Explicit Loading but implicitly [without additional code]

			#region EX 01

			//var employee = (from E in dbcontext.Employees
			//                where E.Id == 2
			//                select E).FirstOrDefault();


			//Console.WriteLine($"EmpName : {employee?.Name ?? "NA"}, Dept : {employee?.Department?.Name ?? "No Department"}");

			#endregion

			#region EX 02

			//var dep = (from D in dbcontext.Department
			//           where D.Id == 10
			//           select D).FirstOrDefault();

			//Console.WriteLine($"DepartmentId : {dep.Id}, DepartmentName : {dep.Name}");

			//foreach (var emp in dep.Employees)
			//{
			//    Console.WriteLine($"EmployeetId : {emp.Id}, EmployeeName : {emp.Name}");

			//}

			#endregion

			// DisAdvantage : more database query

			#endregion

			// VIP Note :
			// If Navigational Property is one   → Use Eager loading
			// If Navigational Property is many → Use Lazy loading 

			#endregion

			#region LINQ - Join Operators

			// Query Expression
			//var Result = from E in dbcontext.Employees
			//             join D in dbcontext.Department
			//             on E.DepartmentId equals D.Id
			//             where E.Address == "Cairo"
			//             select new
			//             {
			//                 empId = E.Id,
			//                 DeptName = D.Name,
			//                 empAddress = E.Address
			//             };

			// Fluent Expression
			//Result = dbcontext.Employees.Join(dbcontext.Department,
			//    E => E.DepartmentId,
			//    D => D.Id,
			//    (E, D) => new
			//    {
			//        empId = E.Id,
			//        DeptName = D.Name,
			//        empAddress = E.Address
			//    }).Where(e => e.empAddress == "Cairo");

			//foreach (var E in Result)
			//{
			//    Console.WriteLine(E);
			//}

			#endregion

			#region Mapping View

			/// To Read Data From View 
			/// 1. write viem in UP method after creating empty migrate
			/// 2. create EmplyeeDepartmentView class → Property is same Attribute in View
			/// 3. crete Dbset to  EmplyeeDepartmentView 
			/// 4. To EF convert dbdet to view not Table , we configure it with Fluent Api 

			//foreach (var item in dbcontext.EmplyeeDepartmentView)
			//{
			//    Console.WriteLine($"EmpName : {item.EmpName}, DeptName : {item.DeptName} ");
			//}

			#endregion

			#region Tracking Vs NoTracking

			#region Tracking - ByDefault

			//var employee = (from E in dbcontext.Employees
			//                where E.Id == 2
			//                select E).FirstOrDefault();

			//Console.WriteLine(dbcontext.Entry(employee).State); // UnChanged

			//employee.Name = "Hamada"; // Locally

			//Console.WriteLine(dbcontext.Entry(employee).State); // Modified

			//dbcontext.SaveChanges(); 

			#endregion

			#region NoTracking

			//// if U don't want to Generalize "AsNoTracking"
			//// dbcontext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

			//var employee = (from E in dbcontext.Employees
			//                where E.Id == 2
			//                select E).AsNoTracking().FirstOrDefault();

			//Console.WriteLine(dbcontext.Entry(employee).State); // Detached

			//employee.Name = "Hambozo"; // does'nt change local

			//Console.WriteLine(dbcontext.Entry(employee).State); // Detached

			//dbcontext.SaveChanges();

			#endregion

			#endregion


		}
	}
}