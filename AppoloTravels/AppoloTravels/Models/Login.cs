using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppoloTravels.Models
{
    public class Login
    {
        [Key]
        
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "PassWord")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }
    }
}
