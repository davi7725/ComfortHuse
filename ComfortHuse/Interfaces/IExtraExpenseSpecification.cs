namespace Comforthuse.Interfaces
{
    public interface IExtraExpenseSpecification : ISpecification
    {
        string Title { get; set; }
        string Description { get; set; }
        int Amount { get; set; }
        decimal PricePerUnit { get; set; }
        decimal TotalPrice { get; }
    }
}