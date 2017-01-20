using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace ASPCoreSample.Models
{
    public class Falls
    {
        [Key]
        public int Id { get; set; }

        [Required]
        //[Remote("CheckForDuplicates", "Falls")]
        [Display(Name = "Water Falls")]
        public string Name { get; set; }

        public string Datum { get; set; }

        public int Zone { get; set; }

        public int Northing { get; set; }

        public int Eastling { get; set; }

        public float Lat_Long { get; set; }

        public int County_Id { get; set; }

        [Required]
        [Display(Name = "Open to Public")]
        public string Open_To_Public { get; set; }

        public int Owner_Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)] //Seems to add a datepicker sweet!
        [Display(Name = "Date Added")]
        public DateTime Confirmed_Date { get; set; }
    }
}
