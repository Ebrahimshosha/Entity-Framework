using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_2_M2M.Entities
{
    internal class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }

        // Navigational Property
        //public ICollection<Student> Students { get; set; } = new HashSet<Student>();

        public ICollection<StudentCourse> CourseStudents { get; set; } = new HashSet<StudentCourse>();


    }
}
