using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MaduraiTravels.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }

        public int Age { get; set; }
        [Required]
        public string Location { get; set; }
        public string Phone { get; set; }
        public string EmailID { get; set; }
    }
}
