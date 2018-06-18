using System;
using System.ComponentModel.DataAnnotations;

namespace TotalMVC.ViewModel
{
    public class BirthDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? Birth { get; set; }

        public int StudentCount { get; set; }
    }
}