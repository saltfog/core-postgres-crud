using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Models
{
    public class Search
    {

        public string name { get; set; }
        public int zone { get; set; }
        public string open_to_public { get; set; }

        //public List<Search> results = new List<Search>();

    }
}
