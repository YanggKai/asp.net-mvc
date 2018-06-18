using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TotalMVC.Models
{
    public class Account
    {
        public int ID { get; set; }
        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}