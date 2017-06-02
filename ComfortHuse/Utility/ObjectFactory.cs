using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Models.SpecificationDerivatives;
using System;
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

        public IMoneyInstitute CreateMoneyInstitute(string name, string address, string zipcode, string city, string phonenumber)
        {
            return new MoneyInstitute() { Name = name, Address = address, Zipcode = zipcode, City = city, PhoneNb = phonenumber };
        }

        public IPlot CreatePlot()
        {
            return new Plot() { AvailabilityDate = new DateTime(2017, 2, 1), Area = 23, City = "Odense" };
        }

        internal List<ITechnicalSpecification> InstanciateTechnicalSpecification(int amount, List<string> presetSpecifications)
        {
            int totalAmount = (amount - presetSpecifications.Count);
            List<ITechnicalSpecification> techSpec = new List<ITechnicalSpecification>();
            foreach (var spec in presetSpecifications)
            {
                techSpec.Add(new TechnicalSpecification() { Description = spec, Editable = false });
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



        public IEmployee CreateEmployee(string FirstName, string LastName, string Email, string PhoneNb)
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
            return new MaterialsOutsideExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.MaterialOutside) };
        }

        private PlotExpenses InstanciatePlotExpenseCategory()
        {
            return new PlotExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Plot) };
        }

        private BrickLayerExpenses InstanciateBrickLayer()
        {
            return new BrickLayerExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.BrickLayer) };
        }
        private CarpenterExpenses InstanciateCarpentry()
        {
            return new CarpenterExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Carpentry) };
        }
        private CarportGarageExpenses InstanciateCarportGarage()
        {
            return new CarportGarageExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.CarportGarage) };
        }
        private ExtraConstructionExpenses InstanciateExtraConstruction()
        {
            return new ExtraConstructionExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.ExtraConstruction) };
        }
        private FlooringExpenses InstanciateFlooring()
        {
            return new FlooringExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Flooring) };
        }
        private IHouseTypeExpenses InstanciateHouseType()
        {
            return new HouseTypeExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), HouseType = new HouseType(), ProductTypes = ProductTypeRepository.Instance.Load(Category.HouseType) };
        }
        private InteriorExpenses InstanciateInterior()
        {
            return new InteriorExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Interior) };
        }
        private MaterialsInsideExpenses InstanciateMaterialInside()
        {
            return new MaterialsInsideExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.MaterialInside) };
        }
        private OtherExpenses InstanciateOther()
        {
            return new OtherExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Other) };
        }
        private PainterExpenses InstanciatePainting()
        {
            return new PainterExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Painting) };
        }
        private PlumberExpenses InstanciatePlumbing()
        {
            return new PlumberExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Plumbing) };
        }
        private VentilationExpenses InstanciateVentilation()
        {
            return new VentilationExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.Ventilation) };
        }
        private WindowsAndDoorsExpenses InstanciateWindowsAndDoors()
        {
            return new WindowsAndDoorsExpenses() { TechnicalSpecifications = InstanciateTechnicalSpecification(5), ExtraExpenses = InstanciateExtraExpense(5), ProductTypes = ProductTypeRepository.Instance.Load(Category.WindowsDoors) };
        }


        public ICase CreateNewCase()
        {
            Case thisCase = new Case(InstanciateEmptyExpenseCategories())
            {
                Customer = CreateNewCustomer(),
                CaseNumber = 0,
                Plot = CreateNewPlot(),
                MoneyInstitute = CreateNewMoneyInstitute(),
                Image = CreateNewImage()
            };
            return thisCase;
        }

        private IMoneyInstitute CreateNewMoneyInstitute()
        {
            return new MoneyInstitute() { Name = "", Address = "", City = "", Zipcode = "", PhoneNb = "" };
        }

        public IImage CreateNewImage()
        {
            return new Image() { Path = "", Description = "" };
        }

        private IPlot CreateNewPlot()
        {
            return new Plot() { Zipcode = "", Address = "", Area = 0, AvailabilityDate = null, City = "", Municipality = "" };
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
