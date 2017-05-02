using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class Case : ICase
    {
        private List<IExpenseCategory> _expenseCategories = new List<IExpenseCategory>();

        public int CaseNumber { get; set; }
        private bool _isSold = true;

        public string Sold => _isSold ? "Yes" : "No";
        public string Title => HouseType + " for " + Customer.FirstName + " " + Customer.LastName;
        public ICustomer Customer { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int AmountOfRevisions { get; set; }
        public DateTime DateOfLastRevision { get; set; }
        public string HouseType { get; set; }
        public float Price => CalculatePrice();

        private float CalculatePrice()
        {
            float price = 0;
            foreach (IExpenseCategory c in _expenseCategories)
            {
                price += c.Price;
            }
            return (float)price;
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
