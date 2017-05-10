using Comforthuse.Models;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class ObjectFactory
    {
        private static ObjectFactory _instance = null;
        private ObjectFactory()
        {
        }

        public static ObjectFactory Instance
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


        public IEmployee CreateEmployee(string FirstName, string LastName, string Email, string PhoneNb)
        {
            return new Employee(FirstName, LastName, Email, PhoneNb);
        }


        public ICase CreateNewCase()
        {

            // Instanciate objects for a new case ----
            List<IExpenseCategory> _categories = new List<IExpenseCategory>();
            List<ITechnicalSpecification> tspec = new List<ITechnicalSpecification>() { new TechnicalSpecification(), new TechnicalSpecification(), new TechnicalSpecification() };
            _categories.Add(new HouseTypeExpenses() { TechnicalSpecifications = tspec });
            _categories.Add(new CarportGarageExpenses());
            _categories.Add(new WindowsAndDoorsExpenses());
            _categories.Add(new MaterialsInsideExpenses());
            _categories.Add(new InteriorExpenses());
            _categories.Add(new FlooringExpenses());
            _categories.Add(new CarpenterExpenses());
            _categories.Add(new BrickLayerExpenses());
            _categories.Add(new PainterExpenses());
            _categories.Add(new PlumberExpenses());
            _categories.Add(new VentilationExpenses());
            _categories.Add(new ExtraConstructionExpenses());
            _categories.Add(new OtherExpenses());

            Case thisCase = new Case() { Customer = new Customer("Allan", "Heboe", "alexale@fsdasd.com", "Odense", "Address", "5200", "60669041", "50505050") };

            return thisCase;
        }

        public ICase CreateExistingCase()
        {
            return new Case();
        }

        public ICustomer CreateNewCustomer()
        {
            return new Customer();
        }

        public ICustomer CreateExistingCustomer(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNr1, string phoneNr2)
        {
            return new Customer(firstName, lastName, email, city, address, zipcode, phoneNr1, phoneNr2);
        }
    }

}
