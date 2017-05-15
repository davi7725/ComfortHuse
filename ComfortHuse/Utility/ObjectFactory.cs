using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using System.Collections.Generic;

namespace Comforthuse.Utility
{
    public class ObjectFactory
    {
        private static ObjectFactory _instance;
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

        internal List<ITechnicalSpecification> InstanciateTechnicalSpecification(int amount, List<string> presetSpecifications)
        {
            int totalAmount = (amount - presetSpecifications.Count);
            List<ITechnicalSpecification> techSpec = new List<ITechnicalSpecification>();
            foreach (var spec in presetSpecifications)
            {
                techSpec.Add(new TechnicalSpecification() { Description = spec, EditAble = false });
            }

            for (int i = 0; i <= totalAmount; i++)
            {
                techSpec.Add(new TechnicalSpecification());
            }
            return techSpec;
        }

        internal List<ITechnicalSpecification> InstanciateTechnicalSpecification(int amount)
        {
            List<ITechnicalSpecification> techSpec = new List<ITechnicalSpecification>();
            for (int i = 0; i < amount; i++)
            {
                techSpec.Add(new TechnicalSpecification());
            }
            return techSpec;
        }

        internal List<IExtraExpenseSpecification> InstanciateExtraExpense(int amount)
        {
            List<IExtraExpenseSpecification> extraSpec = new List<IExtraExpenseSpecification>();
            for (int i = 0; i < amount; i++)
            {
                extraSpec.Add(new ExtraExpenseSpecification());
            }
            return extraSpec;
        }

        private IHouseTypeExpenses InstanciateHouseType()
        {
            return new HouseTypeExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }

        private CarportGarageExpenses InstanciateCarportGarage()
        {
            return new CarportGarageExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5) };
        }

        internal IEmployee CreateEmployee(string FirstName, string LastName, string Email, string PhoneNb)
        {
            return new Employee(FirstName, LastName, Email, PhoneNb);
        }


        private Dictionary<Category, IExpenseCategory> InstanciateEmptyExpenseCategories()
        {
            Dictionary<Category, IExpenseCategory> categories = new Dictionary<Category, IExpenseCategory>();
            categories.Add(Category.HouseType, InstanciateHouseType());
            categories.Add(Category.CarportGarage, InstanciateCarportGarage());
            return categories;
        }

        public ICase CreateNewCase()
        {
            Case thisCase = new Case(InstanciateEmptyExpenseCategories())
            {
                Customer = CreateNewCustomer()
            };
            return thisCase;
        }

        internal ICase CreateExistingCase()
        {
            return new Case();
        }

        internal ICustomer CreateNewCustomer()
        {
            return new Customer();
        }

        internal ICustomer CreateExistingCustomer(string firstName, string lastName, string email, string city, string address, string zipcode, string phoneNb1, string phoneNb2)
        {
            return new Customer(firstName, lastName, email, city, address, zipcode, phoneNb1, phoneNb2);
        }
    }

}
