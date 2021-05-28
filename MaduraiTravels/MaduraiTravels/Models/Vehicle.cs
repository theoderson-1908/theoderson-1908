using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MaduraiTravels.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }
        public string DriverName { get; set; }
        public string DriverContactNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string AvailableSeats { get; set; }
        
        

        [Required]
        public int Capacity { get; set; }

        public IEnumerable<Route> Routes { get; set; }
    }
}
