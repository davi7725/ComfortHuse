using Comforthuse.Models;
using Comforthuse.Utility;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public abstract class Expenses : IExpenseCategory
    {
        public abstract decimal Price { get; }
        public ProductCategory Category { get; }

        public List<ExpenseSpecification> ExtraExpenses
        {
            get { return _extras; }
        }

        public List<TechnicalSpecification> TechnicalSpecifications
        {
            get { return _tecnSpecifications; }
        }

        protected decimal PriceExtraExpenses
        {
            get
            {
                decimal price = 0;
                foreach (ExpenseSpecification exp in _extras)
                {
                    price += exp.Price;
                }
                return price;
            }
        }

        protected List<ExpenseSpecification> _extras = new List<ExpenseSpecification>();

        protected List<TechnicalSpecification> _tecnSpecifications = new List<TechnicalSpecification>();
    }
}

public class HouseTypeExpenses : Expenses
{
    public override decimal Price { get; }
    public HouseTypeExpenses HouseType { get; set; }
    public bool HouseExpansion { get; set; }
}

public class ObjectFactory
{
    /*
    private static ObjectFactory _instance = null;

    private ObjectFactory() { }

    private static ObjectFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ObjectFactory();
            }
            return _instance;
        }
    }
    */




    public ICase CreateNewCase()
    {
        // Instanciate objects for a new case ----
        List<IExpenseCategory> _categories = new List<IExpenseCategory>
            {
            new HouseTypeExpenses(),
            new CarportGarageExpenses(),
            new WindowsAndDoorsExpenses(),
            new MaterialsInsideExpenses(),
            new InteriorExpenses(),
            new FlooringExpenses(),
            new CarpenterExpenses(),
            new BrickLayerExpenses(),
            new PainterExpenses(),
            new PlumberExpenses(),
            new VentilationExpenses(),
            new ExtraConstructionExpenses(),
            new OtherExpenses(),
        };

        Case thisCase = new Case();

        return thisCase;

    }

    public class WindowsAndDoorsExpenses : Expenses
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

    public class OtherExpenses : Expenses
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

    public class VentilationExpenses : Expenses
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

    public class PlumberExpenses : Expenses
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

    public class PainterExpenses : Expenses
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

    public class BrickLayerExpenses : Expenses
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

    public class CarpenterExpenses : Expenses
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

    public class FlooringExpenses : Expenses
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

    public class InteriorExpenses : Expenses
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

    public class MaterialsInsideExpenses : Expenses
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

    public class CarportGarageExpenses : Expenses
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

    public ICase CreateExistingCase()
    {
        return new Case();
    }

    public ICustomer CreateNewCustomer()
    {
        return new Customer();
    }

    public ICustomer CreateExistingCustomer(string firstName, string lastName, string city, string address, string zipcode, string phoneNr1, string phoneNr2)
    {
        return new Customer(firstName, lastName, city, address, zipcode, phoneNr1, phoneNr2);
    }

}
