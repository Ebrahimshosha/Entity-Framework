using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session1_CRUD_Operations.Entities
{
    internal class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public Decimal Salary { get; set; }
        public int? Age { get; set; }
    }
}
