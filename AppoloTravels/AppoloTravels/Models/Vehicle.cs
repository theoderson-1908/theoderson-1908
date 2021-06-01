using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppoloTravels.Models
{
    public class Vehicle
    {
        [Key]
        [Required]
        [Display(Name = "Driver ID")] 
        public int DriverID { get; set; }
        [Required]
        [Display(Name ="Driver Name")]
        public string DriverName { get; set; }
        [Required]
        [Display(Name ="Phone")]
        public string DriverContactNumber { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [Display(Name ="Vehicle Number")]
        public string VehicleNumber { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        [Display(Name ="Seats Available")]

        public int SeatsAvailable { get; set; }




       

    }
}
