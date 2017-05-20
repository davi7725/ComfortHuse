using Comforthuse;
using Comforthuse.Facade;
using Comforthuse.Interfaces;
using Comforthuse.Models;
using Comforthuse.Utility;
using EmployeeGUI.Helpers;
using EmployeeGUI.ViewModels.ExpenseCategoryPages;
using SimpleMVVMExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace EmployeeGUI.ViewModels
{
    public class CaseViewModel : ObservableObject
    {
        private IEmployeeFacade _facade;
        private ICustomer _caseCustomer;
        private ICommand _changePageCommand;
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;
        private int _caseID;
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
        public IEmployeeFacade Facade
        {
            set { _facade = value; }
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
            get { return "Case Number: " + _activeCase.DateOfCreation.Year + "-" + _activeCase.CaseNumber; }
        }

        internal void SetCaseID(int caseid)
        {
            _caseID = caseid;
        }
        public string FirstName
        {
            get { return _caseCustomer.FirstName; }
            set
            {
                if (value != _caseCustomer.FirstName)
                {
                    _caseCustomer.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
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

        public string PlotAvalibilityDate
        {
            get { return _activeCase.Plot.AvailabilityDate.ToString("MM-dd-yy"); }
            set {
                string dateString = value;
                string[] datestringArr = dateString.Split('-');
                int day;
                int month;
                int year;
                int.TryParse(datestringArr[0], out day);
                int.TryParse(datestringArr[1], out month);
                int.TryParse(datestringArr[2], out year);
                _activeCase.Plot.AvailabilityDate = new DateTime(year,month,day); 
            }
        }

        public string PlotAddress
        {
            get { return _activeCase.Plot.Address; }
            set
            {
                _activeCase.Plot.Address = value; 
            }
        }

        public string PlotCity
        {
            get { return _activeCase.Plot.City; }
            set { _activeCase.Plot.City = value; }
        }
        public string PlotZipcode
        {
            get { return _activeCase.Plot.Zipcode; }
            set { _activeCase.Plot.Zipcode = value; }

        }
        public string PlotMunicipality
        {
            get { return _activeCase.Plot.Municipality; }
            set { _activeCase.Plot.Municipality = value; }
        }
        public string PlotArea
        {
            get { return _activeCase.Plot.Area.ToString(); }
            set
            {
                int area;

                if (int.TryParse(value, out area))
                {
                    _activeCase.Plot.Area = area;
                }
                else
                {
                    if (value != "")
                    {
                        MessageHandling.DisplayErrorMessage("Can only contain numbers");
                    }
                    else
                    {
                        _activeCase.Plot.Area = 0;
                    }
                }
            }
        }
        public string TotalPrice
        {
            get { return "Total price: " + _activeCase.Price + " kr"; }
        }
        public List<IEmployee> Employees
        {
            get { return _facade.GetAllEmployees(); }
        }
        public string SalesPersonPhoneNb
        {
            get { return _activeCase.Employee.PhoneNumber; }
            set { _activeCase.Employee.PhoneNumber = value; }
        }
        public string SalesPersonPhoneEmail
        {
            get { return _activeCase.Employee.Email; }
            set
            {
                if (value != _activeCase.Employee.Email)
                {
                    _activeCase.Employee.Email = value;
                    OnPropertyChanged("SalesPersonPhoneEmail");
                }
            }
        }
        public void InjectExpenseCategories()
        {
            PageViewModels[0].ExpenseCategory = _activeCase.GetExpenseCategory(Category.HouseType);

            ICarportGarageExpenses cpExpenses = (ICarportGarageExpenses)_activeCase.GetExpenseCategory(Category.CarportGarage);
            PageViewModels[1].TechnicalSpecifications = cpExpenses.TechnicalSpecifications;
            PageViewModels[1].ExtraExpenses = cpExpenses.ExtraExpenses;

            IPlotExpenses plExpenses = (IPlotExpenses)_activeCase.GetExpenseCategory(Category.Plot);
            PageViewModels[2].TechnicalSpecifications = plExpenses.TechnicalSpecifications;
            PageViewModels[2].ExtraExpenses = plExpenses.ExtraExpenses;

            IMaterialOutsideExpenses miExpenses = (IMaterialOutsideExpenses)_activeCase.GetExpenseCategory(Category.MaterialOutside);
            PageViewModels[3].TechnicalSpecifications = miExpenses.TechnicalSpecifications;
            PageViewModels[3].ExtraExpenses = miExpenses.ExtraExpenses;
        }

        public bool Save()
        {
            return CaseRepository.Instance.Save(_activeCase);
        }
    }
}
