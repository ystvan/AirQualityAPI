using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AirQualityAPI.Models
{
    public class Mercury
    {
        [Key]
        public int Mercury_Id { get; set; }

        public DateTime DateTimeStart { get; set; }

        public double? Hg { get; set; }

        public string Unit { get; set; }
    }
}
