namespace Comforthuse.Models
{
    public interface IExpenseCategory
    {
        ProductCategory Category { get; }
        float Price { get; set; }
    }
}
