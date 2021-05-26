using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Route
    {
        [Key]
        public int RouteNumber { get; set; }
        [Required]
        public string StartingPoint { get; set; }
        [Required]
        public string EndPoint { get; set; }

        [Required]
        public string StopOne { get; set; }
        public string StopTwo { get; set; }
        public string StopThree { get; set; }
        public Vehicle Vehicles { get; set; }
    }
}
