namespace Comforthuse.Models
{
    class ExpenseSpecification
    {
        public virtual string Title { get; set; }
        private int Amount { get; set; }
        private double PricePerUnit { get; set; }
        private double TotalPrice => Amount * PricePerUnit;
    }
}