using Inheritance_Mapping.Contexts;
using Inheritance_Mapping.Entities;

namespace Inheritance_Mapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using dbcontext dbcontext = new dbcontext();

            FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            {
                Name = "Foo",
                Age = 1,
                Address = "alex",
                Salary = 10_000,
                StartDate = DateTime.Now
            };

            PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            {
                Name = "Foo0",
                Age = 10,
                Address = "cairo",
                CoutOfHour = 10,
                HourRate = 10
            };

            dbcontext.fullTimeEmployees.Add(fullTimeEmployee);
            dbcontext.partTimeEmployees.Add(partTimeEmployee);

            dbcontext.SaveChanges();

            foreach(var full in  dbcontext.fullTimeEmployees)
            {
                Console.WriteLine($"EmployeeName : {full.Name}, Salary : {full.Salary}");
            }
            
            Console.WriteLine("-----------------------------");

			foreach (var part in dbcontext.partTimeEmployees)
			{
				Console.WriteLine($"EmployeeName : {part.Name}, HourRate : {part.HourRate}");
			}
		}
    }
}