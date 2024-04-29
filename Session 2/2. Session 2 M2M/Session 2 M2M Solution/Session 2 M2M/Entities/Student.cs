using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_M2M.Entities
{
    internal class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Age { get; set; }
        public string Address { get; set; }

        // Navigational Property

        // public ICollection<Course> Courses { get; set; } = new HashSet<Course>(); 

        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();


    }
}
