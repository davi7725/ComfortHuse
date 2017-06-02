using Comforthuse.Interfaces;
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
                ProductTypes = GetProductOptions();
            }
        }


        public List<IProductType> GetProductOptions()
        {
            List<IProductType> pl = new List<IProductType>();
            pl.Add(new ProductType(1, "CarportGarage", "CarportGarage")
            {
                //  Category = Category.CarportGarage,
                ListOfProductOptions = new List<IProductOption>()
                       {
                           new ProductOption(1, "Carport", 10,10, "m2", true, 1),
                           new ProductOption(2, "Garage", 10,10, "m2", true, 1)
                       }
            });
            pl.Add(new ProductType(2, "CarportGarage", "CarportGarage")
            {
                //  Category = Category.CarportGarage,
                ListOfProductOptions = new List<IProductOption>()
                    {
                        new ProductOption(1, "Carport", 10, 10, "m2", true, 2),
                        new ProductOption(2, "Garage", 10, 10, "m2", true, 2)
                    }
            }
            );



            return pl;
        }
    }
}
