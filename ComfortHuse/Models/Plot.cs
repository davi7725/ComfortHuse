
using System;

namespace Comforthuse.Models
{
    public class Plot :IPlot
    {
        public string Zipcode { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Area { get; set; }
        public string Municipality { get; set; }
        public DateTime AvailabilityDate { get; set; }
    }

    public interface IPlot
    {
        string Zipcode { get; }
        string Address { get;}
        string City { get;}
        string Area { get; }
        string Municipality { get;}
        DateTime AvailabilityDate { get; }
    }
}
