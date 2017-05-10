namespace Comforthuse.Models
{
    public class ExpenseSpecification
    {
        public virtual string Title { get; set; }
        private int Amount { get; set; }
        private decimal PricePerUnit { get; set; }
        private decimal TotalPrice => Amount * PricePerUnit;
        public decimal Price { get; set; }
    }
}