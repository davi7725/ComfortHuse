using Comforthuse.Models;

namespace Comforthuse.Interfaces
{
    public interface IHouseTypeExpenses : IExpenseCategory
    {
        IHouseType HouseType { get; set; }
    }
}
