using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_3.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly? DateOfCreation { get; set; }

        //[InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
