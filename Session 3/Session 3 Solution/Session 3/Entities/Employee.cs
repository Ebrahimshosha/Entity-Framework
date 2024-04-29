using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_3.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public decimal Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")] // ForeignKey → Take Navigational Property name, U can don't write this if ForeignKey name is DepartmentId
        public int DepartmentId { get; set; } // ForeignKey

        //[InverseProperty("Employees")]
        public virtual Department Department { get; set; } // Navigational Property [ONE] [Related Data]
    }
}
