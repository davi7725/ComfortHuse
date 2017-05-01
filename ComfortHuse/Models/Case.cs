using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comforthuse.Models
{
    public class Case : ICase 
    {
        public Case()
        {
        }

        public int CaseNumber { get; set; }

        public ICustomer Customer { get; set; }
        public List<IProductCategory> 

        public float Price => CalculatePrice();

        private float CalculatePrice()
        {
            foreach ( in COLLECTION)
            {
                
            }
        }

        public override string ToString() => string.Format($"CaseNumber: {OfferNumber}, OfferNb: {}");
    }

    public interface ICase
    {
        int CaseNumber { get; set; }
        ICustomer customer { get; set; }
    }
}
