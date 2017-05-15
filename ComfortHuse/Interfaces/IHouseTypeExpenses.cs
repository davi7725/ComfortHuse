using Comforthuse.Models;

namespace Comforthuse.Interfaces
{
    public interface IHouseTypeExpenses : IExpenseCategory
    {
        HouseType HouseType { get; set; }
    }
}
