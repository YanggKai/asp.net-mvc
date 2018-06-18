using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TotalMVC.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public int CourseID { get; set; }

        public Student Students { get; set; }
        public Course Courses { get; set; }
    }
}