using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TotalMVC.Models
{
    public class Student
    {
        [Required]
        
        public int ID { get; set; }
        
        [StringLength(10),MaxLength(20)]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime Birth { get; set; }

        public string Re { get; set; }

        [Range(16,30)]
        public int Age { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}