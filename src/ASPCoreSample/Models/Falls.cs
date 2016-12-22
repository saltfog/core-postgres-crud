using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace ASPCoreSample.Models
{
    public class Falls
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Water Falls")]
        public string Name { get; set; }

        public string Datum { get; set; }

        public int Zone { get; set; }

        public int Northing { get; set; }

        public int Eastling { get; set; }

        public float LatLong { get; set; }

        public string County { get; set; }

        [Required]
        [Display(Name = "Open to Public")]
        public char Open_To_Public { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTimeOffset ConfirmedDate { get; set; }
    }
}
