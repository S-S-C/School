using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Instructor
    {
        public Instructor()
        {
            this.Courses = new HashSet<Course>();
        }
        public int InstructorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Course> Courses {get; set; }
    }
}