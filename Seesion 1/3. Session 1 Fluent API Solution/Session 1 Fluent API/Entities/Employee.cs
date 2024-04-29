using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1_Fluent_API.Entities
{
	/// Ef Core Supports 4 Ways For Mapping Classes to Database ( Tables | Views | Function)
	/// 1. By Convention (Default Bahaviour)
	/// 2. Data Annotation (Set of Attributes Used For Data Validation)
	/// 3. Fluent APIs (DbContext → Override OnModelCreation)
	/// 4. ConfigurationClass Per Entity → Organize 3rd Way
	internal class Employee
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public Decimal Salary { get; set; }
		public int? Age { get; set; }
	}
}
