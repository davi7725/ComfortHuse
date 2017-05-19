using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using System.Collections.Generic;
using System;

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



        internal IEmployee CreateEmployee(string FirstName, string LastName, string Email, string PhoneNb)
        {
            return new Employee(FirstName, LastName, Email, PhoneNb);
        }


        public Dictionary<Category, IExpenseCategory> InstanciateEmptyExpenseCategories()
        {
            Dictionary<Category, IExpenseCategory> categories = new Dictionary<Category, IExpenseCategory>();
            categories.Add(Category.BrickLayer, InstanciateBrickLayer());
            categories.Add(Category.Plot, InstanciatePlotExpenseCategory());
            categories.Add(Category.Carpentry, InstanciateCarpentry());
            categories.Add(Category.CarportGarage, InstanciateCarportGarage());
            categories.Add(Category.ExtraConstruction, InstanciateExtraConstruction());
            categories.Add(Category.Flooring, InstanciateFlooring());
            categories.Add(Category.HouseType, InstanciateHouseType());
            categories.Add(Category.Interior, InstanciateInterior());
            categories.Add(Category.MaterialInside, InstanciateMaterialInside());
            categories.Add(Category.MaterialOutside, InstanciateMaterialOutside());
            categories.Add(Category.Other, InstanciateOther());
            categories.Add(Category.Painting, InstanciatePainting());
            categories.Add(Category.Plumbing, InstanciatePlumbing());
            categories.Add(Category.Ventilation, InstanciateVentilation());
            categories.Add(Category.WindowsDoors, InstanciateWindowsAndDoors());
            return categories;
        }

        private MaterialsOutsideExpenses InstanciateMaterialOutside()
        {
            return new MaterialsOutsideExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }

        private PlotExpenses InstanciatePlotExpenseCategory()
        {
            return new PlotExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }

        private BrickLayerExpenses InstanciateBrickLayer()
        {
            return new BrickLayerExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private CarpenterExpenses InstanciateCarpentry()
        {
            return new CarpenterExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private CarportGarageExpenses InstanciateCarportGarage()
        {
            return new CarportGarageExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private ExtraConstructionExpenses InstanciateExtraConstruction()
        {
            return new ExtraConstructionExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private FlooringExpenses InstanciateFlooring()
        {
            return new FlooringExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private IHouseTypeExpenses InstanciateHouseType()
        {
            return new HouseTypeExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), HouseType = new HouseType() { Area = 32, TotalPrice = 4000, Name = "E170", Description="Bla bla bla" } };
        }
        private InteriorExpenses InstanciateInterior()
        {
            return new InteriorExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private MaterialsInsideExpenses InstanciateMaterialInside()
        {
            return new MaterialsInsideExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private OtherExpenses InstanciateOther()
        {
            return new OtherExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private PainterExpenses InstanciatePainting()
        {
            return new PainterExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private PlumberExpenses InstanciatePlumbing()
        {
            return new PlumberExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private VentilationExpenses InstanciateVentilation()
        {
            return new VentilationExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
        }
        private WindowsAndDoorsExpenses InstanciateWindowsAndDoors()
        {
            return new WindowsAndDoorsExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5) };
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
