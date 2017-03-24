using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityAPI.Models
{
    public class Ozone
    {
        [Key]
        public int Ozone_Id { get; set; }
        public DateTime DateTimeStart { get; set; }
        public double? Ozone1 { get; set; }
        public string Unit { get; set; }
    }
}
