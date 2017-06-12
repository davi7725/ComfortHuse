using Comforthuse.Interfaces;
using Comforthuse.Utility;
using EmployeeGUI.Helpers;
using System;
using System.Collections.Generic;

namespace Comforthuse.Models
{
    public class Case : ObservableObject, ICase
    {


        private bool _isSold = true;
        private Dictionary<Category, IExpenseCategory> _expenseCategories;

        public Case(Dictionary<Category, IExpenseCategory> categories)
        {
            _expenseCategories = categories;
            DateOfCreation = DateTime.Now;
        }

        public Case()
        {
            Plot = ObjectFactory.Instance.CreatePlot();
        }

        public string Title
        {
            get { return "HouseType" + " for " + Customer.FirstName + " " + Customer.LastName; }
        }

        public IEmployee Employee { get; set; }
        public ICustomer Customer { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime DateOfLastRevision { get; internal set; }
        public DateTime? ConstructionStartDate { get; set; }

        public DateTime? MoveInDate { get; set; }
        public int AmountOfRevisions { get; set; }

        public string Description { get; set; }
        public int CaseNumber { get; set; }
        public IMoneyInstitute MoneyInstitute { get; set; }
        public IPlot Plot { get; set; }
        public IImage Image { get; set; }

        public bool Sold
        {
            get { return _isSold; }
            set { _isSold = value; }
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
        public IExpenseCategory GetExpenseCategory(Category category)
        {

            return _expenseCategories[category];
        }

        public override string ToString()
        {
            return string.Format($"CaseNumber: {CaseNumber}");
        }

        public override bool Equals(object obj)
        {
            bool isEqual = false;
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;

            }
            Case thisCase = (Case)obj;
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
}
