using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_api.Models
{
    public class SensorData
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength =3)]
        public string Name { get; set; }
        public double Value { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReceiveTime { get; set; }
    }
}
