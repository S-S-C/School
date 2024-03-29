﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace School.Models
{
    public class Course
    {
        public Course ()
        {
            this.Enrollments = new HashSet<Enrollment>();
        }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments {get; set; }
        public virtual ICollection<Instructor> Instructors {get; set; }
    }
}