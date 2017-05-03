using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comforthuse.Models
{
    public class Case : ICase
    {
        private bool _isSold = true;


        public string Sold => _isSold ? "Yes" : "No";
        public string Title => HouseType + " for " + Customer.FirstName + " " + Customer.LastName;
        public float Price => CalculatePrice();

        public int CaseNumber { get; set; }
        public ICustomer Customer { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AmountOfRevisions { get; set; }
        public DateTime DateOfLastRevision { get; set; }
        public string HouseType { get; set; }

        private float CalculatePrice()
        {
            return 0;
        }

        public override string ToString() => string.Format($"CaseNumber: {CaseNumber}");
    }

    public interface ICase
    {
        string Title { get; }
        string Sold { get; }
        int CaseNumber { get; set; }
        float Price { get; }
        ICustomer Customer { get; set; }
        DateTime DateOfLastRevision { get; set; }
        DateTime DateOfCreation { get; set; }
    }
}
