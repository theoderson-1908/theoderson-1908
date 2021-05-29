using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppoloTravels.Models
{
    public class Route
    {
       [Key]
        public int RouteID { get; set; }
        [Required]
        [Display(Name = "Route Number")]
        public int RouteNumber { get; set; }
       [Required]
       [Display(Name ="Starting Point")]
        public string StartingPoint { get; set; }
        [Required]
        [Display(Name = "Ending Point")]
        public string EndPoint { get; set; }
        [Display(Name = "Stop One")]
        public string StopOne { get; set; }
        [Display(Name = "Stop Two")]
        public string StopTwo { get; set; }
        [Display(Name = "Stop Three")]

        public string StopThree { get; set; }
       public int Distance { get; set; }
    }
}
