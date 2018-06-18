using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TotalMVC.Models
{
    public class Course
    {
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        [Range(1,20)]
        public decimal Credit { get; set; }
        public string Genre { get; set; }

        public ICollection<Enrollment> Enrollment { get; set; }
    }
}