using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppoloTravels.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [Display(Name = "Employee ID")]
        public int EmployeeID { get; set; }

        [Required]
        [Display(Name = "Employee Name")]
        [StringLength(30,MinimumLength =4,ErrorMessage ="Name should be atleast four characters")]
        public string EmployeeName { get; set; }
        [Required]
        public string Department { get; set; }

        [Required]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "Phone number should be 10 digits")]

        public string Phone { get; set; }

        [Required]
        [Display(Name = "Boarding Point")]
        public string BoardingPoint{ get; set; }
        public string Address { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

        [Display(Name = "Email ID")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
