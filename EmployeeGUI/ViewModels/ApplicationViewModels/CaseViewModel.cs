using Comforthuse;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using EmployeeGUI.Helpers;
using EmployeeGUI.ViewModels.ExpenseCategoryPages;
using SimpleMVVMExample;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace EmployeeGUI.ViewModels
{
    public class CaseViewModel : ObservableObject
    {
        private ICustomer _caseCustomer;
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private ICase _activeCase;

        public ICase Case
        {
            get
            {
                return _activeCase;
            }
            set
            {
                _activeCase = value;
                InstanciateViewModel();
            }
        }

        private void InstanciateViewModel()
        {
            _caseCustomer = _activeCase.Customer;
        }
        public CaseViewModel()
        {

            // Instanciate and add avaliable pages
            PageViewModels.Add(new HouseTypeExpenseViewModel());
            PageViewModels.Add(new GarageCarportExpenseViewModel());
            PageViewModels.Add(new PlotExpenseViewModel());
            PageViewModels.Add(new MaterialsOutsideExpenseViewModel());
            PageViewModels.Add(new WindowsDoorsExpenseViewModel());
            PageViewModels.Add(new MaterialInsideExpenseViewModel());
            PageViewModels.Add(new InteriorExpenseViewModel());
            PageViewModels.Add(new FloorExpenseViewModel());
            PageViewModels.Add(new PowerExpenseViewModel());
            PageViewModels.Add(new HomeApplianceExpenseViewModel());
            PageViewModels.Add(new TilesExpenseViewModel());
            PageViewModels.Add(new CarpentryExpenseViewModel());
            PageViewModels.Add(new PaintExpenseViewModel());
            PageViewModels.Add(new WallingExpenseViewModel());
            PageViewModels.Add(new PlumbingExpenseViewModel());
            PageViewModels.Add(new VentilationExpenseViewModel());
            PageViewModels.Add(new ExtraContructionViewModel());
            PageViewModels.Add(new OtherExpenseViewModel());

            // Set starting page
            CurrentPageViewModel = PageViewModels[0];
        }

        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                     p => ChangeViewModel((IPageViewModel)p),
                     p => p is IPageViewModel);
                }

                return _changePageCommand;
            }
        }

        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }

        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged("CurrentPageViewModel");
                }
            }
        }

        public string CaseID
        {
            get { return "Case Number: " + _activeCase.DateOfCreation.Year + "-" + _activeCase.CaseNumber.ToString(); }
        }

        public string FirstName
        {
            get { return _caseCustomer.FirstName; }
            set { _caseCustomer.FirstName = value; }
        }

        public string LastName
        {
            get { return _caseCustomer.LastName; }
            set { _caseCustomer.LastName = value; }
        }

        public string Email
        {
            get { return _caseCustomer.FirstName; }
            set { _caseCustomer.FirstName = value; }
        }

        public string City
        {
            get { return _caseCustomer.City; }
            set { _caseCustomer.City = value; }
        }

        public string Address
        {
            get { return _caseCustomer.Address; }
            set { _caseCustomer.Address = value; }
        }
        public string Zipcode
        {
            get { return _caseCustomer.Zipcode; }
            set { _caseCustomer.Zipcode = value; }
        }
        public string PhoneNb1
        {
            get { return _caseCustomer.PhoneNb1; }
            set { _caseCustomer.PhoneNb1 = value; }
        }
        public string PhoneNb2
        {
            get { return _caseCustomer.PhoneNb2; }
            set { _caseCustomer.PhoneNb2 = value; }
        }

        public string TotalPrice
        {
            get { return "Total price: " + _activeCase.Price + " kr"; }
        }

        public void InjectExpenseCategories()
        {

            IHouseTypeExpenses hsExpenses = (IHouseTypeExpenses)_activeCase.GetExpenseCategory(Category.HouseType);
            IExpenseCategory cgExtraExpenses = _activeCase.GetExpenseCategory(Category.CarportGarage);
            IExpenseCategory plExtraExpenses = _activeCase.GetExpenseCategory(Category.Plot);
            IExpenseCategory moExtraExpenses = _activeCase.GetExpenseCategory(Category.MaterialOutside);
            IExpenseCategory wdExtraExpenses = _activeCase.GetExpenseCategory(Category.WindowsDoors);
            IExpenseCategory miExtraExpenses = _activeCase.GetExpenseCategory(Category.MaterialInside);
            IExpenseCategory inExtraExpenses = _activeCase.GetExpenseCategory(Category.Interior);
            IExpenseCategory flExtraExpenses = _activeCase.GetExpenseCategory(Category.Flooring);
            IExpenseCategory pwExtraExpenses = _activeCase.GetExpenseCategory(Category.Power);
            IExpenseCategory haExtraExpenses = _activeCase.GetExpenseCategory(Category.Appliances);
            IExpenseCategory tlExtraExpenses = _activeCase.GetExpenseCategory(Category.Tiles);
            IExpenseCategory crExtraExpenses = _activeCase.GetExpenseCategory(Category.Carpentry);
            IExpenseCategory ptExtraExpenses = _activeCase.GetExpenseCategory(Category.Painting);
            IExpenseCategory wlExtraExpenses = _activeCase.GetExpenseCategory(Category.BrickLayer);
            IExpenseCategory pmExtraExpenses = _activeCase.GetExpenseCategory(Category.Plumbing);
            IExpenseCategory vtExtraExpenses = _activeCase.GetExpenseCategory(Category.Ventilation);
            IExpenseCategory exExtraExpenses = _activeCase.GetExpenseCategory(Category.ExtraConstruction);
            IExpenseCategory otExtraExpenses = _activeCase.GetExpenseCategory(Category.Other);


            //TechnicalSpecifications = new List<ITechnicalSpecification>() { new TechnicalSpecification() { Description = "LUL", Ticked = true, EditAble = false }, new TechnicalSpecification() }
            PageViewModels[0].TechnicalSpecifications = hsExpenses.TechnicalSpecifications;
            PageViewModels[0].ExtraExpenses = hsExpenses.ExtraExpenses;

            PageViewModels[1].TechnicalSpecifications = cgExtraExpenses.TechnicalSpecifications;
            PageViewModels[1].ExtraExpenses = cgExtraExpenses.ExtraExpenses;

            PageViewModels[2].TechnicalSpecifications = plExtraExpenses.TechnicalSpecifications;
            PageViewModels[2].ExtraExpenses = plExtraExpenses.ExtraExpenses;

            PageViewModels[3].TechnicalSpecifications = moExtraExpenses.TechnicalSpecifications;
            PageViewModels[3].ExtraExpenses = moExtraExpenses.ExtraExpenses;

            PageViewModels[4].TechnicalSpecifications = wdExtraExpenses.TechnicalSpecifications;
            PageViewModels[4].ExtraExpenses = wdExtraExpenses.ExtraExpenses;

            PageViewModels[5].TechnicalSpecifications = miExtraExpenses.TechnicalSpecifications;
            PageViewModels[5].ExtraExpenses = miExtraExpenses.ExtraExpenses;

            PageViewModels[6].TechnicalSpecifications = inExtraExpenses.TechnicalSpecifications;
            PageViewModels[6].ExtraExpenses = inExtraExpenses.ExtraExpenses;

            PageViewModels[7].TechnicalSpecifications = flExtraExpenses.TechnicalSpecifications;
            PageViewModels[7].ExtraExpenses = flExtraExpenses.ExtraExpenses;

            PageViewModels[8].TechnicalSpecifications = pwExtraExpenses.TechnicalSpecifications;
            PageViewModels[8].ExtraExpenses = pwExtraExpenses.ExtraExpenses;

            PageViewModels[9].TechnicalSpecifications = haExtraExpenses.TechnicalSpecifications;
            PageViewModels[9].ExtraExpenses = haExtraExpenses.ExtraExpenses;

            PageViewModels[10].TechnicalSpecifications = tlExtraExpenses.TechnicalSpecifications;
            PageViewModels[10].ExtraExpenses = tlExtraExpenses.ExtraExpenses;

            PageViewModels[11].TechnicalSpecifications = crExtraExpenses.TechnicalSpecifications;
            PageViewModels[11].ExtraExpenses = crExtraExpenses.ExtraExpenses;

            PageViewModels[12].TechnicalSpecifications = ptExtraExpenses.TechnicalSpecifications;
            PageViewModels[12].ExtraExpenses = ptExtraExpenses.ExtraExpenses;

            PageViewModels[13].TechnicalSpecifications = wlExtraExpenses.TechnicalSpecifications;
            PageViewModels[13].ExtraExpenses = wlExtraExpenses.ExtraExpenses;

            PageViewModels[14].TechnicalSpecifications = pmExtraExpenses.TechnicalSpecifications;
            PageViewModels[14].ExtraExpenses = pmExtraExpenses.ExtraExpenses;

            PageViewModels[15].TechnicalSpecifications = vtExtraExpenses.TechnicalSpecifications;
            PageViewModels[15].ExtraExpenses = vtExtraExpenses.ExtraExpenses;

            PageViewModels[16].TechnicalSpecifications = exExtraExpenses.TechnicalSpecifications;
            PageViewModels[16].ExtraExpenses = exExtraExpenses.ExtraExpenses;

            PageViewModels[17].TechnicalSpecifications = otExtraExpenses.TechnicalSpecifications;
            PageViewModels[17].ExtraExpenses = otExtraExpenses.ExtraExpenses;

        }
    }
}
