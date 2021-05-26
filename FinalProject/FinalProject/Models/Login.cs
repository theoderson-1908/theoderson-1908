using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Login
    {
        
        [Key]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}

