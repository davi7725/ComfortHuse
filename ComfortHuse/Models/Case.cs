using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class Case : ICase
    {
        // Change
        private Dictionary<Category, IExpenseCategory> _expenseCategories;

        public Case(Dictionary<Category, IExpenseCategory> categories)
        {
            _expenseCategories = categories;
        }

        public IExpenseCategory GetExpenseCategory(Category category)
        {

            return _expenseCategories[category];
        }

        private bool _isSold = true;

        public string Title
        {
            get { return "HouseType" + " for " + Customer.FirstName + " " + Customer.LastName; }
        }

        public IEmployee Employee { get; internal set; }
        public ICustomer Customer { get; set; }
        public DateTime DateOfCreation { get; internal set; }
        public DateTime DateOfLastRevision { get; internal set; }
        public int AmountOfRevisions { get; set; }
        public int CaseNumber { get; set; }

        public bool Sold
        {
            get { return _isSold; }
        }
        public decimal Price
        {
            get
            {
                return CalculatePrice();
            }
        }

        public string HouseType { get; set; }

        public Case()
        {
            DateOfCreation = DateTime.Now;
        }

        private decimal CalculatePrice()
        {
            decimal price = 0;
            foreach (KeyValuePair<Category, IExpenseCategory> c in _expenseCategories)
            {
                if (c.Value != null)
                {
                    price += c.Value.Price;
                }
            }
            return price;
        }

        public void RegisterRevision()
        {
            AmountOfRevisions = AmountOfRevisions++;
            DateOfLastRevision = DateTime.Now;
        }

        public override string ToString() => string.Format($"CaseNumber: {CaseNumber}");

        public override bool Equals(object o)
        {
            bool isEqual = false;
            Case thisCase = (Case)o;
            if (thisCase.CaseNumber == CaseNumber)
            {
                isEqual = true;
            }

            return isEqual;
        }
    }

    public interface ICase
    {
        string Title { get; }
        bool Sold { get; }
        int CaseNumber { get; set; }
        decimal Price { get; }
        int AmountOfRevisions { get; }
        ICustomer Customer { get; set; }
        IExpenseCategory GetExpenseCategory(Category category);
        DateTime DateOfLastRevision { get; }
        DateTime DateOfCreation { get; }
    }
}
