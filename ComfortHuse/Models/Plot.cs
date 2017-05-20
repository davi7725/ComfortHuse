
using System;

namespace Comforthuse.Models
{
    public class Plot : IPlot
    {
        public int Area { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Municipality { get; set; }
        public DateTime AvalibilityDate { get; set; }
    }

    public interface IPlot
    {
        int Area { get; set; }
        string Zipcode { get; set; }
        string Address { get; set; }
        string City { get; set; }
        string Municipality { get; set; }
        DateTime AvalibilityDate { get; set; }
    }
}
