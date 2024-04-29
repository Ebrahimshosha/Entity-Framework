using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesssion_2.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Salary { get; set; }

		public int DepartmentId { get; set; }

		[InverseProperty("Employees")]
        public Department Department { get; set; } // Navigational Property → One
    }
}
