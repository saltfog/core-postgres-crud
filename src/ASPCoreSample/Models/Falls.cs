﻿using System;
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
        public int id { get; set; }

        [Required]
        //[Remote("CheckForDuplicates", "Falls")]
        [Display(Name = "Water Fall")]
        public string name { get; set; }

        public string datum { get; set; }

        public int zone { get; set; }

        public int northing { get; set; }

        public int eastling { get; set; }

        public float lat_long { get; set; }

        public int county_id { get; set; }

        [Required]
        [Display(Name = "Open to Public")]
        public string open_to_public { get; set; }

        public int owner_id { get; set; }

        [Required]
        [MaxLength(80)]
        [Display(Name = "Description")]
        public string description { get; set; }

        [Required]
        [DataType(DataType.Date)] //Seems to add a datepicker sweet!
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Added")]
        public DateTime confirmed_date { get; set; }
    }

    public enum County
    {
        Alger,
        Baraga,
        Ontonagon,
        Dickinson,
        Gogebic,
        Delta
    }

    public enum OpenToPublic
    {
        Yes,
        No
    }
}
