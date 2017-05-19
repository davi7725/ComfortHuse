using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comforthuse.Models
{
    public class MoneyInstitute : IMoneyInstitute
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string PhoneNb { get; set; }
    }

    public interface IMoneyInstitute
    {
        string Name { get; set; }
        string Address { get; set; }
        string Zipcode { get; set; }
        string City { get; set; }
        string PhoneNb { get; set; }
    }
}
