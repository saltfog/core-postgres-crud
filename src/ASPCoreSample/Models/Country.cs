using ASPCoreSample.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Models
{
    public class Country
    {

        public List<Country> Countries { get; } = new List<Country>();
    }
}
