using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace EmployeeGUI.ViewModels.ExpenseCategoryPages
{
    public class GarageCarportExpenseViewModel : BaseExpenseViewModel
    {
        private ICarportGarageExpenses _carportGarageExpenses;
        public GarageCarportExpenseViewModel()
        {
            Name = "Garage Type";
        }


        public override IExpenseCategory ExpenseCategory
        {
            set
            {
                _carportGarageExpenses = (ICarportGarageExpenses)value;
                TechnicalSpecifications = _carportGarageExpenses.TechnicalSpecifications;
                ExtraExpenses = _carportGarageExpenses.ExtraExpenses;
                //ProductTypes = _carportGarageExpenses.ProductTypes;
                ProductTypes = _carportGarageExpenses.ProductTypes;
            }
        }
        public List<IProductType> GetProductOptions()
        {
            return new List<IProductType>()
               {
                   new ProductType(1, "Carport and garage", "CarportGarage")
                   {
                     //  Category = Category.CarportGarage,
                       ListOfProductOption = new List<ProductOption>()
                       {
                           new ProductOption(1, "Carport", 10,10, "m2", true, 1),
                           new ProductOption(2, "Garage", 10,10, "m2", true, 1)
                       }
                   }
               };


        }
    }
}
