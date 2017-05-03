namespace Comforthuse.Models
{
    public interface IExpenseCategory
    {
        ProductCategory Category { get; }
        decimal Price { get; }
    }
}
