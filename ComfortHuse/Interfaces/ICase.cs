using Comforthuse.Models;
using System;
using System.Collections.Generic;

namespace Comforthuse.Interfaces
{
    public interface ICase
    {
        string Title { get; }
        bool Sold { get; set; }
        int CaseNumber { get; set; }
        decimal Price { get; }
        int AmountOfRevisions { get; set; }

        DateTime? ConstructionStartDate { get; set; }

        DateTime? MoveInDate { get; set; }

        string Description { get; set; }
        ICustomer Customer { get; set; }
        IExpenseCategory GetExpenseCategory(Category category);
        DateTime DateOfLastRevision { get; }
        DateTime DateOfCreation { get; }
        IEmployee Employee { get; set; }
        IMoneyInstitute MoneyInstitute { get; set; }
        IPlot Plot { get; set; }
        IImage Image { get; set; }
        void RegisterRevision();
        Dictionary<Category, IExpenseCategory> GetAllCategories();
    }
}
