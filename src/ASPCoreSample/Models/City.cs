using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreSample.Models
{
    public class City
    {
        public string Name;
        public long Id;
        public string CountryCode;
        public long Population;
        public string District;

        public bool Editable
        {
            get
            {
                return Id > 4079;
            }
        }
    }
}
