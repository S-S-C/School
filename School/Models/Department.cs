using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Department
    {
        public Department()
        {
            this.Instructors = new HashSet<Instructor>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int InstructorId { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}