using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesssion_2.Entities
{
    internal class Department
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime CreatedDate { get; set; }

        

        [InverseProperty("Department")]
        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();  // Navigational Property → Many

		/*
         *  we don't receive Employees in Specific collection, we receive Employees in Parent Interface "IEnumerable"
         *  Employees is a Reference can refere to any object from any class implementing Interface "IEnumerable"
         *  but in IEnumerable we can't add or remove on it because it is an iterable object, So 
         *  if U want to add or count or remove , Use Interface implementing IEnumerable have Functionality (add or count or remove)
         *  The Interface is ICollection
        */

		/*
         * in class Department has Employees property , Employees is a Reference So We must intialize Employees 
         * and Employee must implement Equals and Hashcode
        */
	}
}
