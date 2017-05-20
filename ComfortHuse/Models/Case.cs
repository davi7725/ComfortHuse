using Comforthuse.Utility;
using System;
using System.Collections.Generic;
using Comforthuse.Interfaces;

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
            MoneyInstitute = ObjectFactory.Instance.CreateMoneyInstitute("Danske Bank", "Allerodgade 23", "5300", "Svendborg", "60669041");
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
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastRevision { get; internal set; }
        public DateTime ConstructionStartDate { get; set; }

        public DateTime MoveInDate { get; set; }

        public string Description { get; set; }
        public int AmountOfRevisions { get; set; }
        public int CaseNumber { get; set; }
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
        public string HouseType { get; set; }


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

        public Dictionary<Category, IExpenseCategory> GetAllCategories()
        {
            return _expenseCategories;
        }
    }

    public interface ICase
    {
        string Title { get; }
        bool Sold { get; }
        int CaseNumber { get; set; }
        decimal Price { get; }
        int AmountOfRevisions { get; }

        DateTime ConstructionStartDate { get; set; }

        DateTime MoveInDate { get; set; }

        string Description { get; set; }
        ICustomer Customer { get; set; }
        IExpenseCategory GetExpenseCategory(Category category);
        DateTime DateOfLastRevision { get; }
        DateTime DateOfCreation { get; set; }
        IEmployee Employee { get; set; }
        IMoneyInstitute MoneyInstitute { get; set; }
        IPlot Plot { get; set; }
        IImage Image { get;set; }
        void RegisterRevision();
        Dictionary<Category, IExpenseCategory> GetAllCategories();
    }
}
