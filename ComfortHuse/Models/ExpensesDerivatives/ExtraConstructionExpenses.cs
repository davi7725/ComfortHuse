namespace Comforthuse.Utility
{
    public class ExtraConstructionExpenses : Expenses
    {
        public override decimal Price
        {
            get
            {
                //NOT FINISHED !!!! ADD ALL EXPENSES 
                decimal price = 0;
                price += this.PriceExtraExpenses;

                return price;
            }
        }
    }
}