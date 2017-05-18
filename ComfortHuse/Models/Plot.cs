
using System;

namespace Comforthuse.Models
{
    public class Plot : IPlot
    {
        public int Area { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }
        public int Municipality { get; set; }
        public DateTime AvalibilityDate { get; set; }
    }

    public interface IPlot
    {
        int Area { get; set; }
        int ZipCode { get; set; }
        string City { get; set; }
        int Municipality { get; set; }
        DateTime AvalibilityDate { get; set; }
    }
}
