using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPCoreSample.Models
{
    public class Selectors
    {

        public SelectList WaterFallList { get; set; }

        public SelectList DescriptionList { get; set; }

    }

    public class WaterFalls

    {

        public int Id { get; set; }

        public string WaterFallName { get; set; }

    }

    public class Description

    {

        public int Id { get; set; }

        public string WaterFallDescription { get; set; }

    }

}
