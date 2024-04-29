using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_1.Entities
{
    /// Ef Core Supports 4 Ways For Mapping Classes to Database ( Tables | Views | Function)
    /// 1. By Convention (Default Bahaviour)
    /// 2. Data Annotation (Set of Attributes Used For Data Validation)
    /// 3. Fluent APIs (DbContext → Override OnModelCreation)
    /// 4. ConfigurationClass Per Entity → Organize 3rd Way

    // POCO Class
    // Plain Old CLR oBJECT
    // POCO Claass : No Behaviours, No Functionality, All it have Just Properties
    internal class Employee
    {
        public int Id { get; set; }         // Public Numeric Property Named as "Id" | "EmployeeId" → PK [Identity(1,1)]
        public string? Name { get; set; }   // Nullable String   : Allow Null [Optional] [string must be Nullable ]
        public Decimal Salary { get; set; } // Value Type       : Not Allow Null [Required]
        public int? Age { get; set; }       // Nullable Int     : Allow Null [Optional]
        

    }
}
