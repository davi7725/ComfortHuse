using Comforthuse.Utility;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class Case : ICase
    {

        private Dictionary<Category, IExpenseCategory> _expenseCategories;
        public Case(Dictionary<Category, IExpenseCategory> categories)
        {
            _expenseCategories = categories;
            DateOfCreation = DateTime.Now;
            Plot = ObjectFactory.Instance.CreatePlot();
        }

        public Case()
        {
            Plot = ObjectFactory.Instance.CreatePlot();
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

        public IEmployee Employee { get; set; }
        public ICustomer Customer { get; set; }
        public DateTime DateOfCreation { get; internal set; }
        public DateTime DateOfLastRevision { get; internal set; }
        public DateTime ConstructionStartDate { get; set; }

        public DateTime MoveInDate { get; set; }

        public string Description { get; set; }
        public int AmountOfRevisions { get; set; }
        public int CaseNumber { get; set; }
        public int Bank { get; set; }
        public IMoneyInstitute MoneyInstitute { get; set; }
        public IPlot Plot { get; set; }
        public IImage Image { get; set; }
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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public interface ICase
    {
        string Title { get; }
        bool Sold { get; }
        int CaseNumber { get; set; }
        decimal Price { get; }
        int AmountOfRevisions { get; }
        DateTime ConstructionStartDate { get; }
        DateTime MoveInDate { get; }
        string Description { get; }
        ICustomer Customer { get; set; }
        IEmployee Employee { get; set; }
        IPlot Plot { get; set; }
        IExpenseCategory GetExpenseCategory(Category category);
        DateTime DateOfLastRevision { get; }
        DateTime DateOfCreation { get; }
        IMoneyInstitute MoneyInstitute { get; set; }
        IImage Image { get; set; }
        void RegisterRevision();
    }
}
