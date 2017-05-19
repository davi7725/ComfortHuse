using Comforthuse.Models;

namespace SimpleMVVMExample
{
    public interface IPageViewModel : IExpenseCategory
    {
        string Name { get; }
        IExpenseCategory ExpenseCategory { set; }
    }
}

