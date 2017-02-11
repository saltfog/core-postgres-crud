using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Models
{
    public class Search
    {
        [Key]
        int id { get; set; }
        public string name { get; set; }
        public int county { get; set; }
        public string open_to_public { get; set; }
    }
}
